using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashBank3.Models
{
    public class Cliente
    {
        [Key]
        public string email_proprietario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public Carteira Carteira { get; set; }
    }
}
