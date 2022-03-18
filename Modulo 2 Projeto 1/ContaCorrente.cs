namespace Modulo_2_Projeto_1
{
    public class ContaCorrente : Conta
    {
        public double Limite { get; private set; }   
        public ContaCorrente(string nome, string cPF, string endereco, double rendaMensal, int agencia, double saldo) : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            Limite = rendaMensal * 0.1;
        }

        public override double Saque(double valor)
        {
            if(valor < Saldo + Limite)
            {

                Saldo -= valor;
                Transferencias.Add(new RegistroTransferencia((int)RegistroTransferencia.TiposDeTransferencia.Saque, NumeroDeConta, valor));
                return 1;
            }
                
            return 0;
        }
    }
}
