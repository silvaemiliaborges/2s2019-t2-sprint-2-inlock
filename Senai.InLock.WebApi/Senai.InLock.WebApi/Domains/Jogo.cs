using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Jogo
    {
        public int Idjogo { get; set; }
        public string Jogo1 { get; set; }
        public string Descricao { get; set; }
        public DateTime Datalancamento { get; set; }
        public int Valor { get; set; }
        public int? Idestudio { get; set; }

        public Estudio IdestudioNavigation { get; set; }
    }
}
