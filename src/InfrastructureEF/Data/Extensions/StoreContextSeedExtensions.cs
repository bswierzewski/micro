using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureEF.Data.Extensions
{
    public static class StoreContextSeedExtensions
    {
        private const string path = "../../Mocks";
        public static async Task DeserializeJson<T>(this StoreContext context, string fileName) where T : class
        {
            var set = context.Set<T>();

            if (!set.Any())
            {
                var json = File.ReadAllText(Path.Combine(path, $"{fileName}.json"));

                var items = JsonSerializer.Deserialize<T[]>(json, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await set.AddRangeAsync(items);

                await context.SaveChangesAsync();
            }
        }
    }
}