using BirdingJournal.Models;
using BirdingJournal.DAL;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public static class Program
{
    public static void Main(string[] args)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = ValidateServerCertificate;

        var client = new HttpClient(handler);

        // Use the HttpClient instance to make HTTP requests
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<BirdingJournalDbContext>(opts => {opts.UseSqlServer(builder.Configuration["ConnectionStrings:BirdingJournalConnection"]);
        });

        builder.Services.AddScoped<IBirdingJournalRepository, EFBirdingJournalRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }

    private static bool ValidateServerCertificate(HttpRequestMessage requestMessage, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Always accept the SSL/TLS certificate, even if it is invalid or self-signed
        return true;
    }
}

