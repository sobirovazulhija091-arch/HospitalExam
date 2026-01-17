public class UpdateDoctorDto
{
     public int  Id{get;set;}
     public string Fullname{get;set;}=null!;
     public string Specialty {get;set;}=null!;
     public int Birthdate{get;set;}
     public bool Isactive{get;set;}=true;
   
}