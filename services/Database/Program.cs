using System;
using System.Linq;
using Bogus;
using Core.Entities;
using Database.StaticData;
using Infrastructure.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Database
{
    class Program
    {
        public static string JsonPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static void Main(string[] args)
        {
            var componentFaker = new Faker<Component>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Icon, f => f.PickRandom(Icons.FontAwesome));

            var components = componentFaker.Generate(20);

            var categoryFaker = new Faker<Category>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Icon, f => f.PickRandom(Icons.FontAwesome))
                .RuleFor(x => x.Components, f => f.Random.ListItems<Component>(components));

            var categories = categoryFaker.Generate(10);

            var json = JsonConvert.SerializeObject(new
            {
                categories,
                components,
            }, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            foreach (var item in categories)
            {
                Console.WriteLine(item.Components.Count);
            }

            //File.WriteAllText(Path.Join(JsonPath, "db.json"), json);

            // Console.WriteLine(json);

            using (var db = new StoreContext())
            {
                db.Components.AddRange(components);

                db.SaveChanges();

                db.Categories.AddRange(categories);

                db.SaveChanges();
            }
        }
    }
}
