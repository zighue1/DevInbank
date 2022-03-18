namespace Modulo_2_Projeto_1
{
    public class RegistroTransferencia
    {
        public int NumeroContaOrigem { get; set; }
        public int? NumeroContaDestino { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public static int ID = 0;

        public int tipo { get; set; }
        public enum TiposDeTransferencia : ushort
        {
            Transferencia = 1,
            Saque = 2,
            Deposito = 3,
        }


        //TIPO 1 = TRANSFERENCIA DE CONTA
        public RegistroTransferencia(int tipo, int numeroContaOrigem, int numeroContaDestino, double valor)
        {
            this.tipo = tipo;
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
            Data = DateTime.Now;
            ID = ID++;
        }

        //TIPO 2 = SAQUE // TIPO 3 = DEPOSITO
        public RegistroTransferencia(int tipo, int numeroContaOrigem, double valor)
        {
            this.tipo = tipo;
            NumeroContaOrigem = numeroContaOrigem;
            Valor = valor;
            Data = DateTime.Now;
            ID = ID++;
        }
    }
}
