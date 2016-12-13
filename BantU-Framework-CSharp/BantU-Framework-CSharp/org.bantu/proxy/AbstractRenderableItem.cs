using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

namespace org.bantu.proxy
{
    using org.bantu.interfaces;

    public abstract class AbstractRenderableItem : AbstractIdentifiable, IRenderableItem
    {
        private bool render = true;

        public AbstractRenderableItem(String id)
            :base(id)
        {
        }

        public AbstractRenderableItem()
            : base()
        {
        }

        public void setRender(bool render)
        {
            this.render = render;
        }

        public bool isHidden()
        {
            return !render;
        }

        public void hide()
        {
            this.render = false;
        }

        public void show()
        {
            this.render = true;
        }
    }
}
