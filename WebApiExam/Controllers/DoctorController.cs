using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(DoctorDto doctorDto)
    {
        return await doctorService.AddAsync(doctorDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int doctorid)
    {
       return await doctorService.DeleteAsync(doctorid);
    }
[HttpGet]
    public async Task<List<Doctor>> GetAsync()
    {
        return await doctorService.GetAsync();
    }
 [HttpGet("{doctorid}")]
    public async Task<Response<Doctor>> GetByIdAsync(int doctorid)
    {
        return await doctorService.GetByIdAsync(doctorid);
    }
[HttpPatch("{doctorid}/active")]
    public async Task<Response<string>> UpdateActiveAsync(int doctorid,bool active)
    {
        return await doctorService.UpdateActiveAsync(doctorid,active);
    }
 [HttpPut("doctorid")]
    public async Task<Response<string>> UpdateAsync(UpdateDoctorDto updateDoctorDto)
    {
       return await doctorService.UpdateAsync(updateDoctorDto);
    }
    
}