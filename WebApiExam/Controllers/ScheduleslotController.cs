using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScheduleslotController(IScheduleSlotService scheduleSlotService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(Schedule_slotDto schedule_slotDto)
    {
     return await scheduleSlotService.AddAsync(schedule_slotDto);   
    }
[HttpDelete]
    public async Task<Response<string>> DeleteAsync(int schedule_slotid)
    {
       return await scheduleSlotService.DeleteAsync(schedule_slotid);
    }
[HttpGet]
    public async Task<List<Schedule_slot>> GetAsync()
    {
         return await scheduleSlotService.GetAsync();
    }
[HttpGet("id")]
    public async Task<Response<Schedule_slot>> GetByIdAsync(int schedule_slotid)
    {
       return await scheduleSlotService.GetByIdAsync(schedule_slotid);
    }
[HttpGet("doctors")]
    public async Task<Response<Schedule_slot>>GetDoctorAsync(int schedule_slotid)
    {
         return await scheduleSlotService.GetDoctorAsync(schedule_slotid);
    }
[HttpPatch]
    public async Task<Response<string>> UpdateActiveAsync(int schedule_slotid, bool active)
    {
        return await scheduleSlotService.UpdateActiveAsync(schedule_slotid,active);
    }
}