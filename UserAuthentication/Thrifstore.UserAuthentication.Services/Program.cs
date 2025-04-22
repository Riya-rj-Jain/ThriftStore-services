using ThriftStore.UserAuthentication.IAM;
using ThriftStore.UserAuthentication.IAM.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.UserAssistServices(builder.Configuration);

var app = builder.Build();


DataInitializer.Initialize(app.Services.CreateScope().ServiceProvider);


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
