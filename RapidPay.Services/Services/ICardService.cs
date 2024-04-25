using RapidPay.Domain.Models;
using RapidPay.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Services
{
    public interface ICardService
    {
        ResponseModel Create(Card card, ResponseModel? response = null);
        ResponseModel Pay(Card card, decimal amount, ResponseModel? response = null);
        ResponseModel GetCardBalance(Card card, ResponseModel? response = null);
    }
}
