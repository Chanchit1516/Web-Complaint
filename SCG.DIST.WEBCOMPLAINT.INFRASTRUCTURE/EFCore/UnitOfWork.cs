using Microsoft.Extensions.Logging;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Repositories;

namespace SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.EFCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;
        IProductRepository productRepository;
        ICustomerRepository customerRepository;
        IOrderRepository orderRepository;
        IUserRepository userRepository;


        //private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _dbContext = context;
        }


        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(_dbContext);
        public ICustomerRepository CustomerRepository => customerRepository ??= new CustomerRepository(_dbContext);
        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository(_dbContext);
        public IUserRepository UserRepository => userRepository ??= new UserRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
