public class Appointment
{
    public int Id{get;set;}
    public int PatientId{get;set;}
    public int SlotId{get;set;}
    public string Status{get;set;}=null!;
    public DateTime Createdat{get;set;}=DateTime.UtcNow;
    public DateTime Updatedat{get;set;}
}