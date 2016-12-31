/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BasicSession: BaseUSSDSession<long>
    {
        public long Id { get; set; }
        public String currentWindow { get; set; }
        public String previousWindow { get; set; }

        public override String getString(String key)
        {
            throw new NullReferenceException();
        }

        public override long get(String key, Type t)
        {
            throw new NotImplementedException();
        }

        public BasicSession()
        {
            this.Id = DateTime.Now.Date.Ticks;
        }

        public override void saveSession()
        {
            throw new NullReferenceException();
        }

        public override void close()
        {
            this.Clear();
            this.currentWindow = this.previousWindow = null;
        }

        public override long getId()
        {
            return Id;
        }

        public override String getCurrentWindow()
        {
            return this.currentWindow;
        }

        public override void setCurrentWindow(String windowName)
        {
            this.currentWindow = windowName;
        }

        public override void setPreviousWindow(String windowName)
        {
            this.previousWindow = windowName;
        }

        public override String getPreviousWindow()
        {
            return this.previousWindow;
        }
    }
}
