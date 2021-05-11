using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Utils
{
    public class ErrorHandling : Exception
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ErrorHandling (Exception ex)
        {
            Code = DefineCode(ex.HResult);
            Type = ex.GetType().Name;
            Message = FriendlyMessageError(ex.Message);
            StackTrace = ex.ToString();
        }

        public ErrorHandling(int Code, string Type, string Message)
        {
            this.Code = Code;
            this.Type = Type;
            this.Message = Message;
        }

        private string FriendlyMessageError(string exMessage)
        {
            string friendlyMessage = string.Empty;


            if (!string.IsNullOrEmpty(exMessage))
                return exMessage;

            return friendlyMessage;
        }

        private int DefineCode (int exCode)
        {
            int code = 500;

            if (exCode > 0)
                return exCode;

            return code;
        }
    }
}
