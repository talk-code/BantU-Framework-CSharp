/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface Identifiable
    {
        String getId();

        void setId(String id);

        void setTag(String tag);

        String getTag();
    }
}
