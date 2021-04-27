using Bogus;
using Core.Entities;
using Database.StaticData;

namespace Database.Faker
{
    public static class KindFaker
    {
        public static Faker<Kind> Create()
        {
            return new Faker<Kind>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Icon, f => f.PickRandom(Icons.FontAwesome));
        }
    }
}
