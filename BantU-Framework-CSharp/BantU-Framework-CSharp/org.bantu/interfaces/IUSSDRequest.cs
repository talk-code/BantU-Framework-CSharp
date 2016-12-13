﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDRequest
    {
        String getMSISDN();
        void setMSIDN(String MSISDN);

        String getMCC();
        void setMCC();

        String getCID();
        void setCID(String value);

        String getLAC();
        void setLAC(String LAC);

        void setAttachment(Object attachment);
        Object getAttachment();

        //void redirectTo(String windowName, USSDSession session, USSDResponse response);

        //void setApplication(USSDApplication application);

        //USSDApplication getApplication();
    }
}
