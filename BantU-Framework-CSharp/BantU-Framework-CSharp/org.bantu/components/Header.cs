using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    public class Header
    {
        private List<Message> messages = new List<Message>();

        public List<Message> getMessages()
        {
            return messages;
        }

        public void setMessages(List<Message> messages)
        {
            this.messages = messages;
        }
    }
}
