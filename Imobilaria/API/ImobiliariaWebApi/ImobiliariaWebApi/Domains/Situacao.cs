using System;
using System.Collections.Generic;

namespace ImobiliariaWebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Aluguel = new HashSet<Aluguel>();
        }

        public int IdSituacao { get; set; }
        public string TipoSituacao { get; set; }

        public ICollection<Aluguel> Aluguel { get; set; }
    }
}
