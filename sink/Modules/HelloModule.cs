﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace sink.Modules
{
    public class HelloModule : NancyModule
    {

        public HelloModule()
        {
            Get["/"] = parameters => "hi";
        }

    }
}
