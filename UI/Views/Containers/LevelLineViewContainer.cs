using Isoline;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Views.UC;

namespace UI.Views.Containers
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Ожидание>")]
    public class LevelLineViewContainer : IContainer
    {
        private LevelLine line;
        private ArrayList pointUCs;

        public LevelLineViewContainer(LevelLine line, MouseEventHandler NodeUC_MouseDown, MouseEventHandler NodeUC_MouseMove, MouseEventHandler NodeUC_MouseUp)
        {
            // TODO: Добавить проверку входных параметров.
            this.line = line;

            pointUCs = new ArrayList();

            foreach (var point in this.line.Points)
            {
                PointUC pointUC = new PointUC();
                pointUC.SetLocation(point);
                
                pointUC.MouseDown += NodeUC_MouseDown;
                pointUC.MouseMove += NodeUC_MouseMove;
                pointUC.MouseUp += NodeUC_MouseUp;

                Add(pointUC);
            }
        }

        public LevelLineViewContainer(LevelLine line, MouseEventHandler NodeUC_MouseDown, MouseEventHandler NodeUC_MouseMove, MouseEventHandler NodeUC_MouseUp, KeyEventHandler PointUC_KeyUp) 
            : this(line, NodeUC_MouseDown, NodeUC_MouseMove, NodeUC_MouseUp)
        {
            foreach (PointUC pointUC in pointUCs)
            {
                pointUC.KeyUp += PointUC_KeyUp;
            }
        }


        public LevelLine LevelLine => line;

        public ComponentCollection Components 
        {
            get
            {
                IComponent[] components = new PointUC[pointUCs.Count];
                pointUCs.CopyTo(components);

                return new ComponentCollection(components);
            }
        }

        public void Add(IComponent component)
        {
            // TODO: Добавить проверку входных параметров.
            pointUCs.Add(component);
        }

        public void Add(IComponent component, string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            for (int i = 0; i < pointUCs.Count; ++i)
            {
                IComponent component = (IComponent)pointUCs[i];
                component.Dispose();
            }

            pointUCs.Clear();
        }

        public void Remove(IComponent component)
        {
            // TODO: Добавить проверку входных параметров.
            for (int i = 0; i < pointUCs.Count; ++i)
            {
                if (component.Equals(pointUCs[i]))
                {
                    pointUCs.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
