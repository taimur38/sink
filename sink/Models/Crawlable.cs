﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.Models
{
    public abstract class Crawlable : BaseActivity
    {
        public abstract bool Exists();
    }
}
