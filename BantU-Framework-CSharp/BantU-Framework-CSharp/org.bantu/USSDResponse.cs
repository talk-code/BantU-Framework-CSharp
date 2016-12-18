/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface USSDResponse
    {
        Window getWindow();

        void setWindow(Window window);

        ResponseType getResponseType();

        void setResponseType(ResponseType responseType);

        USSDSession<object> getSession();

        void setSession(USSDSession<object> session);

        String getStatus();
        void setStatus(String value);

        static object ERROR_STATUS { get; set; }
    }
}
