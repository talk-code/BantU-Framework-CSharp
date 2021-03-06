﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public abstract class BaseUSSDSession<T>: Dictionary<String, T>, USSDSession<T>
    {
        public double getDouble(String key)
        {
            if (this.ContainsKey(key))
            {
                double d;
                double.TryParse(this[key].ToString(), out d);

                return d;
            }

            return 0.0;
        }

        public abstract String getString(String key);

        public abstract T getId();

        public abstract T get(String key, Type t);

        public abstract void saveSession();

        public abstract String getCurrentWindow();

        public abstract void setCurrentWindow(String windowName);

        public abstract void setPreviousWindow(String windowName);

        public abstract String getPreviousWindow();

        public abstract void close();

        public bool Is(String key)
        {
            if(this.ContainsKey(key)){
                bool b;
                bool.TryParse(this[key].ToString(), out b);

                return b;
            }

            return false;
        }

        public bool getBoolean(String key)
        {
            return Is(key);
        }

        public int getInt(String key)
        {
            if (this.ContainsKey(key))
            {
                int i;
                int.TryParse(this[key].ToString(), out i);

                return i;
            }

            return 0;
        }

        public long getLong(String key)
        {
            if (this.ContainsKey(key))
            {
                long l;
                long.TryParse(this[key].ToString(), out l);

                return l;
            }

            return 0;
        }

        //public T get<T>(String key, Type type)
        //{
        //    try
        //    {
        //        if (this.ContainsKey(key))
        //        {
        //            //return (T)this[key];
        //        }
        //    }
        //    catch (Exception ex) { }

        //    return default(T);
        //}
    }
}
