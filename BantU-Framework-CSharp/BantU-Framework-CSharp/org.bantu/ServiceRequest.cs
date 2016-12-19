using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface ServiceRequest: BaseCodeRequest
    {
        String getUSSDCode();
        String getServiceName();
        String getServiceDescription();
    }
}
