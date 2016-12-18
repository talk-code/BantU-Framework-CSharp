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

        public BasicSession()
        {
            this.Id = DateTime.Now.Date.Ticks;
        }

        public void close()
        {
            this.Clear();
            this.currentWindow = this.previousWindow = null;
        }
    }
}
