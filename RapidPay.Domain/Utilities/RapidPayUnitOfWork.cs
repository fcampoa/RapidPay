using RapidPay.Domain.Models;
using RapidPay.Domain.Repositories;

namespace RapidPay.Domain.Utilities
{
    public class RapidPayUnitOfWork : UnitOfWork<RapidPayContext>, IRapidPayUnitOfWork
    {
        public RapidPayUnitOfWork(RapidPayContext dbContext): base(dbContext) {}

        private IRepository<Card> _cardRepository;
        public IRepository<Card> CardsRepository() => _cardRepository ??= new Repository<Card>(DbContext);
        private IRepository<Payment> _paymentRepository;
        public IRepository<Payment> PaymentRepository() => _paymentRepository ??= new Repository<Payment>(DbContext);
        
    }
}
