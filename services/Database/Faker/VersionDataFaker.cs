using Bogus;
using Core.Entities;

namespace Database.Faker
{
    public static class VersionDataFaker
    {
        public static Faker<VersionData> Create()
        {
            return new Faker<VersionData>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Extension, f => f.PickRandom(new string[] { "dll", "bin", "exe", "txt" }));
        }
    }
}
