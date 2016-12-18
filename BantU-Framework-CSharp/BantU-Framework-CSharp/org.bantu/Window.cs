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


    }
}
