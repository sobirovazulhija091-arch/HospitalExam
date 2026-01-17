public class Schedule_slot
{
       public int  Id{get;set;}
       public int  RoomId{get;set;}
       public int  DoctorId{get;set;}
     public bool Isactive{get;set;}=true;
    public DateTime StartTime {get;set;}=DateTime.UtcNow;
    public DateTime  EndTime {get;set;}
}