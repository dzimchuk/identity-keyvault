using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace KeyVaultTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();
                    var keyVaultName = builtConfig["KeyVaultName"];

                    if (!string.IsNullOrWhiteSpace(keyVaultName))
                    {
                        var userAssignedClientId = builtConfig["UserAssignedClientId"];

                        var credentials = string.IsNullOrWhiteSpace(userAssignedClientId)
                            ? new DefaultAzureCredential()
                            : new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });

                        config.AddAzureKeyVault(new Uri($"https://{keyVaultName}.vault.azure.net/"), credentials); 
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
