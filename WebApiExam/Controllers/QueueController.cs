using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class QueueController(IQueueService queueService):ControllerBase
{
    [HttpGet]
      public async Task<List<Queue_event>> GetAsync()
    {
     return await    queueService.GetAsync();
    }
}