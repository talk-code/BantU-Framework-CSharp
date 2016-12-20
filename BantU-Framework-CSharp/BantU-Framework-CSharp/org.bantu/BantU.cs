using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BantU
    {
        public static CoreFilter CoreFilter { get; set; }
        public static MenuIndexer MenuIndexer { get; set; }
        public static WindowRenderer WindowRenderer { get; set; }

        public static USSDResponse  executeRequest(USSDApplication application, USSDRequest request)
        {
            return executeRequest(application, request, null);
        }

        protected static USSDResponse executeRequest(USSDApplication application, USSDRequest request, USSDSession<Object> session)
        {
            USSDResponse ussdResponse = new BaseUSSDResponse();
            USSDSession<object> ussdSession = session;

            if (ussdSession == null)
            {
                SessionProvider sessionProvider = application.getSessionProvider();
                if(sessionProvider == null)
                    throw new BantUException(String.Format("The instance must not be null")); // ToDo: Implement as is in Java

                request.setApplication(application);
                ussdResponse.setSession(session);

                if (!application.getFilters().Contains(CoreFilter))
                {
                    application.getFilters().Add(CoreFilter);
                }
            }
        }

        private static USSDFilteringChain createFilteringChain(USSDApplication application)
        {
            List<USSDFilter> filters = new List<USSDFilter>();
            foreach (USSDFilter f in application.getFilters())
            {
                filters.Add(f);
            }

            USSDFilteringChain chain = new BaseUSSDFilteringChain();
        }
    }
}
