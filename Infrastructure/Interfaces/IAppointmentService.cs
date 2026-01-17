public interface IAppointmentService
{
 
      Task<Response<string>> AddAsync(AppointmentDto appointmentDto);
      Task<Response<string>> DeleteAsync(int appointmentid);
      Task<Response<string>> UpdateAsync(UpdatedAppointmentDto updatedAppointmentDto);
      Task<Response<string>> UpdateCheckStatusinAsync(int appointmentid,string status);
      Task<Response<string>> UpdateStartStatusAsync(int appointmentid,string status);
      Task<Response<string>> UpdateFinishStatusAsync(int appointmentid,string status);
      Task<Response<string>> UpdateCancelStatusAsync(int appointmentid,string status);
      Task<Response<Appointment>>  GetByIdAsync(int appointmentid);
      Task<List<Appointment>>  GetWhitDoctorAsync(int appointmentid);   
      Task<List<Appointment>>  GetAsync();   //all
}