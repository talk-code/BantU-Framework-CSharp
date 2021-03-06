﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BasicGetRequest : BasicUSSDRequest, GetRequest
    {
        private String baseUSSDCode;

        public BasicGetRequest()
            :base()
        {
        }

        public new void redirectTo(String windowName, USSDSession<Object> session, USSDResponse response)
        {
            base.redirectTo(windowName, session, response);

            GetRequest getRequest = buildGetRequest();
            getRequest.setUSSDBaseCode(getUSSDBaseCode());

            delegateRequest(getRequest, session, response);

        }

        public String getUSSDBaseCode()
        {
            return baseUSSDCode;
        }

        public void setUSSDBaseCode(String code)
        {
            this.baseUSSDCode = code;
        }
    }
}
