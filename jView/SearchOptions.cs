﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jView
{
    /// <summary>
    /// Class contains options used for search nodes in tree
    /// </summary>
    public class SearchOptions
    {
        //private bool findName;
        //private bool findValue;

        public bool FindName { get; set; }
        public bool FindValue { get; set; }
        public bool CaseSensitive { get; set; }
    }
}
