using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.interfaces;

    class BaseUSSDResponse : USSDResponse
    {
        public Window window { get; set; }
        public ResponseType responseType { get; set; }
        public USSDSession<Object> session { get; set; }
        public String status = USSDResponse.OK_STATUS;
        public String responseBody;

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
            return this.status.Equals(USSDResponse.ERROR_STATUS);
        }
    }
}
