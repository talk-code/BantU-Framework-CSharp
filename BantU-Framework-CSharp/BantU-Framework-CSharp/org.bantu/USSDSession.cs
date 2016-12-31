/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface USSDSession<Object>: IDictionary<String, Object>
    {
        Object getId();
        double getDouble(String key);
        bool Is(String key);
        bool getBoolean(String key);
        String getString(String key);
        int getInt(String key);
        long getLong(String key);

        Object get(String key, Type t);

        void saveSession();

        String getCurrentWindow();

        void setCurrentWindow(String windowName);

        void setPreviousWindow(String windowName);

        String getPreviousWindow();

        void close();
    }
}
