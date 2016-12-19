using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    class WindowNotFoundException: BantURequestException
    {
        private String windowName;

        public WindowNotFoundException(String name, USSDRequest request, USSDResponse response, USSDSession<object> session)
            : base(String.Format("A window with name \"%s\" could not be found.", name), request, response, session)
        {
            this.windowName = name;
        }

        public String getWindowName()
        {
            return windowName;
        }
    }
}
