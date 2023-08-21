using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SW_Console_Controller_V1.Lib
{
    internal class ModelControllerTools
    {
        public static ModelDoc2 Model;
        public static ModelDocExtension ModelExtension;
        public static SelectionMgr SelectionManager;
        static public void SelectFeature(string name, string type)
        {
            Model.Extension.SelectByID2(name, type, 0, 0, 0, false, 0, null, 0);
        }
        
        static public void SetSketchDimension(string sketchName, string dimensionName, double dimension)
        {
            Model.Extension.SelectByID2(sketchName, "SKETCH", 0, 0, 0, false, 0, null, 0);
            Feature feature = SelectionManager.GetSelectedObject6(1, -1);
            Dimension dim = feature.Parameter(dimensionName);
            dim.SetValue3(dimension, 0, null);
            Model.ClearSelection2(true);
        }

        static public void SetSketchDimension(string sketchName, Dictionary<string, double> dimensions)
        {
            Model.Extension.SelectByID2(sketchName, "SKETCH", 0, 0, 0, false, 0, null, 0);
            Feature feature = SelectionManager.GetSelectedObject6(1, -1);
            foreach (KeyValuePair<string, double> entry in dimensions)
            {
                Dimension dim = feature.Parameter(entry.Key);
                dim.SetValue3(entry.Value, 0, null);
            }
            Model.ClearSelection2(true);
        }

        static public void SetSketchDimension(string sketchName, string[] dimensionNames, double[] dimensions)
        {
            if (dimensionNames.Length != dimensions.Length) return;
            Model.Extension.SelectByID2(sketchName, "SKETCH", 0, 0, 0, false, 0, null, 0);
            Feature feature = SelectionManager.GetSelectedObject6(1, -1);
            for (int i = 0; i < dimensionNames.Length; i++)
            {
                Dimension dim = feature.Parameter(dimensionNames[i]);
                dim.SetValue3(dimensions[i], 0, null);
            }
            Model.ClearSelection2(true);
        }

        static public void UnsuppressFeature(string featureName)
        {
            Model.Extension.SelectByID2(featureName, "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            Model.EditUnsuppress2();
            Model.ClearSelection2(true);
        }
    }
}
