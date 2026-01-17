public class Patient
{
     public int  Id{get;set;}
     public string Fullname{get;set;}=null!;
     public int Phone{get;set;}
     public int Birthdate{get;set;}
     public bool Isactive{get;set;}=true;
   public DateTime Createdat{get;set;}= DateTime.UtcNow;
}