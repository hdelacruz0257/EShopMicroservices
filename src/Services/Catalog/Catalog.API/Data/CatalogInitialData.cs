using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync()) return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone X",
            Description = "phone",
            ImageFile = "p1.png",
            Price = 950.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Oppo",
            Description = "phone",
            ImageFile = "p2.png",
            Price = 1050.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Samsung",
            Description = "phone",
            ImageFile = "p3.png",
            Price = 950.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "PS5",
            Description = "Console",
            ImageFile = "p4.png",
            Price = 650.00M,
            Category = new List<string>{"Console"}
        }
    };
}
