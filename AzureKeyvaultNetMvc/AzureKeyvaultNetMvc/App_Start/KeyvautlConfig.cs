using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AzureKeyvaultNetMvc.App_Start
{
    public class KeyvautlConfig
    {
        private static readonly KeyVaultClient _keyVaultClient;
        private static readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        string _keyVaultUrl;
        static KeyvautlConfig()
        {
            _azureServiceTokenProvider = new AzureServiceTokenProvider();
            _keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(_azureServiceTokenProvider.KeyVaultTokenCallback));


        }
        public static async Task InitiateAsync()
        {
            string kvurl = @"https://athulakeyvault.vault.azure.net/";
            string tenantId = "3458f5ba-0bbb-46d0-8580-164284a09c2c";
            string clientId = "15507557-07d7-40ae-aae6-9234b1829f29";
            string clientSecret = "hIK8Q~QFIIUDina4n2m6kKbjhzNIS.b6~VlnScL7";

            try
            {
                //var secretClient = new SecretClient(new Uri(kvurl), new DefaultAzureCredential());
                //var cstr = secretClient.GetSecret("ConnectionStrings--SeerStudioEntities");

                var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
                var client = new SecretClient(new Uri(kvurl), credential);
                var str = client.GetSecret("ConnectionStrings--MyConStr");


            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}