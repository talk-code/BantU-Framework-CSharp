using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{

    class BantURequestException: BantUException
    {
        private USSDRequest request;
        private USSDResponse response;
        private USSDSession<Object> session;

        public BantURequestException(String message, USSDRequest request, USSDResponse response, USSDSession<Type> session)
            :base(message)
        {
            this.request = request;
            this.response = response;
            this.session = session;
        }

        public BantURequestException(String message, USSDRequest request, USSDResponse response, USSDSession<Type> session, Exception cause)
            : base(message, cause)
        {
            this.request = request;
            this.response = response;
            this.session = session;
        }
    }
}
