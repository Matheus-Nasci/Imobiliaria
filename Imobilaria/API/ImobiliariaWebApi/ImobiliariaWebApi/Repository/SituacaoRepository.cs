using ImobiliariaWebApi.Domains;
using ImobiliariaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Repository
{
    public class SituacaoRepository : ISituacaoRepository
    {
        ImobiliariaContext ctx = new ImobiliariaContext();

        public void Atualizar(int id, Situacao situacaoAtualizado)
        {
            Situacao situacaoBuscada = ctx.Situacao.Find(id);

            situacaoBuscada = BuscarPorId(situacaoAtualizado.IdSituacao);

            situacaoBuscada.TipoSituacao = situacaoAtualizado.TipoSituacao;

            ctx.Situacao.Update(situacaoAtualizado);

            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacao.FirstOrDefault(s => s.IdSituacao == id);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacao.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Situacao situacao = ctx.Situacao.Find(id);

            ctx.Situacao.Remove(situacao);

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacao.ToList();
        }
    }
}
