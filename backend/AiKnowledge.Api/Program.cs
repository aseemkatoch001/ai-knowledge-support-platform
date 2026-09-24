using AiKnowledge.Api.Features.Documents.Upload;
using AiKnowledge.Application.Common.Storage;
using AiKnowledge.Application.Documents.Upload;
using AiKnowledge.Infrastructure.Persistence.Configurations;
using AiKnowledge.Infrastructure.Repository.Documents;
using AiKnowledge.Infrastructure.Storage.AiKnowledge.Application.Common.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//database connection

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), npgsqlOptions => npgsqlOptions.UseVector()));
//Services
builder.Services.AddScoped<IFileStorage, LocalFileStorage>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IUploadDocumentHandler,UploadDocumentHandler>();

// API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Https redirection
app.UseHttpsRedirection();

// CORS
app.UseCors("Frontend");

// -----------------------------------------
// Endpoints
// -----------------------------------------

app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    timestamp = DateTime.UtcNow
}));

app.MapUploadDocumentEndpoint();

app.Run();


