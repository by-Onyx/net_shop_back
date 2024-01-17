using System.Reflection;
using System.Text;
using net_shop_back.API.Middlewares;
using net_shop_back.Data;
using net_shop_back.Handlers.GroupHandlers;
using net_shop_back.Mappers;
using net_shop_back.Services.DI;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace net_shop_back.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            this._config = config;
            this._env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            /*var connStr = _config.GetConnectionString("MySQL")
                          ?? throw new InvalidOperationException("Connection string not found");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySql(connStr));*/
            
            services.AddDbContext<ApplicationContext>();
            services.AddDefaultServices();
            services.AddCors();
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining<GetAllGroupsHandler>();
            });
            services.AddAutoMapper(options =>
            {
                options.AddMaps(typeof(ShopMapper));
            });
            services.AddErrorHandling();
            services.AddHttpClient();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                });
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        /*ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = _config["JWT:ValidAudience"],
                        ValidIssuer = _config["JWT:ValidIssuer"],*/
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"] ?? string.Empty))
                    };
                });
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app)
        {
            MigrateDatabase(app.ApplicationServices);

            app.UseHttpLogging();
            
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseErrorHandling();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });
        }

        private static void MigrateDatabase(IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            // ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }
}
