
using Dapper;
using System.Net;
public class AppointmentService(ApplicationDbcontext dbcontext) : IAppointmentService
{
      private readonly ApplicationDbcontext _dbcontext=dbcontext;
    public async Task<Response<string>> AddAsync(AppointmentDto appointmentDto)
    {
        using var conn = _dbcontext.Connaction();
        var query="insert into appointments(patientid,slotid,status) values(@patientid,@slotid,@status)";
        var res = await conn.ExecuteAsync(query , new{patientid=appointmentDto.PatientId,
        slotid=appointmentDto.SlotId,status=appointmentDto.Status});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> DeleteAsync(int appointmentid)
    {
        using var conn = _dbcontext.Connaction();
        var query="delete from appointments where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=appointmentid});
         return res == 0 ? new Response<string>(HttpStatusCode.NotFound,"NotFound")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<List<Appointment>> GetAsync()
    {
         using var conn = _dbcontext.Connaction();
        var query="select s.*,p.*,a.* from appointments a join schedule_slot s on s.id=a.slotid join patients p on p.id=a.patientid";
        var res = await conn.QueryAsync<Appointment>(query);
        return res.ToList();
    }
    public async Task<Response<Appointment>> GetByIdAsync(int appointmentid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from appointments where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Appointment>(query,new{Id=appointmentid});
        return res ==null? new Response<Appointment>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Appointment>(HttpStatusCode.OK,"Ok");
    }
    public async Task<List<Appointment>> GetWhitDoctorAsync(int appointmentid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select p.*,a.* from appointments a join patients p on p.id=a.patientid";
        var res = await conn.QueryAsync<Appointment>(query);
        return res.ToList();
    }
    public async Task<Response<string>> UpdateAsync(UpdatedAppointmentDto updatedAppointmentDto)
    {
           using var conn = _dbcontext.Connaction();
       var query="update appointments set status=@Statues,patientid=@PatientId,slotid=@SlotId,updatedat=now() WHERE id = @AppointmentId";
        var res = await conn.ExecuteAsync(query,updatedAppointmentDto);
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> UpdateCancelStatusAsync(int appointmentid,string status)
    {
         using var conn = _dbcontext.Connaction();
       var query="update appointments set status = ' cancelled',updatedat=now() WHERE id = @AppointmentId";
        var res = await conn.ExecuteAsync(query,new{Status = status,   AppointmentId = appointmentid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> UpdateCheckStatusinAsync(int appointmentid,string status)
    {
         using var conn = _dbcontext.Connaction();
        var query="update appointments set status = 'checked_in',updatedat=now() WHERE id = @AppointmentId";
       var res = await conn.ExecuteAsync(query,new{Status = status,   AppointmentId = appointmentid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> UpdateFinishStatusAsync(int appointmentid,string status)
    {
        using var conn = _dbcontext.Connaction();
          var query="update appointments set status = 'dane',updatedat=now() WHERE id = @AppointmentId";
         var res = await conn.ExecuteAsync(query,new{Status = status,   AppointmentId = appointmentid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> UpdateStartStatusAsync(int appointmentid,string status)
    {
        using var conn = _dbcontext.Connaction();
          var query="update appointments set status = 'in_progress',updatedat=now() WHERE id = @AppointmentId";
       var res = await conn.ExecuteAsync(query,new{Status = status,   AppointmentId = appointmentid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
}