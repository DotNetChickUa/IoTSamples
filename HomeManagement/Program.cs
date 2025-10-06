using HomeManagement;
using HomeManagement.Components;
using LiveStreamingServerNet;
using LiveStreamingServerNet.AdminPanelUI;
using LiveStreamingServerNet.Flv.Installer;
using LiveStreamingServerNet.Standalone;
using LiveStreamingServerNet.Standalone.Installer;
using LiveStreamingServerNet.StreamProcessor.AspNetCore.Installer;
using LiveStreamingServerNet.StreamProcessor.Installer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using System.Net;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<HomeManagementDbContext>(options => options.UseSqlite("Data Source=home_management.db"));
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<StaticAuthOptions>(builder.Configuration.GetSection("Auth"));

// Cookie authentication only (no Identity)
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath = "/Account/Login";
        o.LogoutPath = "/Account/Logout";
        o.AccessDeniedPath = "/Account/Login";
        o.SlidingExpiration = true;
        o.ExpireTimeSpan = TimeSpan.FromHours(12);
    });

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddLiveStreamingServer(
    new IPEndPoint(IPAddress.Any, 1935),
<<<<<<< HEAD
    options => options.AddStandaloneServices().AddFlv()
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
<<<<<<< HEAD
<<<<<<< HEAD
    options => options.AddStandaloneServices().AddFlv()
=======
    options => options
    .AddAuthorizationHandler<StreamAuthorizationHandler>()
=======
    options => options
    .AddAuthorizationHandler<DemoAuthorizationHandler>()
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
<<<<<<< HEAD
=======
    options => options
    .AddAuthorizationHandler<StreamAuthorizationHandler>()
>>>>>>> 0de0591 (Get Status, Update to .NET 10)
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
    .AddStandaloneServices()
    .AddFlv()
    .AddStreamProcessor()
    .AddHlsTransmuxer()
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
=======
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
>>>>>>> 3d0106c (Add Dashboard, Add Auth)
<<<<<<< HEAD
=======
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
>>>>>>> 0de0591 (Get Status, Update to .NET 10)
>>>>>>> d4eca16 (Get Status, Update to .NET 10)
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<HomeManagementDbContext>>();
    await using var dbContext = await dbContextFactory.CreateDbContextAsync();
    await dbContext.Database.MigrateAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.UseWhen(c => c.Request.Path.StartsWithSegments("/ip-cameras"), branch =>
{
    branch.Use(async (ctx, next) =>
    {
        if (!(ctx.User.Identity?.IsAuthenticated ?? false))
        {
            var returnUrl = Uri.EscapeDataString(ctx.Request.Path + ctx.Request.QueryString);
            ctx.Response.Redirect($"/Account/Login?returnUrl={returnUrl}");
            return;
        }
        await next();
    });
});

app.UseHttpFlv();
app.UseHlsFiles();
app.MapStandaloneServerApiEndPoints();
app.UseAdminPanelUI(new AdminPanelUIOptions
{
    BasePath = "/ip-cameras",
    HasHttpFlvPreview = true,
    HasHlsPreview = true,
    HttpFlvUriPattern = "{streamPath}.flv",
    HlsUriPattern = "{streamPath}/output.m3u8"
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

<<<<<<< HEAD
app.Run();
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3d0106c (Add Dashboard, Add Auth)
=======
>>>>>>> 0de0591 (Get Status, Update to .NET 10)
>>>>>>> d4eca16 (Get Status, Update to .NET 10)
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 3d0106c (Add Dashboard, Add Auth)
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
>>>>>>> 0e1ba11 (Add Dashboard, Add Auth)
app.Run();
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
=======
>>>>>>> 5be7bab (Add Dashboard, Add Auth)
=======
=======
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
>>>>>>> a123fff (Add Dashboard, Add Auth)
>>>>>>> 3d0106c (Add Dashboard, Add Auth)
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 0de0591 (Get Status, Update to .NET 10)
>>>>>>> d4eca16 (Get Status, Update to .NET 10)
=======
<<<<<<< HEAD
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
>>>>>>> 0e1ba11 (Add Dashboard, Add Auth)
app.MapPost("api/account/login", async (
    HttpContext context,
    IOptions<StaticAuthOptions> authOptions,
    [FromForm] string username,
    [FromForm] string key,
    [FromForm] bool remember,
    [FromForm] string? returnUrl) =>
{
    var cfg = authOptions.Value;
    if (key == cfg.Key)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, username)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var props = new AuthenticationProperties
        {
            IsPersistent = remember == true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
        };
        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

        var target = NormalizeReturnUrl(returnUrl);
        return Results.Redirect(target);
    }

    var redirect = "/Account/Login?error=1" + (string.IsNullOrWhiteSpace(returnUrl) ? "" : $"&returnUrl={Uri.EscapeDataString(returnUrl)}");
    return Results.Redirect(redirect);

    static string NormalizeReturnUrl(string? ru)
    {
<<<<<<< HEAD
        if (string.IsNullOrWhiteSpace(ru))
        {
            return "/";
        }

        if (Uri.TryCreate(ru, UriKind.Relative, out _))
        {
            return ru;
        }

=======
        if (string.IsNullOrWhiteSpace(ru)) return "/";
        if (Uri.TryCreate(ru, UriKind.Relative, out _)) return ru;
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
        return "/";
    }
});

app.MapPost("api/account/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync();
    return Results.Redirect("/");
});

<<<<<<< HEAD
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
=======
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
await app.RunAsync();
>>>>>>> 109a8f2 (Get Status, Update to .NET 10)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
await app.RunAsync();
>>>>>>> eeff7ac (Refactor and enhance device management system)
>>>>>>> 83b53c6 (Refactor and enhance device management system)
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 0df645d (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
