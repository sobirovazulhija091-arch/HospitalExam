using System.Net;
using Dapper;

public class RoomService(ApplicationDbcontext dbcontext):IRoomService
{
 private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<Response<string>> AddAsync(RoomDto roomDto)
    {
        using var conn = _dbcontext.Connaction();
        var query="insert into rooms(name,isactive) values(@name,@isactive)";
         var res= await conn.ExecuteAsync(query,new{name=roomDto.Name,isactive=roomDto.Isactive});
          return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<Response<string>> DeleteAsync(int roomid)
    {
        using var conn = _dbcontext.Connaction();
        var query="delete from rooms where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=roomid});
         return res == 0 ? new Response<string>(HttpStatusCode.NotFound,"NotFound")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<List<Room>> GetAsync()
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from rooms";
        var res = await conn.QueryAsync<Room>(query);
        return res.ToList();
    }

    public async Task<Response<Room>> GetByIdAsync(int roomid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from rooms where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Room>(query,new{Id=roomid});
        return res ==null? new Response<Room>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Room>(HttpStatusCode.OK,"Ok",res);
    }
    public async Task<Response<string>> UpdateActiveAsync(int roomid,bool active)
    {
        using var conn = _dbcontext.Connaction();
        var query="update rooms set isactive=@Isactive WHERE id = @Id";
       var res = await conn.ExecuteAsync(query,new{Isactive=active,Id=roomid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
}