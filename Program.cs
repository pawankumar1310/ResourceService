


//using DBService;
//using Service;
//using Structure;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
//builder.Services.AddScoped<IFileStorage,FileStorageDB>();
//builder.Services.AddScoped<SaveFileService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
