using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LabirintoBacktracking
{
    class Labirinto
    {
        public int Linhas { get; }

        public int Colunas { get; }

        public char[,] Dados { get; set; }

        public Labirinto(char[,] dados)
        {
            Dados = dados;
            Linhas = dados.GetLength(0);
            Colunas = dados.GetLength(1);
        }
    }
}
