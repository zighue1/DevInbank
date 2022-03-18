namespace Modulo_2_Projeto_1.DTO
{
    public class TransferenciaDTO
    {
        public TransferenciaDTO(int contaOrigem, int contaDestino, double valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }

        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public double Valor { get; set; }


    }
}
