using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Services
{
    public interface IPaymentService
    {
        public decimal CalculateFee();
        public void SetFee(decimal fee);
    }
}
