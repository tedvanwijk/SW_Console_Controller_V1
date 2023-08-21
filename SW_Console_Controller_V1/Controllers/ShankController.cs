using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SW_Console_Controller_V1.Lib;

namespace SW_Console_Controller_V1.Controllers
{
    internal class ShankController : ModelController
    {
        public ShankController(Properties properties, ModelDoc2 model) : base(properties, model)
        {
            UpdateModel();
        }

        private void UpdateModel()
        {
            double shankChamferWidth = Properties.ToolDiameter < 0.2501 ? 0.03 : 0.045;
            double shankChamferAngle = Properties.ToolDiameter < 0.2501 ? 30 : 45;

            switch (Properties.ShankType)
            {
                case "Reduced":
                    ModelControllerTools.SetSketchDimension("REDUCED_SHANK_SKETCH",
                        new[] { "CHAMFER_ANGLE", "CHAMFER_WIDTH", "SHANK_DIAMETER", "TO_HEAD_RADIUS" },
                        new[] { shankChamferAngle, shankChamferWidth, Properties.ShankDiameter, Properties.ShankToHeadRadius }
                        );
                    ModelControllerTools.UnsuppressFeature("REDUCED_SHANK_CUT");
                    break;
                case "Neck":
                    ModelControllerTools.SetSketchDimension("NECK_SHANK_SKETCH",
                        new[] { "CHAMFER_ANGLE", "CHAMFER_WIDTH", "NECK_LENGTH", "NECK_DIAMETER", "BLEND_ANGLE", "TO_HEAD_RADIUS" },
                        new[] { shankChamferAngle, shankChamferWidth, Properties.ShankNeckLength, Properties.ShankNeckDiameter, Properties.ShankBlendAngle, Properties.ShankToHeadRadius }
                        );
                    ModelControllerTools.UnsuppressFeature("NECK_SHANK_CUT");
                    break;
                case "Blend":
                    ModelControllerTools.SetSketchDimension("BLEND_SHANK_SKETCH",
                        new[] { "CHAMFER_ANGLE", "CHAMFER_WIDTH", "BLEND_ANGLE" },
                        new[] { shankChamferAngle, shankChamferWidth, Properties.ShankBlendAngle}
                        );
                    ModelControllerTools.UnsuppressFeature("BLEND_SHANK_CUT");
                    break;
                case "Normal":
                    ModelControllerTools.SetSketchDimension("SHANK_SKETCH",
                        new[] { "CHAMFER_ANGLE", "CHAMFER_WIDTH" },
                        new[] { shankChamferAngle, shankChamferWidth }
                        );
                    ModelControllerTools.UnsuppressFeature("SHANK_CUT");
                    break;
            }
        }
    }
}
