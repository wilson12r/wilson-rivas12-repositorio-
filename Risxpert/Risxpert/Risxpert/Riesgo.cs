using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Xadiel Martinez Santana 2022-0141
namespace Risxpert
{
    internal class Riesgo
    {
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public int IdData { get; set; }
        public string Analista { get; set; }
        public string Activo { get; set; }
        public string Riesgoo { get; set; }
        public string Daño { get; set; }

        public int S { get; set; }
        public int F { get; set; }
        public int P { get; set; }
        public int A { get; set; }
        public int V { get; set; }
        public int E { get; set; }

        public int I { get; set; }
        public int D { get; set; }
        public int C { get; set; }
        public int Pb { get; set; }
        public int ER { get; set; }
        
    }
}
