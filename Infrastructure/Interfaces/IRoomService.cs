public interface IRoomService
{
      Task<Response<string>> AddAsync(RoomDto roomDto);
      Task<Response<string>> DeleteAsync(int roomid);
      Task<Response<string>> UpdateActiveAsync(int roomid,bool active);
      Task<Response<Room>>  GetByIdAsync(int roomid);
      Task<List<Room>>  GetAsync();
}