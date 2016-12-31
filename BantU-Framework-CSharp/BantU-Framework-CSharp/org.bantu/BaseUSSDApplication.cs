/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BaseUSSDApplication: USSDApplication
    {
        private String startupWindowId;
        private SessionProvider sessionProvider;
        private Dictionary<string, List<USSDFilter>> windowFilters = new Dictionary<string, List<USSDFilter>>();
        private Dictionary<string, Window> windows = new Dictionary<string, Window>();
        private List<USSDFilter> filters = new List<USSDFilter>();
        private Dictionary<string, bool> baseCodes = new Dictionary<string, bool>();
        private Dictionary<string, Service> services = new Dictionary<string, Service>();
        private NavigationCache navigationCache;

        public BaseUSSDApplication()
        {
            this.sessionProvider = new BasicSessionProvider();
        }

        public Service getService(String id)
        {
            return services[id];
        }

        public SessionProvider getSessionProvider()
        {
            return sessionProvider;
        }

        public void setSessionProvider(SessionProvider provider)
        {
            this.sessionProvider = provider;
        }

        public void addWindowFilter(String windowName, USSDFilter filter)
        {
            if (windowFilters.Keys.Contains(windowName))
            {
                windowFilters[windowName].Add(filter);
            }
            else
            {
                List<USSDFilter> filterList = new List<USSDFilter>();
                filterList.Add(filter);
                windowFilters[windowName] = filterList;
            }
        }

        public void addFilter(USSDFilter filter)
        {
            filters.Add(filter);
        }

        public void addWindow(Window window)
        {
            this.windows[window.getId()] = window;
        }

        public List<USSDFilter> getWindowFilters(String windowName)
        {
            if (windowFilters.Keys.Contains(windowName))
                return windowFilters[windowName];

            return new List<USSDFilter>();
        }

        public List<USSDFilter> getFilters()
        {
            return filters;
        }

        public void addService(Service service)
        {
            this.services[service.Id] = service;
        }

        public List<Service> getServices()
        {
            throw new NotImplementedException();
        }

        public String getStartupWindowId()
        {
            return startupWindowId;
        }

        public void setStartupWindowId(String startupWindowId)
        {
            this.startupWindowId = startupWindowId;
        }

        public Window getWindow(String windowId)
        {

            if (windows.Keys.Contains(windowId))
                return windows[windowId];

            return null;
        }

        public USSDRequest newRequest(String str)
        {
            if (str == null || str.Length == 0)
                throw new BantUException("Request cannot be null or null");

            if (canRun(str.Trim()))
            {
                BasicGetRequest request = new BasicGetRequest();
                request.setApplication(this);
                request.setUSSDBaseCode(str.Trim());

                return request;
            }

            foreach(Service service in getServices()){
                //TODO: Generate the regular expression
                String regExp = service.getRegularExpression();
                //TODO: Match a service
                //TODO: Get the values
                //TODO: Fill the Service Request and return it
            }

            BasicPostRequest prequest = new BasicPostRequest();
            prequest.setApplication(this);
            prequest.setInputValue(str.Trim());
            return prequest;
        }

        public List<String> getBaseCodes()
        {
            return baseCodes.Keys.ToList();
        }

        public void activateBaseCode(String code)
        {
            baseCodes[code] = true;
        }

        public bool canRun(String code)
        {
            return baseCodes.Keys.Contains(code);
        }

        public NavigationCache getNavigationCache()
        {
            return navigationCache;
        }

        public void setNavigationCache(NavigationCache navigationCache)
        {
            this.navigationCache = navigationCache;
        }

        public USSDRequest newTimeoutRequest()
        {
            //TODO: Create and return a Timeout Request
            return null;
        }

        public USSDRequest newReleaseRequest()
        {
            //TODO: Create and return a Release Request
            return null;
        }
    }
}
