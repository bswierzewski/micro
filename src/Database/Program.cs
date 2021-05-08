using Database.Faker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Database
{
    public static class Program
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

            categories.SaveToFile(nameof(categories));
            components.SaveToFile(nameof(components));
            addresses.SaveToFile(nameof(addresses));
            kinds.SaveToFile(nameof(kinds));
            versionsData.SaveToFile(nameof(versionsData));
            versions.SaveToFile(nameof(versions));
            devices.SaveToFile(nameof(devices));

            var json = CreateJson(new
            {
                addresses,
                categories,
                components,
                devices,
                kinds,
                versions,
                versionsData
            });

            SaveToFile(GetPath("db.json"), json);
        }
        private static string GetPath(string fileName)
        {
            var currentDirectory = Environment.CurrentDirectory;

            int endIndex = currentDirectory.IndexOf("Services");

            return Path.Join(currentDirectory.Substring(0, endIndex), "Mocks", fileName);
        }

        private static void SaveToFile<T>(this List<T> collections, string name)
        {
            var json = CreateJson(collections);

            SaveToFile(GetPath($"{name}.json"), json);
        }

        private static string CreateJson(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        private static void SaveToFile(string path, string json)
        {
            File.WriteAllText(path, json);
        }
    }
}
