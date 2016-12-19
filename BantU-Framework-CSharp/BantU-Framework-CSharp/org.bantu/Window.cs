/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class Window: AbstractIdentifiable
    {
        private Header header;
        private Input input;
        private List<MenuItem> menuItems = new List<MenuItem>();
        private String menuValueName;
        private USSDProcessor processor;
        private List<MenuItemsProvider> menuItemsProvider = new List<MenuItemsProvider>();
        private List<Message> messages = new List<Message>();

        public Window()
        {
        }

        public Window(String id)
            :base(id)
        {
        }

        public String getMenuValueName()
        {
            return menuValueName;
        }

        public void setMenuValeName(String nameValueName)
        {
            this.menuValueName = nameValueName;
        }

        public Header getHeader()
        {
            return header;
        }

        public void setHeader(Header header)
        {
            this.header = header;
        }

        public List<MenuItem> getMenuItems()
        {
            return menuItems;
        }

        public void setMenuItems(List<MenuItem> menuItems)
        {
            this.menuItems = menuItems;
        }

        public Input getInput()
        {
            return this.input;
        }

        public void setInput(Input input)
        {
            this.input = input;
        }

        public USSDProcessor getUSSDProcessor()
        {
            return processor;
        }

        public void setUSSDProcessor(USSDProcessor processor)
        {
            this.processor = processor;
        }

        public void addMenuItemsProviders(MenuItemsProvider provider)
        {
            this.menuItemsProvider.Add(provider);
        }

        public List<MenuItemsProvider> getMenuItemsProvider()
        {
            return menuItemsProvider;
        }

        public void addMessage(Message message)
        {
            this.messages.Add(message);
        }

        public void addMenuItem(MenuItem menuItem)
        {
            this.menuItems.Add(menuItem);
        }

        public List<Message> getMessages()
        {
            return messages;
        }

        public bool isForm()
        {
            return menuItems.Count > 0 || input != null;
        }
    }
}
