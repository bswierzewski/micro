using Bogus;
using Core.Entities;
using Database.StaticData;
using System.Collections.Generic;

namespace Database.Faker
{
    public static class DeviceFaker
    {
        public static Faker<Device> Create(ICollection<Kind> kinds, ICollection<Component> components, ICollection<Address> addresses, ICollection<Version> versions)
        {
            return new Faker<Device>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.ComponentId, f => f.PickRandom(components).Id)
                .RuleFor(x => x.KindId, f => f.PickRandom(kinds).Id)
                .RuleFor(x => x.AddressId, f => f.PickRandom(addresses).Id)
                .RuleFor(x => x.VersionId, f => f.PickRandom(versions).Id)
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Icon, f => f.PickRandom(Icons.FontAwesome));
        }
    }
}
