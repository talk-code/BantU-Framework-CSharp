﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public interface PostRequest: USSDRequest
    {
        String getInputValue();
        void setInputValue(String inputValue);
    }
}
