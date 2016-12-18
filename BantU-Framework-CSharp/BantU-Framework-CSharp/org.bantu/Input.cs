/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class Input
    {
        public String RegExp { get; set; }
        public String Name { get; set; }
        public String OnErrorTargetWindow { get; set; }
    }

    public class InputBuilder
    {
        private Input input = new Input();

        public InputBuilder withName(String name)
        {
            input.Name = name;
            return this;
        }

        public InputBuilder withRegExp(String regExp, String onErrorWindow)
        {
            input.RegExp = regExp;
            input.OnErrorTargetWindow = onErrorWindow;
            return this;
        }

        public Input build()
        {
            return input;
        }
    }
}
