using SouthernBughIsoline.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthernBughIsoline.UI.Views
{
    public interface IView
    {
        IController Controller { get; }
    }
}
