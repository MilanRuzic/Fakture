using Application;
using Persistence;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddWebApiServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice");
    c.DocExpansion(DocExpansion.None);
    c.EnableFilter();
});

app.UseCors("_myAllowSpecificOrigins");
app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/{controller}/{action}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(
      options => options
          .AllowAnyHeader()
          .WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE")
          .AllowAnyOrigin()
        );


app.Run();
