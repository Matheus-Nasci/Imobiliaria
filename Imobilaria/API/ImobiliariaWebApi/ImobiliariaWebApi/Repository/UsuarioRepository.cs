using ImobiliariaWebApi.Domains;
using ImobiliariaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaWebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ImobiliariaContext ctx = new ImobiliariaContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado = BuscarPorId(usuarioAtualizado.IdUsuario);

            usuarioBuscado.Nome = usuarioAtualizado.Nome;

            usuarioBuscado.Email = usuarioAtualizado.Email;

            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            usuarioBuscado.Telefone = usuarioAtualizado.Telefone;

            usuarioBuscado.Cpf = usuarioAtualizado.Cpf;

            ctx.Usuario.Update(usuarioAtualizado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return usuarioBuscado;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(usuario);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
