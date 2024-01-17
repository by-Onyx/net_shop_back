using net_shop_back.API;
using Serilog;

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseUrls("http://+:12344");
        webBuilder.UseStartup<Startup>();
    })
    .Build()
    .Run();