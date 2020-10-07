using System;
using System.Collections.Generic;

namespace ImobiliariaWebApi.Domains
{
    public partial class Aluguel
    {
        public int IdAluguel { get; set; }
        public string Endereco { get; set; }
        public string Valor { get; set; }
        public string DataVencimento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdSituacao { get; set; }

        public Situacao IdSituacaoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
