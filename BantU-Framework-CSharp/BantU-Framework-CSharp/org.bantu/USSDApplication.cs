/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface USSDApplication
    {
        void addWindowFilter(String windowName, USSDFilter filter);

        void addFilter(USSDFilter filter);

        void addWindow(Window window);

        List<USSDFilter> getWindowFilters(String windowName);

        List<USSDFilter> getFilters();

        void addService(Service service);
        List<Service> getServices();
        Service getService(String id);


        String getStartupWindowId();

        void setStartupWindowId(String startupWindowId);

        Window getWindow(String windowId);

        USSDRequest newRequest(String str);
        USSDRequest newTimeoutRequest();
        USSDRequest newReleaseRequest();

        SessionProvider getSessionProvider();
        void setSessionProvider(SessionProvider provider);

        List<String> getBaseCodes();
        void activateBaseCode(String code);
        bool canRun(String code);
    }
}
