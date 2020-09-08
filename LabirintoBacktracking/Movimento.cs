namespace LabirintoBacktracking
{
    /// <summary>
    /// Representa um passo de determinada tentativa de solucionar um Labirinto.
    /// </summary>
    class Movimento
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public int Direcao { get; set; }

        public Movimento(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Movimento(int linha, int coluna, int direcao)
        {
            Linha = linha;
            Coluna = coluna;
            Direcao = direcao;
        }

        public override string ToString()
        {
            return "[" + Linha + "," + Coluna + "]";
        }
    }
}
