/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.interfaces
{
    using org.bantu.components;
    public interface IMenuItemsProvider
    {
        List<MenuItem> getMenuItems(String windowName, IUSSDRequest request, IUSSDSession<Object> session);
    }
}
