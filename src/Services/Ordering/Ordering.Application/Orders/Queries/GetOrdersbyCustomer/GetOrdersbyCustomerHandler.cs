namespace Ordering.Application.Orders.Queries.GetOrdersbyCustomer;

public class GetOrdersbyCustomerHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersbyCustomerQuery, GetOrdersbyCustomerResult>
{
    public async Task<GetOrdersbyCustomerResult> Handle(GetOrdersbyCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
                                    .Include(o => o.OrderItems)
                                    .AsNoTracking()
                                    .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                                    .OrderBy(o => o.OrderName.Value)
                                    .ToListAsync(cancellationToken);

        return new GetOrdersbyCustomerResult(orders.ToOrderDtoList());
    }
}
