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

        public NavigationCache getNavigationCache()
        {
            return navigationCache;
        }

        public void setNavigationCache(NavigationCache navigationCache)
        {
            this.navigationCache = navigationCache;
        }
    }
}
