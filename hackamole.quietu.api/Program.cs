using Hackamole.Quietu.SharedKernel;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain;
using hackamole.quietu.api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddJwtOptions();
        builder.AddConnectionStringOptions();
        builder.AddBusProviderOptions();
        builder.Services.AddJwtManager();
        builder.Services.AddAuthenticatedPrincipalProvider();

        builder.Services.AddRepositories();
        builder.Services.AddQueries();
        builder.Services.AddDatabase();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCommands();
        builder.Services.AddCommandsAndEventsManagers();

        builder.Services.AddAndConfigureSwagger();

        builder.Services.AddAndConfigureKafka();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseQuietuCORS();

        app.MapControllers();

        app.UseQuietuMiddlewares();

        app.InitializeDb();

        app.Run();
    }

}