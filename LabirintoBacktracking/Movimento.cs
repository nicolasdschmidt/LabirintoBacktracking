using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintoBacktracking
{
    class Movimento
    {
        public int AlteradorLinha { get; set; }
        public int AlteradorColuna { get; set; }

        public Movimento (int linha, int coluna)
        {
            AlteradorLinha = linha;
            AlteradorColuna = coluna;
        }
    }
}
