using System;
using System.Collections.Generic;

namespace ImobiliariaWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Aluguel = new HashSet<Aluguel>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Aluguel> Aluguel { get; set; }
    }
}
