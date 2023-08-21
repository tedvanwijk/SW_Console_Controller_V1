using SolidWorks.Interop.sldworks;
using SW_Console_Controller_V1.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Console_Controller_V1.Controllers
{
    internal class BodyController : ModelController
    {
        ModelController _toolController;
        public BodyController(Properties properties, ModelDoc2 model) : base(properties, model)
        {
            UpdateModel();
        }

        private void UpdateModel()
        {
            switch (Properties.ToolType)
            {
                case "EMV2":
                    _toolController = new EMController(Properties, SwModel);
                    break;
            }
        }
    }
}
