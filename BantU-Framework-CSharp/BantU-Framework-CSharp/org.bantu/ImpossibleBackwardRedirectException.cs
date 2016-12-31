using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class ImpossibleBackwardRedirectException : BantURequestException
    {
        public ImpossibleBackwardRedirectException(MenuItem menuItem, USSDRequest request, USSDResponse response, USSDSession<Object> session)
            :base(String.Format("Session has no valid previousWindow value. User cant be redirected backward by %s Menu Item.",
                    menuItem.getId()), request, response, session)
        {
        }

    }
}
