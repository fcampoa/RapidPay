using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Domain.Utilities
{
    public enum ResponseStatusType
    {
        Success,
        Error
    }

    public enum ResponseMessageType
    {
        Information,
        Warning,
        Error,
    }

    public class ResponseMessage
    {
        public bool DisplayToUser { get; set; }
        public ResponseMessageType ResponseMessageType { get; set; }
        public string Message { get; set; }
    }

    public interface IResponseData
    {
        object Id { get; set; }
        ResponseStatusType ResponseStatusType { get; set; }
        List<ResponseMessage> ResponseMessages { get; }

        void AddResponseMessage(ResponseMessageType type, string message, bool displayToUser = false);
        void InsertResponseMessage(ResponseMessageType type, string message, bool displayToUser = false);
        void AddResponseMessages(ResponseMessageType type, IEnumerable<string> messages, bool displayToUser = false);
        void AddErrorMessages(IEnumerable<string> messages, bool displayToUser = false);
        void AddSuccessMessages(IEnumerable<string> messages, bool displayToUser = false);

    }

    public class ResponseModel : IResponseData
    {
        public object Id { get; set; }
        public ResponseStatusType ResponseStatusType { get; set; }

        public List<ResponseMessage> ResponseMessages { get; set; }

        public ResponseModel()
        {
            ResponseMessages = new List<ResponseMessage>();
        }

        public void AddErrorMessages(IEnumerable<string> messages, bool displayToUser = false)
        {
            foreach (var m in messages)
            {
                var message = new ResponseMessage();
                message.DisplayToUser = displayToUser;
                message.ResponseMessageType = ResponseMessageType.Error;
                message.Message = m;
                ResponseMessages.Add(message);
            }
        }

        public void AddResponseMessage(ResponseMessageType type, string message, bool displayToUser = false)
        {

            var m = new ResponseMessage();
            m.ResponseMessageType = type;
            m.DisplayToUser = displayToUser;
            m.Message = message;
            ResponseMessages.Add(m);
        }

        public void AddResponseMessages(ResponseMessageType type, IEnumerable<string> messages, bool displayToUser = false)
        {
            foreach (var m in messages)
            {
                var message = new ResponseMessage();
                message.DisplayToUser = displayToUser;
                message.ResponseMessageType = type;
                message.Message = m;
                ResponseMessages.Add(message);
            }
        }

        public void AddSuccessMessages(IEnumerable<string> messages, bool displayToUser = false)
        {
            foreach (var m in messages)
            {
                var message = new ResponseMessage();
                message.DisplayToUser = displayToUser;
                message.ResponseMessageType = ResponseMessageType.Information;
                message.Message = m;
                ResponseMessages.Add(message);
            }
        }

        public void InsertResponseMessage(ResponseMessageType type, string message, bool displayToUser = false)
        {
            var m = new ResponseMessage();
            m.ResponseMessageType = type;
            m.DisplayToUser = displayToUser;
            m.Message = message;
            ResponseMessages.Add(m);
        }
    }
}
