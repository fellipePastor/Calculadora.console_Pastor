namespace Domain
{
    public class OperacaoHistorico
    {
        public int Id { get; set; }
        public string NomeOperacao { get; set; }
        public decimal Resultado { get; set; }
        public DateTime DataHoraOperacao { get; set; }
    }
}