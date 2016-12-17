using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.interfaces;

    public class BasicUSSDRequest: USSDRequest
    {
        private String msisdn;
        private String mcc;
        private String lac;
        private String cid;
        private Object attachment;
        private USSDApplication application;

        public String getLAC()
        {
            return this.lac;
        }

        public String getCID()
        {
            return this.cid;
        }

        public Object getAttachment()
        {
            return this.attachment;
        }

        public USSDApplication getUSSDApplication()
        {
            return this.application;
        }

        public String getMCC()
        {
            return this.mcc;
        }

        public String getMSISDN()
        {
            return this.msisdn;
        }

        protected void delegateRequest(USSDRequest request, USSDSession<Object> session, USSDResponse response)
        {
            
        }

        protected GetRequest buildGetRequest()
        {
            GetRequest getRequest = (GetRequest)new BasicGetRequest();

            return getRequest;
        }
    }
}
