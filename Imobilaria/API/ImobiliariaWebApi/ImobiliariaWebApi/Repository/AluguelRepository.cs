using ImobiliariaWebApi.Domains;
using ImobiliariaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Repository
{
    public class AluguelRepository : IAluguelRepository
    {
        ImobiliariaContext ctx = new ImobiliariaContext();

        public void Atualizar(int id, Aluguel aluguelAtualizado)
        {
            Aluguel aluguelBuscado = ctx.Aluguel.Find(id);

            aluguelBuscado = BuscarPorId(aluguelAtualizado.IdAluguel);

            aluguelBuscado.Endereco = aluguelAtualizado.Endereco;

            aluguelBuscado.Valor = aluguelAtualizado.Valor;

            aluguelBuscado.DataVencimento = aluguelAtualizado.DataVencimento;

            aluguelBuscado.IdUsuario = aluguelAtualizado.IdUsuario;

            aluguelBuscado.IdSituacao = aluguelAtualizado.IdSituacao;

            ctx.Aluguel.Update(aluguelAtualizado);

            ctx.SaveChanges();   
        }

        public Aluguel BuscarPorId(int id)
        {
            return ctx.Aluguel.FirstOrDefault(a => a.IdAluguel == id);
        }

        public void Cadastrar(Aluguel novoAluguel)
        {
            ctx.Aluguel.Add(novoAluguel);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Aluguel aluguel = ctx.Aluguel.Find(id);

            ctx.Aluguel.Remove(aluguel);

            ctx.SaveChanges();
        }

        public List<Aluguel> Listar()
        {
            return ctx.Aluguel
                .Select(a => new Aluguel()
                {
                    IdAluguel = a.IdAluguel,
                    Endereco = a.Endereco,
                    Valor = a.Valor,
                    DataVencimento = a.DataVencimento,
                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = a.IdSituacaoNavigation.IdSituacao,
                        TipoSituacao = a.IdSituacaoNavigation.TipoSituacao
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        Nome = a.IdUsuarioNavigation.Nome,
                        Cpf = a.IdUsuarioNavigation.Cpf,
                        Telefone = a.IdUsuarioNavigation.Telefone,
                        Email = a.IdUsuarioNavigation.Email,
                        Senha = a.IdUsuarioNavigation.Senha,
                    },

                }).ToList();
        }
    }
}
