using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Console_Controller_V1.Controllers
{
    internal class EMController : ModelController
    {
        public EMController(Properties properties, ModelDoc2 model) : base(properties, model)
        {
            UpdateModel();
        }

        private void UpdateModel()
        {
        } 
    }
}
