using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class CoreFilter: USSDFilter
    {
        public static sealed String BACKWARD_TARGET_WINDOW = "#backward";

        public void doFilter(USSDRequest request, USSDSession<Object> session, USSDResponse response, USSDFilteringChain chain)
        {

        }
    }
}
