using ImobiliariaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Interfaces
{
    interface IAluguelRepository
    {
        List<Aluguel> Listar();

        Aluguel BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Aluguel aluguelAtualizado);

        void Cadastrar(Aluguel novoAluguel);
    }
}
