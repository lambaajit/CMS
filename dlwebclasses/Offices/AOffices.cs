﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public abstract class AOffices
    {
        public abstract StringBuilder getofficesInLondon();
        public abstract StringBuilder getofficesOutLondon();
        public abstract List<string> getofficesInLondonList(Website_Pages webpage = null);

        public abstract List<string> getofficesOutLondonList(Website_Pages webpage = null);
    }
}
