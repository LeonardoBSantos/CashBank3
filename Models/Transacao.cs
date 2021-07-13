namespace CashBank3.Models
{
    public class Transacao
    {
        public int id { get; set; }
        public string tipo_operacao { get; set; }
        public int fk_id_carteira { get; set; }
        public double valor { get; set; }
        public Carteira Carteira { get; set; }
    }
}