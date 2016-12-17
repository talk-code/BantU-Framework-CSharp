using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.interfaces;

    class BantURequestException: BantUException
    {
        private USSDRequest request;
        private USSDResponse response;
        private USSDSession<Object> session;

        public BantURequestException(String message, USSDRequest request, USSDResponse response, USSDSession<Object> session)
            :base(message)
        {
            this.request = request;
            this.response = response;
            this.session = session;
        }

        public BantURequestException(String message, USSDRequest request, USSDResponse response, USSDSession<Object> session, Exception cause)
            : base(message, cause)
        {
            this.request = request;
            this.response = response;
            this.session = session;
        }
    }
}
