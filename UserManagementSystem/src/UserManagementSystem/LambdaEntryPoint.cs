using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserManagementSystem
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IHostBuilder builder)
        {
            builder
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>();
                });
        }
    }
}
