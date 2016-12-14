/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    public interface IRenderableItem
    {
        void setRender(bool value);
        bool isHidden();
        void hide();
        void show();
    }
}
