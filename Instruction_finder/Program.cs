using Instruction_finder.Components;
using IF.UseCase.PlugInInterfaces;
using IF.UseCase.Interfaces;
using IF.Plugins.InMemory;
using IF.UseCase;

var builder = WebApplication.CreateBuilder(args);

// Instruction connection
builder.Services.AddTransient<IInstructionRepository, InstructionRepository>();
builder.Services.AddTransient<IFindInstructionUseCase, FindInstructionUseCase>();
builder.Services.AddTransient<ICheckIfInstructionExistUseCase, CheckIfInstructionExistUseCase>();
builder.Services.AddTransient<ICollectInstructionsUseCase, CollectInstructionsUseCase>();


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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
