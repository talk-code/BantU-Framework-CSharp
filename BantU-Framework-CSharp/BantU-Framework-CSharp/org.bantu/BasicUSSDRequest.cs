using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
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


        public void setLAC(String lac)
        {
            this.lac = lac;
        }

        public void setCID(String cid)
        {
            this.cid = cid;
        }

        public void setAttachment(Object attachment)
        {
            this.attachment = attachment;
        }

        public void setUSSDApplication(USSDApplication application)
        {
            this.application = application;
        }

        public void setMCC(String mcc)
        {
            this.mcc = mcc;
        }

        public void setMSISDN(String msisdn)
        {
            this.msisdn = msisdn;
        }

        protected void delegateRequest(USSDRequest request, USSDSession<Object> session, USSDResponse response)
        {
            USSDResponse ussdResponse = BantU.executeRequest(application, request, session);
            response.setWindow(ussdResponse.getWindow());
            response.setResponseType(ussdResponse.getResponseType());
            response.setSession(ussdResponse.getSession());
        }

        public void setApplication(USSDApplication application)
        {
            this.application = application;
        }

        public USSDApplication getApplication()
        {
            return application;
        }

        protected GetRequest buildGetRequest()
        {
            GetRequest getRequest = (GetRequest)new BasicGetRequest();
            getRequest.setMSISDN(getMSISDN());
            getRequest.setApplication(getApplication());
            getRequest.setAttachment(getAttachment());
            getRequest.setCID(getCID());
            getRequest.setLAC(getLAC());
            getRequest.setMCC(getMCC());

            return getRequest;
        }

        public void redirectTo(String windowName, USSDSession<Object> session, USSDResponse response) {
            session.setPreviousWindow(session.getCurrentWindow());
            session.setCurrentWindow(windowName);
            session.saveSession();
        }
    }
}
