namespace Modulo_2_Projeto_1
{
    public class ContaInvestimento : Conta
    {
        public static double LCI = 0.08;
        public static double LCA = 0.09;
        public static double CDB = 0.1;
        public ContaInvestimento(string nome, string cPF, string endereco, double rendaMensal, int agencia, double saldo) : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
        }


      
        public double SimularInvestimento(InvestimentoDTO i)
        {
            switch (i.Tipo)
            {
                case (int)InvestimentoDTO.TipoInvestimento.lci:
                    return i.Valor * (LCI / 365 * i.Meses * 30);
                    break;
                case (int)InvestimentoDTO.TipoInvestimento.lca:
                    return i.Valor * (LCA / 365 * i.Meses * 30);
                    break;
                case (int)InvestimentoDTO.TipoInvestimento.cdb:
                    return i.Valor * (CDB / 365 * i.Meses * 30);
                    break;
            }
            return 0;
        }

    }
}
