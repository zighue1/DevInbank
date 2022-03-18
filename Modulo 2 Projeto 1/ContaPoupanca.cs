namespace Modulo_2_Projeto_1
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cPF, string endereco, double rendaMensal, int agencia, double saldo) : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
        }


        public double SimularRendimento(RendimentoDTO r)
        {
            return Saldo*r.Rentabilidade*r.Meses;
        }
    }
}
