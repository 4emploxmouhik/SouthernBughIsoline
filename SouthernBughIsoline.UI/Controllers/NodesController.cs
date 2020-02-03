using Isoline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SouthernBughIsoline.UI.Controllers
{
    public class NodesController : IController
    {
        MapController mapController;

        public NodesController()
        {
        }

        public NodesController(MapController mapController)
        {
            this.mapController = mapController;
        }

        public DataTable LoadNodes()
        {
            if (mapController == null)
            {
                throw new NullReferenceException("Map controller is null.");
            }

            DataTable nodesTable = new DataTable();
            nodesTable.Columns.Add("Number", typeof(int));
            nodesTable.Columns.Add("Name", typeof(string));
            nodesTable.Columns.Add("Level", typeof(float));

            for (int i = 0; i < mapController.Grid.Nodes.Count; i++)
            {
                Node node = mapController.Grid.Nodes[i];

                nodesTable.Rows.Add(node.Id, node.Name, node.Level);
            }

            return nodesTable;
        }

        public void SaveNodesValues(DataGridView dgv)
        {
            if (mapController == null)
            {
                throw new NullReferenceException("Map controller is null.");
            }

            List<(float Level, int Id)> levelsChangesKit = new List<(float Level, int Id)>();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                float level = (float)dgv.Rows[i].Cells["Level"].Value;
                int id = (int)dgv.Rows[i].Cells["Number"].Value;

                levelsChangesKit.Add((level, id));
            }

            mapController.ChangeLevelOnNodes(levelsChangesKit);
        }

    }
}
