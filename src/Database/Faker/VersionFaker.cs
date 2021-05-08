using Bogus;
using Core.Entities;
using System.Collections.Generic;

namespace Database.Faker
{
    public static class VersionFaker
    {
        public static Faker<Core.Entities.Version> Create(ICollection<Kind> kinds, ICollection<Component> components, ICollection<VersionData> versionsData)
        {
            return new Faker<Core.Entities.Version>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.KindId, f => f.PickRandom(kinds).Id)
                .RuleFor(x => x.ComponentId, f => f.PickRandom(components).Id)
                .RuleFor(x => x.VersionDataId, f => f.PickRandom(versionsData).Id)
                .RuleFor(x => x.Name, f => f.Name.FirstName());
        }
    }
}
