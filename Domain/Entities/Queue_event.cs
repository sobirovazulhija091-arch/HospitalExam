public class Queue_event
{
   public int  Id{get;set;}
public int AppointmentId{get;set;}
public string Eventtype{get;set;}=null!;
public DateTime Createdat{get;set;}=DateTime.UtcNow;
}