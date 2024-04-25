using Microsoft.EntityFrameworkCore;

namespace RapidPay.Domain.Utilities
{
    public abstract class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        public T DbContext { get; private set; }

        public UnitOfWork(T dbContext)
        {
            DbContext = dbContext;
        }

        public string ConnectionString => DbContext.Database.GetConnectionString();-

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public int Commit(IResponseData responseData)
        {
            responseData.ResponseStatusType = ResponseStatusType.Error;
            int result = 0;

            try
            {
                result = DbContext.SaveChanges();
                responseData.ResponseStatusType = ResponseStatusType.Success;
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessage = ex.Message;
                    responseData.AddResponseMessage(ResponseMessageType.Error, errorMessage);
            }
            catch (DbUpdateException ex)
            {

                foreach (var errorEntry in ex.Entries)
                {
                    responseData.InsertResponseMessage(ResponseMessageType.Error, $"Type: {errorEntry.Entity.GetType().Name} was part of the problem.");
                }

                var innerEx = ex.InnerException;

                while (innerEx != null)
                {
                    responseData.InsertResponseMessage(ResponseMessageType.Error, innerEx.Message);

                    innerEx = innerEx.InnerException;
                }
            }
            catch (Exception ex)
            {
                responseData.AddResponseMessage(ResponseMessageType.Error, ex.Message);
            }

            return result;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
