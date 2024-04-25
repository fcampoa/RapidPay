using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Services
{
    public class PaymentService : IPaymentService
    {
       public decimal LastFee { get; set; }
        public decimal ActualFee {  get; set; }
        public PaymentService() { }
        public decimal CalculateFee()
        {
            return LastFee * ActualFee;
        }

        public void SetFee(decimal fee)
        {
            LastFee = ActualFee;
            ActualFee = fee;
        }
    }
}
