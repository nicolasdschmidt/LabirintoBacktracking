using System;

namespace LabirintoBacktracking
{
    class Pilha<X> : ICloneable
    {
        Lista<X> lista = new Lista<X>();

        public Pilha() {}

        public bool Vazia()
        {
            return lista.Vazia();
        }

        public X Espiar()
        {
            return lista.GetFim();
        }

        public X Desempilhar()
        {
            X ret = lista.GetFim();
            lista.RemoverDoFim();
            return ret;
        }

        public void Adicionar(X i)
        {
            lista.InserirNoFim(i);
        }

        public int GetTamanho()
        {
            return lista.GetQtd();
        }

        public Lista<X> ParaLista()
        {
            Lista<X> ret = new Lista<X>();

            int tamanho = lista.GetQtd();

            for (int i = 0; i < tamanho; i++)
            {
                ret.InserirNoFim(lista.Get(i));
            }

            return ret;
        }

        public string ToString()
        {
            return lista.ToString();
        }

        public object Clone()
        {
            Pilha<X> ret = new Pilha<X>();

            int tamanho = lista.GetQtd();

            for (int i = 0; i < tamanho; i++)
            {
                ret.Adicionar(lista.Get(i));
            }

            return ret;
        }
    }
}
