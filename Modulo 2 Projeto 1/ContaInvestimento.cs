namespace Modulo_2_Projeto_1
{
    public class ContaInvestimento : Conta
    {
        public static double LCI = 0.08;
        public static double LCA = 0.09;
        public static double CDB = 0.1;

        public int Tipo { get; set; }   

        
        public ContaInvestimento(string nome, string cPF, string endereco, double rendaMensal, int agencia, double saldo, int tipo) : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            Tipo = tipo;
        }

        public override double Saque(double valor)
        {
            CalculaInvestimento();
            return base.Saque(valor);
        }

        public override void Depositar(double valor, int tipo)
        {
            CalculaInvestimento();
            base.Depositar(valor, tipo);
        }

        public override void Transferencia(double valor, Conta contaDestino)
        {
            CalculaInvestimento();
            base.Transferencia(valor, contaDestino);
        }
        public void CalculaInvestimento()
        {
            DateTime lastUpdate = Transferencias.Last().Data;
            int dias = Convert.ToInt32(DateTime.Now.Subtract(lastUpdate).TotalDays);
            switch (Tipo)
            {
                case (int)InvestimentoDTO.TipoInvestimento.lci:
                    base.Depositar((dias * (LCI / 365) * Saldo),(int) RegistroTransferencia.TiposDeTransferencia.Investimento);
                    break;
                case (int)InvestimentoDTO.TipoInvestimento.lca:
                    base.Depositar((dias * (LCI / 365) * Saldo), (int)RegistroTransferencia.TiposDeTransferencia.Investimento);
                    break;
                case (int)InvestimentoDTO.TipoInvestimento.cdb:
                    base.Depositar((dias * (LCI / 365) * Saldo), (int)RegistroTransferencia.TiposDeTransferencia.Investimento);
                    break;
            }
        }

        public double SimularInvestimento(InvestimentoDTO i)
        {
            switch (i.Tipo)
            {
                case (int)InvestimentoDTO.TipoInvestimento.lci:
                    return i.Valor * (LCI / 365 * i.Meses * 30);
                case (int)InvestimentoDTO.TipoInvestimento.lca:
                    return i.Valor * (LCA / 365 * i.Meses * 30);
                case (int)InvestimentoDTO.TipoInvestimento.cdb:
                    return i.Valor * (CDB / 365 * i.Meses * 30);
            }
            return 0;
        }

    }
}
