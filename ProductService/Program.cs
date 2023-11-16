using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOcelot(builder.Configuration);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder
//            .WithOrigins("https://meego.vn")
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials());
//});
var app = builder.Build();


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapGet("/product", async context =>
//    {
//        await context.Response.WriteAsync("Product Service");
//    });
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapGet("/api/product", () => "Hello World!, I'm Product");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//app.UseCors("CorsPolicy");
//app.UseOcelot().Wait();
app.Run();
