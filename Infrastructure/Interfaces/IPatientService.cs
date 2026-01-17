public interface IPatientService
{
      Task<Response<string>> AddAsync(PatientDto patientDto);
      Task<Response<string>> DeleteAsync(int patientid);
      Task<Response<string>> UpdateAsync(UpdatePatientDto updatePatientDto);
      Task<Response<string>> UpdateActiveAsync(int patientid,bool active);
      Task<Response<Patient>>  GetByIdAsync(int patientid);
      Task<List<Patient>>  GetAsync();
}