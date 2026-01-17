using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController(IAppointmentService appointmentService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(AppointmentDto appointmentDto)
    {
       return await appointmentService.AddAsync(appointmentDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int appointmentid)
    {
        return await appointmentService.DeleteAsync(appointmentid);
    }
    [HttpGet]
    public async Task<List<Appointment>> GetAsync()
    {
         return await appointmentService.GetAsync();
    }
    [HttpGet("appointmentid")]
    public async Task<Response<Appointment>> GetByIdAsync(int appointmentid)
    {
          return await appointmentService.GetByIdAsync(appointmentid);
    }
    [HttpGet("appointmentid/patient")]
    public async Task<List<Appointment>> GetWhitDoctorAsync(int appointmentid)
    {
         return await appointmentService.GetWhitDoctorAsync(appointmentid);
    }
    [HttpPatch("updateappoinmentdto")]
    public async Task<Response<string>> UpdateAsync(UpdatedAppointmentDto updatedAppointmentDto)
    {
         return await appointmentService.UpdateAsync(updatedAppointmentDto);
    }
    [HttpPatch("cancel")]
    public async Task<Response<string>> UpdateCancelStatusAsync(int appointmentid,string status)
    {
        return await appointmentService.UpdateCancelStatusAsync(appointmentid,status);
    }
    [HttpPatch("check")]
    public async Task<Response<string>> UpdateCheckStatusinAsync(int appointmentid,string status)
    {
        return await appointmentService.UpdateCheckStatusinAsync(appointmentid,status);
    }
    [HttpPatch("finish")]
    public async Task<Response<string>> UpdateFinishStatusAsync(int appointmentid,string status)
    {
         return await appointmentService.UpdateFinishStatusAsync(appointmentid,status);
    }
    [HttpPatch("start")]
    public async Task<Response<string>> UpdateStartStatusAsync(int appointmentid,string status)
    {
        return await appointmentService.UpdateStartStatusAsync(appointmentid,status);
    }
}