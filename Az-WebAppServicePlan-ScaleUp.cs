using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.AppService;

namespace WebApp.VerticalScaling.AzureSDK
{
    public static class Az_WebAppServicePlan_List
    {
        [FunctionName("Az-WebAppServicePlan-ScaleUp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                // Authenticate using DefaultAzureCredential
                var armClient = new ArmClient(new DefaultAzureCredential());
                var resourceGroup = ""; //Specify the resource group name
                var appServicePlanName = ""; //Specify the App Service Plan name

                // Get the specified subscription
                SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

                // Get the specific resource group by name
                ResourceGroupResource resourceGroupName = await subscription.GetResourceGroups().GetAsync(resourceGroup);

                // Get the specific App Service plan in the resource group by name
                AppServicePlanCollection appServicePlans = resourceGroupName.GetAppServicePlans();
                AppServicePlanResource appServicePlanResource = await appServicePlans.GetAsync(appServicePlanName);
                
                AppServicePlanData appServicePlanData = appServicePlanResource.Data;

                // Use a switch statement to update the App Service Plan based on its current SKU name
                switch (appServicePlanData.Sku.Name)
                {
                    case "B1":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "B2";
                        appServicePlanData.Sku.Tier = "Basic";
                        appServicePlanData.Sku.Size = "B2";
                        appServicePlanData.Sku.Family = "B";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        ArmOperation<AppServicePlanResource> operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "B2":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "B3";
                        appServicePlanData.Sku.Tier = "Basic";
                        appServicePlanData.Sku.Size = "B3";
                        appServicePlanData.Sku.Family = "B";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "B3":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "S1";
                        appServicePlanData.Sku.Tier = "Standard";
                        appServicePlanData.Sku.Size = "S1";
                        appServicePlanData.Sku.Family = "S";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "S1":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "S2";
                        appServicePlanData.Sku.Tier = "Standard";
                        appServicePlanData.Sku.Size = "S2";
                        appServicePlanData.Sku.Family = "S";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "S2":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "S3";
                        appServicePlanData.Sku.Tier = "Standard";
                        appServicePlanData.Sku.Size = "S3";
                        appServicePlanData.Sku.Family = "S";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "S3":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "P1v2";
                        appServicePlanData.Sku.Tier = "PremiumV2";
                        appServicePlanData.Sku.Size = "P1v2";
                        appServicePlanData.Sku.Family = "Pv2";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "P1v2":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "P2v2";
                        appServicePlanData.Sku.Tier = "PremiumV2";
                        appServicePlanData.Sku.Size = "P2v2";
                        appServicePlanData.Sku.Family = "Pv2";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "P2v2":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "P3v2";
                        appServicePlanData.Sku.Tier = "PremiumV2";
                        appServicePlanData.Sku.Size = "P3v2";
                        appServicePlanData.Sku.Family = "Pv2";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    case "P3v2":
                        // Assign new SKU details
                        appServicePlanData.Sku.Name = "P0v3";
                        appServicePlanData.Sku.Tier = "PremiumV3";
                        appServicePlanData.Sku.Size = "P0v3";
                        appServicePlanData.Sku.Family = "Pv3";
                        appServicePlanData.Sku.Capacity = 1;
                        // Update the service plan
                        operation = await appServicePlans.CreateOrUpdateAsync(Azure.WaitUntil.Completed, appServicePlanName, appServicePlanData);
                        Console.WriteLine($"App Service Plan has been scaled up to: {appServicePlanData.Sku.Name}");
                        break;
                    default:
                        Console.WriteLine($"No update needed.");
                        break;
                }
                
                return new OkObjectResult("OK");
            }
            catch (Exception ex)
            {
                log.LogError($"An error occurred: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}