﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.proxy;
    using org.bantu.interfaces;

    public class Window: AbstractIdentifiable
    {
        private Header header;
        private Input input;
        private List<MenuItem> menuItems = new List<MenuItem>();
        private String menuValueName;
        private IUSSDProcessor processor;
        private List<IMenuItemsProvider> menuItemsProvider = new List<IMenuItemsProvider>();
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