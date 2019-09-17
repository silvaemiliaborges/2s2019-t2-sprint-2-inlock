using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Estudio = new HashSet<Estudio>();
        }

        public int Idusuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Idperfil { get; set; }

        public Perfil IdperfilNavigation { get; set; }
        public ICollection<Estudio> Estudio { get; set; }
    }
}
