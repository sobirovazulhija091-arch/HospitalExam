
using Dapper;
using System.Net;
public class ScheduleSlotService(ApplicationDbcontext dbcontext):IScheduleSlotService
{
   private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<Response<string>> AddAsync(Schedule_slotDto schedule_slotDto)
    {
        using var conn = _dbcontext.Connaction();
        var query="insert into schedule_slots(roomid,doctorid,isactive) values(@roomid,@doctorid,@isactive)";
        var res = await conn.ExecuteAsync(query,new{roomid=schedule_slotDto.RoomId,doctorid=schedule_slotDto.DoctorId,isactive=schedule_slotDto.Isactive});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<Response<string>> DeleteAsync(int schedule_slotid)
    {
       using var conn = _dbcontext.Connaction();
        var query="delete from schedule_slots where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=schedule_slotid});
         return res == 0 ? new Response<string>(HttpStatusCode.NotFound,"NotFound")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<List<Schedule_slot>> GetAsync()
    {
        using var conn = _dbcontext.Connaction();
        var query="select s.*,d.*,r.* from schedule_slots s  join rooms r on r.id=s.roomid join doctors d  on d.id=s.doctorid";
        var res = await conn.QueryAsync<Schedule_slot>(query);
        return res.ToList();
    }

    public async Task<Response<Schedule_slot>> GetByIdAsync(int schedule_slotid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from schedule_slots where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Schedule_slot>(query,new{Id=schedule_slotid});
        return res ==null? new Response<Schedule_slot>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Schedule_slot>(HttpStatusCode.OK,"Ok",res);
    }

    public async Task<Response<Schedule_slot>>GetDoctorAsync(int schedule_slotid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select s.*,d.fullname from schedule_slots s join doctors d on d.id=s.doctorid where s.id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Schedule_slot>(query,new{Id=schedule_slotid});
        return res ==null? new Response<Schedule_slot>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Schedule_slot>(HttpStatusCode.OK,"Ok",res);
    }

    public async Task<Response<string>> UpdateActiveAsync(int schedule_slotid, bool active)
    {
           using var conn =_dbcontext.Connaction();
        var query="update schedule_slots set isactive=@Isactive where id=@Id";
       var res = await conn.ExecuteAsync(query,new {Isactive=active,Id=schedule_slotid});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
        :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
}