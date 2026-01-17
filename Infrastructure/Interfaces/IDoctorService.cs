public interface IDoctorService
{
      Task<Response<string>> AddAsync(DoctorDto doctorDto);
      Task<Response<string>> DeleteAsync(int doctorid);
      Task<Response<string>> UpdateAsync(UpdateDoctorDto updateDoctorDto);
      Task<Response<string>> UpdateActiveAsync(int doctorid,bool active);
      Task<Response<Doctor>>  GetByIdAsync(int doctorid);
      Task<List<Doctor>>  GetAsync();
}