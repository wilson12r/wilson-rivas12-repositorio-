using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Xadiel Martinez Santana 2022-0141
namespace Risxpert
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<Riesgo> listRiesgos = new List<Riesgo>();

            //dataGridView1.DataSource = listRiesgos;
        }
    }
}
