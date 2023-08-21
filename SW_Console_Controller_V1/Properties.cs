using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Console_Controller_V1
{
    internal class Properties
    {
        public string ToolType { get; set; }

        // Reference Dimensions
        public double LOA { get; set; }
        public double LOF { get; set; }
        public double LOC { get; set; }
        public double BodyLength { get; set; }
        public double ToolDiameter { get; set; }

        // General Shank
        public double ShankDiameter { get; set; }
        public string ShankType { get; set; }
        public double ShankToHeadRadius { get; set; }
        public double ShankBlendAngle { get; set; }
        public double ShankNeckLength { get; set; }
        public double ShankNeckDiameter { get; set; }

        // General Tool
        public string FluteSeries { get; set; }
        public bool CoolantThrough { get; set; }

        // EM
        public double CornerRadius { get; set; }
        public double CornerChamferAngle { get; set; }
        public double CornerChamferWidth { get; set; }
        public bool BallNose { get; set; }

        // Drill
        public double PointAngle { get; set; }
        public bool LOFFromPoint { get; set; }
    }
}
