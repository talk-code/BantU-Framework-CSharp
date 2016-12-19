using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class DefaultWindowRenderer: WindowRenderer
    {
        public String render(Window window, USSDResponse response)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Message message in window.getMessages())
            {
                builder.Append(message.getContent());
                builder.Append("\n");
            }

            foreach (MenuItem menuItem in window.getMenuItems())
            {
                builder.Append(menuItem.Index + "." + menuItem.Description + "\n");
            }

            String final = builder.ToString();
            USSDSession<Object> session = response.getSession();

            foreach (Object key in session.Keys)
            {
                Object value = session[(String)key];
                final = final.Replace("\\{\\{" + (String)key + "\\}\\}", value.ToString()); //ToDo: Fix this!
            }

            return final;
        }
    }
}
