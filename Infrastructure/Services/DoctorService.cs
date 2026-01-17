using System.Net;
using Dapper;

public class DoctorService(ApplicationDbcontext dbcontext):IDoctorService
{
    private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<Response<string>> AddAsync(DoctorDto doctorDto)
    {
        using var conn = _dbcontext.Connaction();
        var query="insert into doctors(fullname,specialty,birthdate,isactive) values(@fullname,@specialty,@birthdate,@isactive)";
        var res = await conn.ExecuteAsync(query,new{fullname=doctorDto.Fullname,specialty=doctorDto.Specialty,birthdate=doctorDto.Birthdate,isactive=doctorDto.Isactive});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<Response<string>> DeleteAsync(int doctorid)
    {
         using var conn = _dbcontext.Connaction();
        var query="delete from doctors where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=doctorid});
         return res == 0 ? new Response<string>(HttpStatusCode.NotFound,"NotFound")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<List<Doctor>> GetAsync()
    {
          using var conn = _dbcontext.Connaction();
        var query="select * from doctors ";
        var res = await conn.QueryAsync<Doctor>(query);
        return res.ToList();
    }

    public async Task<Response<Doctor>> GetByIdAsync(int doctorid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from doctors where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Doctor>(query,new{Id=doctorid});
        return res ==null? new Response<Doctor>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Doctor>(HttpStatusCode.OK,"Ok");
    }

    public async Task<Response<string>> UpdateActiveAsync(int doctorid,bool active)
    {
           using var conn = _dbcontext.Connaction();
       var query="update doctors set isactive=@Isactive WHERE id = @Id";
        var res = await conn.ExecuteAsync(query,new {Isactive=active,Id=doctorid});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }

    public async Task<Response<string>> UpdateAsync(UpdateDoctorDto updateDoctorDto)
    {
         using var conn = _dbcontext.Connaction();
       var query="update doctors set fullname=@Fullname,specialty=@Specialty,birthdate=@Birthdate,isactive=@Isactive WHERE id = @Id";
        var res = await conn.ExecuteAsync(query,updateDoctorDto);
        return res==0? new Response<string>(HttpStatusCode.NotFound,"NotFound") : new Response<string>(HttpStatusCode.OK,"Ok");
    }
}