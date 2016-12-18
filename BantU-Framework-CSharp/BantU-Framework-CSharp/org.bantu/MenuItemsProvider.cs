/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface MenuItemsProvider
    {
        List<MenuItem> getMenuItems(String windowName, USSDRequest request, USSDSession<Object> session);
    }
}
