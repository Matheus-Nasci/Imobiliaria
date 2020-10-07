using ImobiliariaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> Listar();

        Situacao BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Situacao situacaoAtualizado);

        void Cadastrar(Situacao novaSituacao);
    }
}
