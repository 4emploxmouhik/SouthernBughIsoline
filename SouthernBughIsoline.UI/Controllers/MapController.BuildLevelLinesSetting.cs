using System.Drawing;

namespace SouthernBughIsoline.UI.Controllers
{
    public partial class MapController
    {
        public struct BuildLevelLinesSetting
        {
            public bool IsDrawLevelValues { get; set; }
            public bool IsDrawNodeValues { get; set; }

            public bool IsUsedPointsOnDiagonals { get; set; }
            public Color[] ColorsOfLines { get; set; }
            public float[] LevelsOfLines { get; set; }

        }
    }
}
