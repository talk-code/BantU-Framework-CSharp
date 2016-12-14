/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDResponse
    {
        //String OK_STATUS = "OK";
        //String ERROR_STATUS = "ERROR";

        //Window getWindow();

        //void setWindow(Window window);

        //ResponseType getResponseType();

        //void setResponseType(ResponseType responseType);

        //USSDSession getSession();

        //void setSession(USSDSession session);

        String getStatus();
        void setStatus(String value);
    }
}
