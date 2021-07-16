using System.Collections.Generic;

namespace CashBank3.Models
{
    public class Carteira
    {
        public int id_carteira { get; set; }
        public string fk_email_proprietario { get; set; }
        public double saldo { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Transacao> Transacao { get; set; }
    }
}