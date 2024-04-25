using RapidPay.Domain.Repositories;

namespace RapidPay.Domain.Utilities
{
    public interface IUnitOfWork
    {
        int Commit();
        int Commit(IResponseData responseData);
        Task CommitAsync();
        void Dispose();
    }
}
