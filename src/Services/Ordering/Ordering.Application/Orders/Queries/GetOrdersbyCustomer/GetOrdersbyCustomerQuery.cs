namespace Ordering.Application.Orders.Queries.GetOrdersbyCustomer;

public record GetOrdersbyCustomerQuery(Guid CustomerId) : IQuery<GetOrdersbyCustomerResult>;

public record GetOrdersbyCustomerResult(IEnumerable<OrderDto> Orders);
