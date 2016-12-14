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

    public interface IUSSDApplication
    {
        void addWindowFilter(String windowName, IUSSDFilter filter);

        void addFilter(IUSSDFilter filter);

        void addWindow(Window window);

        List<IUSSDFilter> getWindowFilters(String windowName);

        List<IUSSDFilter> getFilters();

        void addService(Service service);
        List<Service> getServices();
        Service getService(String id);


        String getStartupWindowId();

        void setStartupWindowId(String startupWindowId);

        Window getWindow(String windowId);

        IUSSDRequest newRequest(String str);
        IUSSDRequest newTimeoutRequest();
        IUSSDRequest newReleaseRequest();

        ISessionProvider getSessionProvider();
        void setSessionProvider(ISessionProvider provider);

        List<String> getBaseCodes();
        void activateBaseCode(String code);
        bool canRun(String code);
    }
}
