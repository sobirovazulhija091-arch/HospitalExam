public interface IScheduleSlotService
{
      Task<Response<string>> AddAsync(Schedule_slotDto schedule_slotDto);
      Task<Response<string>> DeleteAsync(int schedule_slotid);
      Task<Response<string>> UpdateActiveAsync(int schedule_slotid,bool active);
      Task<Response<Schedule_slot>>  GetByIdAsync(int schedule_slotid);
      Task<List<Schedule_slot>>  GetAsync(); 
      Task<Response<Schedule_slot>>  GetDoctorAsync(int schedule_slotid);//doctors
  
}