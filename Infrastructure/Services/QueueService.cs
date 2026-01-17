using Npgsql;
using Dapper;
public class QueueService(ApplicationDbcontext dbcontext):IQueueService
{
    private readonly ApplicationDbcontext _dbcontext=dbcontext;

    public async Task<List<Queue_event>> GetAsync()
    {
         using var conn = _dbcontext.Connaction();
        var query="select a.* from queue_events q join appointments a on a.id=q.appointmentid ";
        var res = await conn.QueryAsync<Queue_event>(query);
        return res.ToList();
    }
}