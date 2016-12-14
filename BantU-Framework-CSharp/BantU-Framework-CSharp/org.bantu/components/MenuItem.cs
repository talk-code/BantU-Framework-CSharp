/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    using org.bantu.proxy;

    public class MenuItem: AbstractRenderableItem
    {
        public String Description { get; set; }
        public String Value { get; set; }
        public String TargetWindow { get; set; }
        public String Index { get; set; }
    }

    public class MenuItemBuilder
    {
        private MenuItem menuItem = new MenuItem();

        public MenuItemBuilder withValue(String value)
        {
            menuItem.Value = value;
            return this;
        }

        public MenuItemBuilder withDescription(String description)
        {
            menuItem.Description = description;
            return this;
        }

        public MenuItemBuilder withTargetWindow(String targetWindow)
        {
            menuItem.TargetWindow = targetWindow;
            return this;
        }

        public MenuItem build()
        {
            return menuItem;
        }
    }
}
