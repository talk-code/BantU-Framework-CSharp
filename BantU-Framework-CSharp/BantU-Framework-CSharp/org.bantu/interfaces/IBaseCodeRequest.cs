using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public class IBaseCodeRequest: IUSSDRequest
    {
        String getUSSDBaseCode();
        void setUSSDBaseCode(String code);
    }
}
