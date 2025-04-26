using FluentValidation;
using FluentValidation.AspNetCore;
using ThriftStore.UserAuthentication.IAM;
using ThriftStore.UserAuthentication.IAM.Data;
using ThriftStore.UserAuthentication.IAM.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.UserAssistServices(builder.Configuration);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserViewModelValidator>();


var app = builder.Build();


DataInitializer.Initialize(app.Services.CreateScope().ServiceProvider);


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
