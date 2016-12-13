using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu.components
{
    public class Input
    {
        public String RegExp { get; set; }
        public String Name { get; set; }
        public String OnErrorTargetWindow { get; set; }

        public static class Builder
        {
            private Input input = new Input();

            public Builder withName(String name)
            {
                input.Name = name;
                return this;
            }

            public Builder withRegExp(String regExp, String onErrorWindow)
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
}
