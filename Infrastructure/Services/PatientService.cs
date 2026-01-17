using System.Net;
using Dapper;
public class PatientService(ApplicationDbcontext dbcontext ):IPatientService
{
    private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<Response<string>> AddAsync(PatientDto patientDto)
    {
        using var conn =_dbcontext.Connaction();
        var query="insert into patients (fullname,phone,birthdate,isactive) values(@fullname,@phone,@birthdate,@isactive)";
       var res = await conn.ExecuteAsync(query , new{fullname=patientDto.Fullname,phone=patientDto.Phone,birthdate=patientDto.Birthdate,isactive=patientDto.Isactive});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
        :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> DeleteAsync(int patientid)
    {
          using var conn = _dbcontext.Connaction();
        var query="delete from patients where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=patientid});
         return res == 0 ? new Response<string>(HttpStatusCode.NotFound,"NotFound")
             :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<List<Patient>> GetAsync()
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from patients ";
        var res = await conn.QueryAsync<Patient>(query);
        return res.ToList();
    }
    public async Task<Response<Patient>> GetByIdAsync(int patientid)
    {
         using var conn = _dbcontext.Connaction();
        var query="select * from patients where id=@Id";
        var res = await conn.QueryFirstOrDefaultAsync<Patient>(query,new{Id=patientid});
        return res ==null? new Response<Patient>(HttpStatusCode.NotFound,"NotFound")
        :new Response<Patient>(HttpStatusCode.OK,"Ok",res);
    }
    public async Task<Response<string>> UpdateActiveAsync(int patientid,bool active)
    {
          using var conn =_dbcontext.Connaction();
        var query="update patients set isactive=@Isactive where id=@Id";
       var res = await conn.ExecuteAsync(query,new {Isactive=active,Id=patientid});
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
        :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
    public async Task<Response<string>> UpdateAsync(UpdatePatientDto updatePatientDto)
    {
         using var conn =_dbcontext.Connaction();
        var query="update patients set fullname=@Fullname,phone=@Phone,birthdate=@Birthdate,isactive=@Isactive where id=@Id";
       var res = await conn.ExecuteAsync(query,updatePatientDto);
        return res == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Error")
        :  new Response<string>(HttpStatusCode.OK,"Ok");
    }
}
