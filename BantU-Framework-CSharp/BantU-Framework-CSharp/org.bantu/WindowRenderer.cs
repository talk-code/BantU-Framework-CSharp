using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface WindowRenderer
    {
        String render(Window renderable, USSDResponse response);
    }
}
