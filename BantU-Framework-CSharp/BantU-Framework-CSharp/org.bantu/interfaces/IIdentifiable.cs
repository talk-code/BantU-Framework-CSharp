using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

namespace org.bantu.interfaces
{
    public interface IIdentifiable
    {
        String getId();

        void setId();

        void setTag();

        String getTag();
    }
}
