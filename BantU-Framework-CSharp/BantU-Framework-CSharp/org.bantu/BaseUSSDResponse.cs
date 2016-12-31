using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    class BaseUSSDResponse : USSDResponse
    {
        private Window window { get; set; }
        private ResponseType responseType { get; set; }
        private USSDSession<Object> session { get; set; }
        private String responseBody;
        private String status = BaseUSSDResponse.OK_STATUS;
        private static String OK_STATUS = "OK";
        private static String ERROR_STATUS = "ERROR";

        public BaseUSSDResponse()
            : base()
        {
        }

        public bool requestFailed()
        {
            return this.status.Equals(BaseUSSDResponse.ERROR_STATUS);
        }

        public Window getWindow()
        {
            return window;
        }

        public void setWindow(Window window)
        {
            this.window = window;
        }

        public ResponseType getResponseType()
        {
            return responseType;
        }

        public void setResponseType(ResponseType responseType)
        {
            this.responseType = responseType;
        }

        public void setResponseBody(String body)
        {

            this.responseBody = body;

        }

        public String getResponseBody()
        {

            return this.responseBody;
        }

        public USSDSession<object> getSession()
        {
            return session;
        }

        public void setSession(USSDSession<Object> session)
        {
            this.session = session;
        }

        public String getStatus()
        {

            return status;

        }

        public void setStatus(String value)
        {

            if (value == null)
                throw new BantUException("Status should never be null");
            this.status = value;

        }


        public override String ToString()
        {
            if (responseBody != null)
                return responseBody;

            //if (window != null)
            //    return window;

            return "";
        }
    }
}
