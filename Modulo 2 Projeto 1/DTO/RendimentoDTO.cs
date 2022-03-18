namespace Modulo_2_Projeto_1
{
    public class RendimentoDTO
    {
        public int Meses { get; set; }
        public double Rentabilidade { get; set; }

        public RendimentoDTO(int meses, double rentabilidade)
        {
            Meses = meses;
            Rentabilidade = rentabilidade;
        }
    }
}
