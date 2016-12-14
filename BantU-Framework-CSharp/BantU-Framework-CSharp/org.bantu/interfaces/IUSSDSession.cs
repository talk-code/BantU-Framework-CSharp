/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IUSSDSession<IdType>: IDictionary<String, Object>
    {
        IdType getId();
        double getDouble(String key);
        bool Is(String key);
        bool getBoolean(String key);
        String getString(String key);
        int getInt(String key);
        long getLong(String key);

        T get<T>(String key, T type) where T: class;

        void saveSession();

        String getCurrentWindow();

        void setCurrentWindow(String windowName);

        void setPreviousWindow(String windowName);

        String getPreviousWindow(String windowName);

        void close();
    }
}
