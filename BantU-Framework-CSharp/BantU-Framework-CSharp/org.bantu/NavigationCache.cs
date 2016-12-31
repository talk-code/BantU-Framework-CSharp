using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface NavigationCache
    {
        void storeWindow(Window window, USSDRequest request, USSDSession<Object> session);
        Window fetchWindow(String windowId, USSDRequest request, USSDSession<Object> session);
    }
}
