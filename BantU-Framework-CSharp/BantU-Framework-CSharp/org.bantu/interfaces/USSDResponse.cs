/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    using org.bantu.components;

    public interface USSDResponse
    {
        static String OK_STATUS = "OK";
        static String ERROR_STATUS = "ERROR";

        Window getWindow();

        void setWindow(Window window);

        ResponseType getResponseType();

        void setResponseType(ResponseType responseType);

        USSDSession<object> getSession();

        void setSession(USSDSession<object> session);

        String getStatus();
        void setStatus(String value);
    }
}
