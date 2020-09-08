namespace LabirintoBacktracking
{
    /// <summary>
    /// Representa um Labirinto bidimensional.
    /// </summary>
    class Labirinto
    {
        public int Linhas { get; }

        public int Colunas { get; }

        public char[,] Dados { get; set; }

        public Labirinto(char[,] dados)
        {
            Dados = dados;
            Linhas = Dados.GetLength(0);
            Colunas = Dados.GetLength(1);
        }
    }
}
