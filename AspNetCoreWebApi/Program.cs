var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            // builder.WithOrigins(
            //         "http://aspnetcorewebapi.onrender.com/",
            //         "https://aspnetcorewebapi.onrender.com/",
            //         "http://blazorwasmsample.onrender.com/",
            //         "https://blazorwasmsample.onrender.com/")
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Do DEV-only stuff
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
