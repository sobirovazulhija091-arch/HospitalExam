using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService roomService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(RoomDto roomDto)
    {
      return await roomService.AddAsync(roomDto);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int roomid)
    {
        return await roomService.DeleteAsync(roomid);
    }

[HttpGet]
    public async Task<List<Room>> GetAsync()
    {
         return await roomService.GetAsync();
    }

[HttpGet("roomid")]
    public async Task<Response<Room>> GetByIdAsync(int roomid)
    {
        return await roomService.GetByIdAsync(roomid);
    }
    [HttpPatch]
    public async Task<Response<string>> UpdateActiveAsync(int roomid,bool active)
    {  
         return await roomService.UpdateActiveAsync(roomid,active);
    }
}