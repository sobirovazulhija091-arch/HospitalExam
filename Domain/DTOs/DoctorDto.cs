public class DoctorDto
{
     public string Fullname{get;set;}=null!;
     public string Specialty {get;set;}=null!;
     public DateTime Hiredat{get;set;}=DateTime.UtcNow;
     public bool Isactive{get;set;}=true;
}