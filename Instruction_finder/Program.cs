using Instruction_finder.Components;
using IF.UseCase.PlugInInterfaces;
using IF.UseCase.Interfaces;
using IF.Plugins.InMemory;
using IF.UseCase;
using Microsoft.EntityFrameworkCore;
using IF.Plugins.EFCoreSqlServer;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsEnvironment("Testing"))
{
    builder.WebHost.UseStaticWebAssets();

    // Instruction connection
    builder.Services.AddTransient<IInstructionRepository, InstructionRepository>();
    builder.Services.AddTransient<ICheckIfInstructionExistUseCase, CheckIfInstructionExistUseCase>();
    builder.Services.AddTransient<ICollectInstructionsUseCase, CollectInstructionsUseCase>();

}
else
{
    // Instruction connection
    builder.Services.AddDbContext<IFContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("InstructionMenagement")));
    builder.Services.AddTransient<IInstructionRepository, EfInstructionRepository>();
    builder.Services.AddTransient<ICheckIfInstructionExistUseCase, CheckIfInstructionExistUseCase>();
    builder.Services.AddTransient<ICollectInstructionsUseCase, CollectInstructionsUseCase>();
}



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapGet("/pdf", (HttpContext httpContext, IWebHostEnvironment environment) =>
{
    var requestedPath = httpContext.Request.Query["path"].ToString().Trim().Trim('"', '\'');
    if (string.IsNullOrWhiteSpace(requestedPath))
    {
        return Results.BadRequest("Brak ścieżki PDF.");
    }

    var filePath = Path.IsPathFullyQualified(requestedPath)
        ? requestedPath
        : Path.Combine(environment.WebRootPath, requestedPath.TrimStart('~', '/', '\\'));

    if (!File.Exists(filePath) || !string.Equals(Path.GetExtension(filePath), ".pdf", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Nie znaleziono pliku PDF: {filePath}");
        return Results.NotFound();
    }

    Console.WriteLine($"Serwowanie pliku PDF: {filePath}");
    return Results.File(filePath, "application/pdf", enableRangeProcessing: true);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
