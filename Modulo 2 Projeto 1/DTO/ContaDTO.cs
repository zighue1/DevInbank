namespace Modulo_2_Projeto_1.DTO
{
    public class ContaDTO
    {
        public ContaDTO(string nome, string cPF, string endereco, double rendaMensal, int agencia, int tIPO)
        {
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
            tipoInvestimento = tIPO;
        }

        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string Endereco { get;  set; }
        public double RendaMensal { get;  set; }
    
        public int Agencia { get;  set; }

        public int tipoInvestimento { get; set; }
    }
}
