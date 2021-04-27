using Database.Faker;
using Infrastructure.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = CategoryFaker
                .Create()
                .Generate(10);

            var components = ComponentFaker
                .Create(categories)
                .Generate(20);

            var addresses = AddressFaker
                .Create()
                .Generate(10);

            var kinds = KindFaker
                .Create()
                .Generate(10);

            var versionsData = VersionDataFaker
                .Create()
                .Generate(10);

            var versions = VersionFaker
                .Create(kinds, components, versionsData)
                .Generate(10);

            var devices = DeviceFaker
                .Create(kinds, components, addresses, versions)
                .Generate(10);

            var json = JsonConvert.SerializeObject(new
            {
                addresses,
                categories,
                components,
                devices,
                kinds,
                versions,
                versionsData
            }, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            SaveToFile(json);

            using (var db = new StoreContext())
            {
                db.Database.EnsureDeleted();

                db.Database.EnsureCreated();

                db.Addresses.AddRange(addresses);

                db.Categories.AddRange(categories);

                db.Components.AddRange(components);

                db.Devices.AddRange(devices);

                db.Kinds.AddRange(kinds);

                db.Versions.AddRange(versions);

                db.VersionsData.AddRange(versionsData);

                db.SaveChanges();
            }
        }

        private static void SaveToFile(string json)
        {
            var currentDirectory = Environment.CurrentDirectory;

            int endIndex = currentDirectory.IndexOf("Services");

            var path = Path.Join(currentDirectory.Substring(0, endIndex), "Mocks", "db.json");

            File.WriteAllText(path, json);
        }
    }
}
