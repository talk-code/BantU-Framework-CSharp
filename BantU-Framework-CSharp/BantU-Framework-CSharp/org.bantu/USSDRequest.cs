/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface USSDRequest
    {
        String getMSISDN();
        void setMSISDN(String MSISDN);

        String getMCC();
        void setMCC(String mcc);

        String getCID();
        void setCID(String value);

        String getLAC();
        void setLAC(String LAC);

        void setAttachment(Object attachment);
        Object getAttachment();

        void redirectTo(String windowName, USSDSession<Object> session, USSDResponse response);

        void setApplication(USSDApplication application);

        USSDApplication getApplication();
    }
}
