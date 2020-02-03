using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Controllers;

namespace UI.Views
{
    public interface IView
    {
        IController Controller { get; }
    }
}
