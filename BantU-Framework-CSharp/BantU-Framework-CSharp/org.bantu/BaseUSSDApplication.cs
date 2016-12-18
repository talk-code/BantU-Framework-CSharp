/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BaseUSSDApplication
    {
        private String startupWindowId;
        private SessionProvider sessionProvider;
        private Dictionary<string, List<USSDFilter>> windowFilters = new Dictionary<string, List<USSDFilter>>();
        private Dictionary<string, Window> windows = new Dictionary<string, Window>();
        private List<USSDFilter> filters = new List<USSDFilter>();
        private Dictionary<string, bool> baseCodes = new Dictionary<string, bool>();
        private Dictionary<string, Service> services = new Dictionary<string, Service>();

        public BaseUSSDApplication()
        {
            //this.sessionProvider = new Base
        }
    }
}
