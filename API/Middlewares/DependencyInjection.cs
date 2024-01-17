namespace net_shop_back.API.Middlewares
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            return services.AddScoped<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
