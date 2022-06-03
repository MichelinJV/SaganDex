using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaganDex.Entidades
{
    public class ExoPlanetas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Constelação")]
        public string Constelacao { get; set; }
        [Display(Name = "Estrela-Mãe")]
        public string EstrelaMae { get; set; }
        public string Categoria { get; set; }
        [Display(Name = "Distância (anos-luz)")]
        public int Distancia { get; set; }
    }
}
