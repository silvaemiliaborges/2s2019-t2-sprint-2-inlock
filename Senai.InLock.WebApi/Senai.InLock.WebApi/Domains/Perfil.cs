using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idperfil { get; set; }
        public string Perfil1 { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
