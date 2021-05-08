using Bogus;
using Core.Entities;
using Core.Entities.Enums;

namespace Database.Faker
{
    public static class AddressFaker
    {
        public static Faker<Address> Create()
        {
            return new Faker<Address>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.AddressType, f => f.Random.Enum<AddressType>())
                .RuleFor(x => x.Label, f => f.Internet.Mac())
                .RuleFor(x => x.IsConfirmed, f => f.Random.Bool());
        }
    }
}
