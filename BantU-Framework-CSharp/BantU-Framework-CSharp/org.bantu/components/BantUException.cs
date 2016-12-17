using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    class BantUException: Exception
    {
        public BantUException(String message)
            :base(message)
        {   
        }

        public BantUException(String message, Exception ex)
            :base(message, ex)
        {
        }
    }
}
