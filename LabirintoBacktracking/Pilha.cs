using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintoBacktracking
{
    class Pilha<X>
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
    }
}
