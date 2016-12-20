using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    class BaseNavigationCache : NavigationCache
    {
        private Dictionary<String, Window> items = new Dictionary<String, Window>();

        public void storeWindow(Window window, USSDRequest request, USSDSession<Object> session)
        {

            items[window.getId()] = window;

        }

        public Window fetchWindow(String windowId, USSDRequest request, USSDSession<Object> session)
        {

            return items[windowId];

        }
    }
}
