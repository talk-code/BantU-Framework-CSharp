using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BasicPostRequest : BasicUSSDRequest, PostRequest
    {
        private String inputValue;

        public BasicPostRequest()
            :base()
        {
        }

        public new void redirectTo(String windowName, USSDSession<Object> session, USSDResponse response)
        {
            base.redirectTo(windowName, session, response);
            GetRequest getRequest = buildGetRequest();
            delegateRequest(getRequest, session, response);
        }

        public String getInputValue()
        {
            return inputValue;
        }

        public void setInputValue(String inputValue)
        {
            this.inputValue = inputValue;
        }
    }
}
