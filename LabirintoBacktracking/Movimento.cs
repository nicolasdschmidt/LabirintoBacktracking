using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintoBacktracking
{
    class Movimento
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public int Direcao { get; set; }

        public Movimento (int linha, int coluna, int[,] direcao)
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
