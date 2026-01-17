public class Appointment
{
    public int Id{get;set;}
    public int PatientId{get;set;}
    public int Slotid{get;set;}
    public Base Status{get;set;}
    public DateTime Createdat{get;set;}=DateTime.UtcNow;
    public DateTime Updatedat{get;set;}
}