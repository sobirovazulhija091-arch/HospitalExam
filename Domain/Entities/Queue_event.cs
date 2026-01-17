public class Queue_event
{
   public int  Id{get;set;}
public int AppointmentId{get;set;}
public Base Eventtype{get;set;}
public DateTime Createdat{get;set;}=DateTime.UtcNow;
}