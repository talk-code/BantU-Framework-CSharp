/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class Message: AbstractRenderableItem
    {
        private String content;

        public Message()
        {
        }

        public Message(String content)
            :base()
        {
            this.content = content;
        }

        public Message(String content, String id)
            : base(id)
        {
            this.content = content;
        }

        public String getContent()
        {
            return content;
        }

        public void setContent(String content)
        {
            this.content = content;
        }
    }
}
