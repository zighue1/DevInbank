namespace Modulo_2_Projeto_1
{
    public class InvestimentoDTO
    {
        public double Valor { get; set; }
        public int Meses { get; set; }
        public int Tipo { get; set; }

        public enum TipoInvestimento : int
        {
            lci = 0,
            lca = 1,
            cdb = 2,
        }
        public InvestimentoDTO(double valor, int meses, int tipo)
        {
            Valor = valor;
            Meses = meses;
            Tipo = tipo;

        }
    }
}
