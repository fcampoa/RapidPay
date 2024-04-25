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
        private readonly IPaymentService _paymentService;
        public CardService(IRapidPayUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseModel Create(Card card, ResponseModel? response = null)
        {
            response = response ??= new ResponseModel();
            var repo = _unitOfWork.CardsRepository();
            repo.Create(card);
            _unitOfWork.Commit(response);
            if (response.ResponseStatusType == ResponseStatusType.Success)
            {
                response.Id = card.Id;
                response.AddSuccessMessages(new string[] { "Card saved" }, true);
            }
            else
            {
                response.AddErrorMessages(new string[] { "Error during creation" }, true);
            }
            return response;
        }

        public ResponseModel GetCardBalance(Card card, ResponseModel? response = null)
        {
            response = response ??= new ResponseModel();
            var repo = _unitOfWork.CardsRepository();
            repo.Create(card);
            _unitOfWork.Commit(response);
            if (response.ResponseStatusType == ResponseStatusType.Success)
            {
                response.Id = card.Balance;
                response.AddSuccessMessages(new string[] { "Card Balance" }, true);
            }
            else
            {
                response.AddErrorMessages(new string[] { "Error getting card balance" }, true);
            }
            return response;
        }

        public ResponseModel Pay(Card card, decimal amount, ResponseModel? response = null)
        {
            response = response ??= new ResponseModel();
            var repo = _unitOfWork.CardsRepository();
            var c = repo.FindById(card.Id);
            if (c == null)
            {
                response.AddErrorMessages(new string[] { "card not found" }, true);
                return response;
            }
            c.Balance += (amount - (amount * _paymentService.CalculateFee()));
            repo.Update(c);
            _unitOfWork.Commit(response);
            if (response.ResponseStatusType == ResponseStatusType.Success)
            {
                response.Id = card.Id;
                response.AddSuccessMessages(new string[] { "Card saved" }, true);
            }
            else
            {
                response.AddErrorMessages(new string[] { "Error during creation" }, true);
            }
            return response;
        }
    }
}
