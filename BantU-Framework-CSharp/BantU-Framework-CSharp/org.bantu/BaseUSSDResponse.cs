using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    class BaseUSSDResponse : USSDResponse
    {
        public Window window { get; set; }
        public ResponseType responseType { get; set; }
        public USSDSession<Object> session { get; set; }
        public String responseBody;
        private String status = BaseUSSDResponse.OK_STATUS;
        public static String OK_STATUS="OK";
        public static String ERROR_STATUS="ERROR";

        public BaseUSSDResponse()
            : base()
        {

        }

        public String ToString()
        {
            if (responseBody != null)
                return responseBody;

            //if (window != null)
            //    return window;

            return "";
        }

        public bool requestFailed()
        {
            return this.status.Equals(BaseUSSDResponse.ERROR_STATUS);
        }
    }
}
