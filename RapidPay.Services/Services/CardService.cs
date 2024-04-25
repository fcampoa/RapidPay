using RapidPay.Domain.Models;
using RapidPay.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Services
{
    public class CardService : ICardService
    {
        private readonly IRapidPayUnitOfWork _unitOfWork;
        public CardService(IRapidPayUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseModel Create(Card card, ResponseModel? response = null)
        {
            throw new NotImplementedException();
        }

        public ResponseModel GetCardBalance(Card card, ResponseModel? response = null)
        {
            throw new NotImplementedException();
        }

        public ResponseModel Pay(Card card, decimal amount, ResponseModel? response = null)
        {
            throw new NotImplementedException();
        }
    }
}
