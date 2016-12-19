using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class DefaultMenuIndexer: MenuIndexer
    {
        public void index(List<MenuItem> menus)
        {
            //Index 0 (Zero) reserved for backward navigation
            for (int i = 0; i < menus.Count - 1; i++)
            {
                if (menus[i].Index != null)
                {
                    menus[i].Index = (i + 1).ToString(); 
                }
            }
        }
    }
}
