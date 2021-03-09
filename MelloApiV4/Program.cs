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
            /*              .ConfigureAppConfiguration((context, config) =>
                          {
                              config.AddAzureKeyVault(new AzureKeyVaultConfigurationOptions
                              {
                                  Vault = "https://melloapi-keyvault.vault.azure.net/",
                                  Client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(new AzureServiceTokenProvider().KeyVaultTokenCallback)),
                              });
                          })*/
            /* .ConfigureAppConfiguration((context, config) =>
             {
                 KeyVaultClient keyVaultClient;
                 var accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

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

                 config.AddAzureKeyVault(
                                     "https://melloapi-keyvault.vault.azure.net/",
                                     keyVaultClient,
                                     new DefaultKeyVaultSecretManager());

             })*/

            /*      .ConfigureAppConfiguration((context, config) =>
                  {


                      var clientId = "37620a8a-4dfd-4363-9a87-05dfcb30cb39"; // Environment.GetEnvironmentVariable("");// stageOneConfig.GetValue<string>("clientid");
                      var clientSecret = ""; //Environment.GetEnvironmentVariable(""); //stageOneConfig.GetValue<string>("clientsecret");
                      var keyVaultIdentifier = Environment.GetEnvironmentVariable("keyvaultidentifier");  //stageOneConfig.GetValue<string>("keyvaultidentifier");
                      var keyVaultUri = $"https://melloapi-keyvault.vault.azure.net/";
                      config.AddAzureKeyVault(keyVaultUri, clientId, clientSecret);
                  })*/


                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
