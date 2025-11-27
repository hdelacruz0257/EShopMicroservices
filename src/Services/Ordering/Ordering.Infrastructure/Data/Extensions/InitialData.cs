namespace Ordering.Infrastructure.Data.Extensions;

internal static class InitializeData
{
    public static IEnumerable<Customer> Customers => new List<Customer>()
    {
        Customer.Create(CustomerId.Of(new Guid("4537d7b6-2a8a-4a19-adc4-790144b860b9")), "testptp", "testptp@testemail.com"),
        Customer.Create(CustomerId.Of(new Guid("604982d4-e25d-44dd-9c1b-ba7082236ede")), "testptp2", "testptp2@testemail.com")
    };

    public static IEnumerable<Product> Products => new List<Product>()
    {
        Product.Create(ProductId.Of(new Guid("bb599c16-2cd0-4bcb-9583-d65d59cbd29b")), "IPhone X", 950),
        Product.Create(ProductId.Of(new Guid("88ccea8e-763e-403e-a8db-701f5c0fe519")), "Oppo", 1050),
        Product.Create(ProductId.Of(new Guid("9ed2225b-c325-4c25-b4d1-86f847b19c12")), "Samsung", 950),
        Product.Create(ProductId.Of(new Guid("18788016-adfb-45cb-b94e-0465d67e59f3")), "PS5", 650)
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("test", "testName", "test@testmail.com", "123 Test Address Line1", "PH", "MM", "1902");
            var address2 = Address.Of("test2", "testName2", "test2@testmail.com", "1234 Test Address Line1", "PH", "MM", "1902");

            var payment1 = Payment.Of("test", "1234567890", "01/30", "123", 1);
            var payment2 = Payment.Of("test2", "0987654321", "02/30", "124", 1);

            var order1 = Order.Create(OrderId.Of(Guid.NewGuid()),
                                      CustomerId.Of(new Guid("4537d7b6-2a8a-4a19-adc4-790144b860b9")),
                                      OrderName.Of("ORD_1"),
                                      shippingAddress: address1,
                                      billingAddress: address2,
                                      payment1);
            order1.Add(ProductId.Of(new Guid("bb599c16-2cd0-4bcb-9583-d65d59cbd29b")), 1, 950);
            order1.Add(ProductId.Of(new Guid("88ccea8e-763e-403e-a8db-701f5c0fe519")), 1, 1050);

            var order2= Order.Create(OrderId.Of(Guid.NewGuid()),
                                      CustomerId.Of(new Guid("604982d4-e25d-44dd-9c1b-ba7082236ede")),
                                      OrderName.Of("ORD_2"),
                                      shippingAddress: address1,
                                      billingAddress: address2,
                                      payment1);
            order2.Add(ProductId.Of(new Guid("9ed2225b-c325-4c25-b4d1-86f847b19c12")), 1, 950);
            order2.Add(ProductId.Of(new Guid("18788016-adfb-45cb-b94e-0465d67e59f3")), 1, 650);

            return new List<Order>() { order1, order2 };
        }
    }

}
