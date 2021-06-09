using System;
using System.Threading.Tasks;
using Core.Entities;
using InfrastructureEF.Data.Extensions;
using Microsoft.Extensions.Logging;
using Version = Core.Entities.Version;

namespace InfrastructureEF.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory logger)
        {
            try
            {
                await context.DeserializeJson<Kind>("kinds");
                await context.DeserializeJson<Category>("categories");
                await context.DeserializeJson<Address>("addresses");
                await context.DeserializeJson<Component>("components");
                await context.DeserializeJson<VersionData>("versionsData");
                await context.DeserializeJson<Version>("versions");
                await context.DeserializeJson<Device>("devices");
            }
            catch (Exception ex)
            {
                logger.CreateLogger<StoreContextSeed>().LogError(ex.Message);
            }
        }
    }
}