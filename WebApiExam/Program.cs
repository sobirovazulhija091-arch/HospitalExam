var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IAppointmentService,AppointmentService>();
builder.Services.AddScoped<ApplicationDbcontext>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddScoped<IRoomService,RoomService>();
builder.Services.AddScoped<IScheduleSlotService,ScheduleSlotService>();
builder.Services.AddScoped<IQueueService,QueueService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(cofig=>{cofig.AddConsole();});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwaggerUI();
   app.UseSwagger();
}
app.UseMiddleware<RequestTimeMiddleware>();
app.MapOpenApi();
app.MapControllers();
app.Run();
