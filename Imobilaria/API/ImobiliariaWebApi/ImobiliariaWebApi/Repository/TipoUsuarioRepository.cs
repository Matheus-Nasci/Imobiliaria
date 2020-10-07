using ImobiliariaWebApi.Domains;
using ImobiliariaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        ImobiliariaContext ctx = new ImobiliariaContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            tipoUsuarioBuscado = BuscarPorId(tipoUsuarioAtualizado.IdTipoUsuario);

            tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;

            ctx.TipoUsuario.Update(tipoUsuarioAtualizado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(U => U.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuario = ctx.TipoUsuario.Find(id);

            ctx.TipoUsuario.Remove(tipoUsuario);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
