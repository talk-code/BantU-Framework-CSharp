/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.interfaces;

    public class Service
    {
        public String Id { get; set; }
        public String Description { get; set; }
        public String matchPattern { get; set; }
        public USSDProcessor processor { get; set; }

        public String getRegularExpression()
        {

            //TODO: Implement
            throw new NotImplementedException();

        }
    }
}
