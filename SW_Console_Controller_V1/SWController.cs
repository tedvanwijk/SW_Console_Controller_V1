using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SW_Console_Controller_V1.Controllers;
using SW_Console_Controller_V1.Lib;
using System.IO;

namespace SW_Console_Controller_V1
{
    internal class SWController
    {
        private SldWorks _swApp;
        private ModelDoc2 _swModel;
        private ModelDocExtension _swModelExtension;
        private SelectionMgr _selectionMgr;
        private Properties _properties;
        private int _fileError;
        private int _fileWarning;
        private int _saveError;
        private int _saveWarning;

        // Controllers
        private ShankController _shankController;
        private BodyController _bodyController;

        public SWController(string fileName, Properties properties)
        {
            string oldDocumentPath = Path.Combine(fileName, "TOOL_V2_DONOTMODIFY.SLDPRT");
            string newDocumentPath = Path.Combine(fileName, "TOOL_V2_GENERATED.SLDPRT");
            _properties = properties;
            _swApp = new SldWorks();
            Console.WriteLine(Path.Combine(fileName, "TOOL_V2_DONOTMODIFY.SLDPRT"));
            _swApp.CopyDocument(
                oldDocumentPath,
                newDocumentPath,
                new string[] { },
                new string[] { },
                1);
            _swModel = _swApp.OpenDoc6(newDocumentPath, 1, 1, "", ref _fileError, ref _fileWarning);
            //_swModel = (ModelDoc2)_swApp.GetOpenDocumentByName(Path.Combine(fileName, "TOOL_V2_GENERATED.SLDPRT"));
            _swModelExtension = _swModel.Extension;
            _selectionMgr = _swModel.SelectionManager;
            ModelControllerTools.Model = _swModel;
            ModelControllerTools.ModelExtension = _swModelExtension;
            ModelControllerTools.SelectionManager = _selectionMgr;

            SetReferences();
            _shankController = new ShankController(properties, _swModel);
            _bodyController = new BodyController(properties, _swModel);

            _swModel.ForceRebuild3(false);
            _swModel.Save3(1, ref _saveError, ref _saveWarning);
            //_swApp.CloseDoc(newDocumentPath);
        }

        private void SetReferences()
        {
            ModelControllerTools.SetSketchDimension("LENGTH_REF",
                new[] { "LOA", "LOC", "LOF", "BODY_LENGTH" },
                new[] { _properties.LOA, _properties.LOC, _properties.LOF, _properties.BodyLength }
                );

            double maxDiameter = Math.Max(_properties.ShankDiameter, _properties.ToolDiameter);
            double maxDiameterOffset = maxDiameter + 0.5f;
            Dictionary<string, double> refDimensions = new Dictionary<string, double>
            {
                { "MAX_DIAMETER", maxDiameter },
                { "MAX_DIAMETER_OFFSET", maxDiameterOffset },
                { "MAX_BODY_DIAMETER", _properties.ToolDiameter }
            };
            if (_properties.ShankType == "Reduced")
            {
                refDimensions.Add("MAX_SHANK_DIAMETER", _properties.ShankDiameter + 2 * _properties.ShankToHeadRadius);
            } else
            {
                refDimensions.Add("MAX_SHANK_DIAMETER", _properties.ShankDiameter);
            }
            ModelControllerTools.SetSketchDimension("DIAMETER_REF", refDimensions);

            if (maxDiameter > _properties.ToolDiameter)
            {
                ModelControllerTools.UnsuppressFeature("BODY_PROFILE_CUT");
            }
        }
    }
}
