﻿using Isoline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public interface ILevelLineView : IView
    {
        List<LevelLine> LevelLines { get; set; }

    }
}
