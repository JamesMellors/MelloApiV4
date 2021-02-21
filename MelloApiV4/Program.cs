using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MelloApiV4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            /*  .ConfigureAppConfiguration((context, config) =>
              {
                  config.AddAzureKeyVault(new AzureKeyVaultConfigurationOptions
                  {
                      Vault = "https://melloapi-keyvault.vault.azure.net/",
                      Client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(new AzureServiceTokenProvider().KeyVaultTokenCallback)),
                  });
              })*/
            /*.ConfigureAppConfiguration((context, config) =>
            {
                        KeyVaultClient keyVaultClient;
            var accessToken = //Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            if (accessToken != null)
            {
                keyVaultClient = new KeyVaultClient(
                    async (string a, string r, string s) => accessToken);
            }
            else
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                keyVaultClient = new KeyVaultClient(
                   new KeyVaultClient.AuthenticationCallback(
                       azureServiceTokenProvider.KeyVaultTokenCallback));
            }

            config.AddAzureKeyVault(new AzureKeyVaultConfigurationOptions
            {
                Vault = "https://melloapi-keyvault.vault.azure.net/",
                Client = keyVaultClient,
            });
                
            })*/
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
