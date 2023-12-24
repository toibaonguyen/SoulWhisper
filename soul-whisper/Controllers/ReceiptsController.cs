using Microsoft.AspNetCore.Mvc;
using soul_whisper.Data;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Data;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "receipts")]

public class ReceiptsController : ControllerBase
{
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly ILogger<ReceiptsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAIL = "Logout fully!";
    private UserDTO ConvertAccessTokenToUserDTO()
    {
        string? authHeaderValue = HttpContext.Request.Headers["Authorization"];
        if (String.IsNullOrEmpty(authHeaderValue))
        {
            throw new UnauthorizedAccessException(this.MISSING_TOKEN);
        }
        var myMachine = new TokenConverterMachine();
        UserDTO user = myMachine.ConvertAccessTokenToUserDTO(authHeaderValue);
        return user;
    }
    public ReceiptsController(ILogger<ReceiptsController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetReceipts()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();

        using (FlatformContext context = new FlatformContext())
        {
            var receipts = context.receipts.Where(i => i.patient.id == user.userId || i.doctor.id == user.userId).ToList();
            List<ReceiptDTO> receipts1 = [];
            receipts.ForEach(
                item =>
                {
                    receipts1.Add(
                        new ReceiptDTO
                        {
                            id = item.id,
                            type = item.type.ToString(),
                            userId = user.userId,
                            details = item.details,
                            amount = item.amount,
                            createAt = item.createAt
                        });
                }
            );
            return Ok(new ContainDataResponseDTO { data = receipts1 });
        }

    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateReceipts(ReceiptDTO receipt)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role == UserRole.ADMIN)
        {
            using (FlatformContext context = new FlatformContext())
            {
                await context.receipts.AddAsync(new Receipt
                {
                    type = (ReceiptType)Enum.Parse(typeof(ReceiptType), receipt.type),
                    id = receipt.id,
                    patient = context.patients.FirstOrDefault(i => i.id == receipt.userId),
                    doctor = context.doctors.FirstOrDefault(i => i.id == receipt.userId),
                    details = receipt.details,
                    amount = receipt.amount,
                    createAt = receipt.createAt

                });

                return Ok(new ContainMessageResponseDTO { message = "Created successfully" });
            }
        }
        else
        {
            return BadRequest(new ContainMessageResponseDTO { message = "User do not have permission" });
        }

    }
    [HttpGet("{receiptId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetReceiptByReceiptId(Guid receiptId)
    {
        using (FlatformContext context = new FlatformContext())
        {
            var receipt = context.receipts.FirstOrDefault(i => i.id == receiptId);
            if (receipt != null)
            {

            }
            return Ok(new ContainDataResponseDTO
            {
                data = new ReceiptDTO
                {
                    id = receipt.id,
                    type = receipt.type.ToString(),
                    userId = (Guid)(receipt.patient.id ?? receipt.doctor.id),
                    details = receipt.details,
                    amount = receipt.amount,
                    createAt = receipt.createAt
                }
            });
        }
    }
}

