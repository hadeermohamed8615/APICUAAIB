namespace APICUAAIB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", corsOptionsBuilder =>
                {
                  //  corsOptionsBuilder.WithOrigins("127.0.0.1:12346", "fghjkl");
                    corsOptionsBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
                //corsOptions.AddPolicy("MyPolicyV02", corsOptionsBuilder =>
                //{
                //    corsOptionsBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                //});
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //   app.UseAuthorization();
            app.UseCors("MyPolicy");

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}