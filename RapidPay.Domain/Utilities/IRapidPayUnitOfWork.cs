using RapidPay.Domain.Models;
using RapidPay.Domain.Repositories;

namespace RapidPay.Domain.Utilities
{
    public interface IRapidPayUnitOfWork : IUnitOfWork
    {
        IRepository<Card> CardsRepository();
        IRepository<Payment> PaymentRepository();
    }
}
