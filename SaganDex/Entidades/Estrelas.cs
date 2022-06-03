using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaganDex.Entidades
{
    public class Estrelas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Designação")]
        public string Designacao { get; set; }
        [Display(Name = "Constelação")]
        public string Constelacao { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Distância (anos-luz)")]
        public int Distancia { get; set; }
    }
}
