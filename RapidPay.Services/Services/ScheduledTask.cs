using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Services
{
    public class ScheduledTask : BackgroundService
    {
        private static readonly Random random = new Random();
        private readonly IPaymentService _paymentService;
        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Factory.StartNew(() => { _paymentService.SetFee((decimal)RandomNumberBetween(0, 2)); });
            
        }
    }
}
