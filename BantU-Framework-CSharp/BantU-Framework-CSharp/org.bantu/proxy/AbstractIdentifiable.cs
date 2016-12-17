/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.proxy
{
    using org.bantu.interfaces;

    public abstract class AbstractIdentifiable: Identifiable
    {
        private String id;

        public String tag;

        public AbstractIdentifiable()
        {
        }

        public AbstractIdentifiable(String id)
        {
            this.id = id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public void setTag(String tag)
        {
            this.tag = tag;
        }

        public String getId()
        {
            return id;
        }

        public String getTag()
        {
            return tag;
        }
    }
}
