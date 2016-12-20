using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

                ussdSession = sessionProvider.getSession(request);
                if(ussdSession==null)
                    throw new NullReferenceException(String.Format("The %s instance returned by %s must not be null"));
            }

            request.setApplication(application);
            ussdResponse.setSession(session);

            if (!application.getFilters().Contains(CoreFilter))
            {
                application.getFilters().Add(CoreFilter);
            }

            USSDFilteringChain chain = createFilteringChain(application);
            chain.proceed(request, ussdSession, ussdResponse);

            if (request is GetRequest || request is PostRequest)
            {
                if (ussdResponse.getWindow().isForm())
                    ussdResponse.setResponseType(ResponseType.FORM);
                else
                    ussdResponse.setResponseType(ResponseType.MESSAGE);
            }
            else
            {
                ussdResponse.setResponseType(ResponseType.MESSAGE);
            }

            if (ussdResponse.getResponseType() == ResponseType.FORM)
            {
                BaseNavigationCache navigationCache = (BaseNavigationCache)application.getNavigationCache();

                if (navigationCache != null)
                {
                    try
                    {
                        navigationCache.storeWindow(ussdResponse.getWindow(), request, session);
                    }
                    catch (Exception ex)
                    {
                        throw new WindowStoreFailedException(ussdResponse.getWindow().getId(), request, ussdResponse, session);
                    }
                }
                else
                {
                    ussdSession.close();
                }
            }

            return ussdResponse;
        }

        private static USSDFilteringChain createFilteringChain(USSDApplication application)
        {
            List<USSDFilter> filters = new List<USSDFilter>();
            foreach (USSDFilter f in application.getFilters())
            {
                filters.Add(f);
            }

            BaseUSSDFilteringChain chain = new BaseUSSDFilteringChain();
            chain.Filters = filters;

            return chain;
        }

        public static USSDApplication getApplicationFromXML(Stream inputStream)
        {

            //TODO: Implement
            return null;

        }
    }
}
