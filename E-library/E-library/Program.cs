using E_library.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options =>
{
    options.AddPolicy( "AllowFrontend", policy =>
    {
        policy.WithOrigins( "http://localhost:3000" )
              .AllowAnyHeader()
              .AllowAnyMethod();
    } );
} );

builder.Services.AddDbContext<LibraryContext>( options =>
    options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors( "AllowFrontend" );

app.UseAuthorization();

app.MapControllers();

app.Run();
