using Microsoft.AspNetCore.Mvc;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Patient;
using soul_whisper.Models.Public;
using soul_whisper.Service;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "receipts")]

public class ReceiptsController : ControllerBase
{
    private readonly ILogger<ReceiptsController> _logger;
    private readonly string LOGOUT_SUCCESSFULLY = "Logout fully!";
    private readonly string LOGOUT_FAIL = "Logout fully!";

    public ReceiptsController(ILogger<ReceiptsController> logger)
    {
        _logger = logger;
    }
   

    [HttpGet]
    public async Task<ActionResult<BaseResponseDTO>> GetReceipts()
    {
        string? limit = HttpContext.Request.Query["limit"];
    }
    [HttpPost]
    public async Task<ActionResult<BaseResponseDTO>> CreateReceipts(ReceiptDTO receipt)
    {

    }
    [HttpGet("{receiptId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetReceiptByReceiptId(Guid receiptId)
    {

    }
}

