using Microsoft.AspNetCore.Mvc;
using soul_whisper.Models.Public;
using soul_whisper.Helpers;
using soul_whisper.Data;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Models.Private.Data;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Controllers;

[ApiController]
[Route("[controller]", Name = "registrations")]

public class RegistrationsController : ControllerBase
{
    private readonly string MISSING_TOKEN = "Missing token!";
    private readonly ILogger<RegistrationsController> _logger;
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
    public RegistrationsController(ILogger<RegistrationsController> logger)
    {
        _logger = logger;
    }
    // [HttpGet("achievements/{registrationId}")]
    // public async Task<ActionResult<BaseResponseDTO>> GetAchievementRegistrationById(Guid registrationId)
    // {

    // }



    [HttpGet("doctorships/{registrationId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetDoctorshipRegistrationById(Guid registrationId)
    {
        using (FlatformContext context = new FlatformContext())

        {
            var reg = await context.doctorship_registrations.FirstOrDefaultAsync(i => i.id == registrationId);

            if (reg != null)
            {
                return Ok(new ContainDataResponseDTO
                {
                    data = new DoctorshipRegistrationDTO
                    {
                        id = registrationId,
                        doctor = ModelsConverterMachine.ConvertDoctorToDoctorDTO(reg.registrant),

                        status = reg.status.ToString(),
                        createdAt = reg.createdAt,
                        expiredAt = reg.expiredAt
                    }
                });
            }
            return BadRequest(new ContainMessageResponseDTO { message = "This registration is not exist" });
        }
    }
    [HttpGet("doctorships")]
    public ActionResult<BaseResponseDTO> GetDoctorshipRegistrations()
    {
        string? limit = HttpContext.Request.Query["limit"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.role != UserRole.ADMIN)
        {
            return BadRequest(new ContainMessageResponseDTO { message = "User do not have er mission" });

        }
        List<DoctorshipRegistrationDTO> okoko = [];
        using (FlatformContext context = new FlatformContext())

        {
            List<Doctorship_Registration> reg = [];
            if (limit != null)
            {
                reg = (List<Doctorship_Registration>)context.doctorship_registrations.ToList().Take(Int32.Parse(limit));
            }
            else
            {
                reg = context.doctorship_registrations.ToList();

            }


            if (reg != null)
            {
                reg.ForEach(it =>
                {
                    okoko.Add(new DoctorshipRegistrationDTO
                    {
                        id = it.id,
                        doctor = ModelsConverterMachine.ConvertDoctorToDoctorDTO(context.doctors.FirstOrDefault(i => i.id == it.registrant.id)),
                        status = it.status.ToString(),
                        createdAt = it.createdAt,
                        expiredAt = it.expiredAt
                    });
                });
                return Ok(new ContainDataResponseDTO
                {
                    data = okoko
                });
            }
            return Ok(new ContainDataResponseDTO { data = okoko });
        }
    }

    [HttpPost("doctorships")]
    public async Task<ActionResult<BaseResponseDTO>> CreateDoctorshipRegistration(DoctorshipRegistrationDTO registration)
    {
        using (FlatformContext context = new FlatformContext())
        {
            context.doctorship_registrations.Add(new Doctorship_Registration
            {
                
                status = RegistrationStatus.PENDING,
                createdAt = DateTime.Now,
                expiredAt=DateTime.Now.AddDays(30),
                registrant=new Doctor{
                    email=registration.doctor.email,
                    password=registration.doctor.password,
                    name=registration.doctor.name,
                    avatar=registration.doctor.avatar,
                    birthday=registration.doctor.birthday,
                    gender=(Gender) Enum.Parse(typeof(Gender),registration.doctor.gender),
                    activationStatus=ActivationStatus.PENDING,
                    specialty=(MedicalSpecialty)Enum.Parse(typeof(MedicalSpecialty),registration.doctor.specialty),
                    moneyInWallet=0,
                    achievements=[]
                }
            });
            context.SaveChanges();
            return Ok(new ContainMessageResponseDTO { message = "Created successfully" });
        }
    }
    [HttpPatch("doctorships/{registrationId}")]
    public ActionResult<BaseResponseDTO> UpdateDoctorRegistration(Guid registrationId, UpdateDoctorshipRegistrationDTO update)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        using (FlatformContext context = new FlatformContext())
        {
            Doctorship_Registration? reg = context.doctorship_registrations.FirstOrDefault(i => i.id == registrationId);
            if (user.role != UserRole.ADMIN)
            {
                    return BadRequest(new ContainMessageResponseDTO { message = "User do not have permission" });
            }
            if (reg != null)
            {
                reg.status = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), update.status);
            context.SaveChanges();
                return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });
            }
            return BadRequest(new ContainMessageResponseDTO { message = "updated failfully" });
        }
    }



    [HttpGet("appointments/{registrationId}")]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointmentRegistrationById(Guid registrationId)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        using (FlatformContext context = new FlatformContext())

        {
            var reg = await context.appointment_Registrations.FirstOrDefaultAsync(i => i.id == registrationId);
            if (reg != null)
            {
                return Ok(new ContainDataResponseDTO
                {
                    data = new AppointmentRegistrationDTO
                    {
                        id = registrationId,
                        doctorId = (Guid)reg.doctor.id,
                        status = reg.status.ToString(),
                        createdAt = (DateTime)reg.createdAt,
                        patientId = user.userId,
                        appointment = ModelsConverterMachine.ConvertAppointmentToAppointmentDTO(reg.appointment)
                    }
                });
            }
            return BadRequest(new ContainMessageResponseDTO { message = "This registration is not exist" });
        }
    }
    [HttpGet("appointments")]
    public async Task<ActionResult<BaseResponseDTO>> GetAppointmentRegistrations()
    {
        string? doctorId = HttpContext.Request.Query["doctorId"];
        string? patientId = HttpContext.Request.Query["patientId"];
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        List<AppointmentRegistrationDTO> okoko = [];
        using (FlatformContext context = new FlatformContext())

        {
            List<Appointment_Registration> reg;
            if (doctorId != null && patientId != null)
            {
                reg = context.appointment_Registrations.Where(i => i.doctor.id == Guid.Parse(doctorId) && i.patient.id == Guid.Parse(patientId)).ToList();
            }
            else if (doctorId != null && patientId == null)
            {
                reg = context.appointment_Registrations.Where(i => i.doctor.id == Guid.Parse(doctorId)).ToList();
            }
            else if (doctorId == null && patientId != null)
            {
                reg = context.appointment_Registrations.Where(i => i.patient.id == Guid.Parse(patientId)).ToList();
            }
            else
            {
                if (user.role == UserRole.ADMIN)
                {
                    reg = context.appointment_Registrations.ToList();

                }
                else
                {
                    return BadRequest(new ContainMessageResponseDTO { message = "User do not have permission" });

                }
            }
            if (reg != null)
            {
                reg.ForEach(i =>
                {
                    okoko.Add(new AppointmentRegistrationDTO
                    {
                        id = i.id,
                        doctorId = (Guid)i.doctor.id,
                        status = i.status.ToString(),
                        createdAt = (DateTime)i.createdAt,
                        patientId = (Guid)i.patient.id,
                        appointment = ModelsConverterMachine.ConvertAppointmentToAppointmentDTO(i.appointment)
                    });
                });
                return Ok(new ContainDataResponseDTO
                {
                    data = okoko
                });
            }
            return Ok(new ContainDataResponseDTO { data = okoko });
        }
    }

    [HttpPost("appointments")]
    public async Task<ActionResult<BaseResponseDTO>> CreateAppointmentRegistration(AppointmentRegistrationDTO registration)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        if (user.userId != registration.doctorId && user.userId != registration.patientId)
        {
            return BadRequest(new ContainMessageResponseDTO { message = "User do not have er mission" });
        }
        using (FlatformContext context = new FlatformContext())

        {
            var doctor = context.doctors.FirstOrDefault(i => i.id == registration.doctorId);
            var patient = context.patients.FirstOrDefault(i => i.id == registration.patientId);
            if (doctor == null || patient == null)
            {
                return BadRequest(new ContainMessageResponseDTO { message = "Patient or doctor is not exist" });
            }
            context.appointment_Registrations.Add(new Appointment_Registration
            {
                doctor = doctor,
                patient = patient,
                appointment = new Appointment
                {
                    type = (AppointmentType)Enum.Parse(typeof(AppointmentType), registration.appointment.type),
                    startTime = registration.appointment.startTime,
                    endTime = registration.appointment.endTime,
                    doctor = doctor,
                    patient = patient,
                    status = AppoinmentStatus.NOT_OCCURRED
                },
                status = RegistrationStatus.PENDING,
                createdAt = DateTime.Now

            });
            context.SaveChanges();
            return Ok(new ContainMessageResponseDTO { message = "Created successfully" });
        }
    }
    [HttpPatch("appointments/{registrationId}")]
    public ActionResult<BaseResponseDTO> UpdateAppointmentRegistration(Guid registrationId, UpdateAppointmentRegistrationDTO update)
    {
        UserDTO user = this.ConvertAccessTokenToUserDTO();
        using (FlatformContext context = new FlatformContext())
        {
            Appointment_Registration? reg = null;
            if (user.role == UserRole.DOCTOR)
            {
                reg = context.appointment_Registrations.FirstOrDefault(i => i.id == registrationId && user.userId == i.doctor.id);
            }
            if (reg != null)
            {
                reg.status = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), update.status);
            context.SaveChanges();
                return Ok(new ContainMessageResponseDTO { message = "Updated successfully" });
            }
            return Ok(new ContainMessageResponseDTO { message = "updated failfully" });
        }
    }

}

