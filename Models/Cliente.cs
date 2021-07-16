namespace CashBank3.Models
{
    public class Cliente
    {
        public string email_proprietario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public Carteira Carteira { get; set; }
    }
}
