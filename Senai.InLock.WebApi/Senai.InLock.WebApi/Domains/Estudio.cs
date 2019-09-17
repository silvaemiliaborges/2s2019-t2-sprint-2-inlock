using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogo = new HashSet<Jogo>();
        }

        public int Idestudio { get; set; }
        public string Estudio1 { get; set; }
        public DateTime Datacriacao { get; set; }
        public int? Idusuario { get; set; }

        public Usuario IdusuarioNavigation { get; set; }
        public ICollection<Jogo> Jogo { get; set; }
    }
}
