using Bogus;
using Core.Entities;
using Database.StaticData;
using System.Collections.Generic;

namespace Database.Faker
{
    public static class ComponentFaker
    {
        public static Faker<Component> Create(ICollection<Category> categories)
        {
            return new Faker<Component>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Created, f => f.Date.Soon())
                .RuleFor(x => x.CreatedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Modified, f => f.Date.Soon())
                .RuleFor(x => x.ModifiedBy, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Icon, f => f.PickRandom(Icons.FontAwesome))
                .RuleFor(x => x.CategoryId, f => f.PickRandom(categories).Id);
        }
    }
}
