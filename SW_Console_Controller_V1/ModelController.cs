﻿using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SW_Console_Controller_V1
{
    internal class ModelController
    {
        public Properties Properties { get; }
        public ModelDoc2 SwModel { get; }
        public ModelController(Properties properties, ModelDoc2 model)
        {
            Properties = properties;
            SwModel = model;
        }
    }
}
