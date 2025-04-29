using KK.Uno.Server.EF;
using KK.Uno.Server.Extensions;
using KK.Uno.Server.Seeder;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddRepositories();
        builder.Services.AddFactories();
        builder.Services.AddServices();

        var configuration = BuildConfiguration("kkunoconfig.json");

        var isDev = configuration.GetValue<string>("ENV_TYPE") == "Dev";
        var programType = typeof(Program);

        if (isDev)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = programType.Assembly.GetName().Version?.ToString() ?? string.Empty,
                    Title = "Kavvaii Kira Uno Server"
                });
            });
        }

        var migrationAssembly = programType.GetTypeInfo().Assembly.GetName().Name;

        builder.Services.AddDbContext<KKUnoDBContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetValue<string>("SQL_CONNECTION_STRING") ?? throw new ArgumentNullException("DB connection string not found in environment variables!"),
                option =>
                {
                    option.MigrationsAssembly(migrationAssembly);
                    option.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        if (isDev)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger KK.Uno Server API");
            });
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        DBSeeder.Seed(app);

        app.Run();
    }

    private static IConfigurationRoot BuildConfiguration(string configName)
    {
        var configPath = Path.GetFullPath("config");

        var builder = new ConfigurationBuilder()
            .SetBasePath(configPath)
            .AddJsonFile(
                configName,
                optional: false,
                reloadOnChange: false);

        var jsonConfig = builder.Build();
        var inMemmory = new Dictionary<string, string>();

        foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
        {
            var key = environmentVariable.Key.ToString();
            if (jsonConfig.GetValue<string>(key) != null)
            {
                Log.Logger.Warning($"Variable \"{key}\" was declared in both \"{configName}\" and variables.environment: JSON confog value will be used.");
                continue;
            }

            inMemmory.Add(key, environmentVariable.Value.ToString());
        }

        builder.AddInMemoryCollection(inMemmory);

        return builder.Build();
    }
}