public class UpdatePatientDto
{
     public int  Id{get;set;}
     public string Fullname{get;set;}=null!;
     public int Phone{get;set;}
     public int Birthdate{get;set;}
     public bool Isactive{get;set;}=true;
 
}