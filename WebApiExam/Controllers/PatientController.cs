using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(PatientDto patientDto)
    {
         return await patientService.AddAsync(patientDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int patientid)
    {
         return await patientService.DeleteAsync(patientid);
    }
    [HttpGet]
    public async Task<List<Patient>> GetAsync()
    {
        return await patientService.GetAsync();
    }
    [HttpGet("patientid")]
    public async Task<Response<Patient>> GetByIdAsync(int patientid)
    {
       return await patientService.GetByIdAsync(patientid);
    }
    [HttpPatch]
    public async Task<Response<string>> UpdateActiveAsync(int patientid,bool active)
    {
         return await patientService.UpdateActiveAsync(patientid,active);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(UpdatePatientDto updatePatientDto)
    {
        return await patientService.UpdateAsync(updatePatientDto);
    }
    
}