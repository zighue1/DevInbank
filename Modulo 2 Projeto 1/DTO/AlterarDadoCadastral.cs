namespace Modulo_2_Projeto_1
{
    public class AlterarDadoCadastral
    {
        public int NumeroDaConta { get; set; }
        public int IdentificadorDado { get; set; }

        public string NewDado { get; set; }

        public enum Identificadores : int
        {
            nome = 0,
            endereco = 2,
            renda = 3,
            agencia = 4,
        }
        public AlterarDadoCadastral(int numeroDaConta, int identificadorDado, string newDado)
        {
            NumeroDaConta = numeroDaConta;
            IdentificadorDado = identificadorDado;
            NewDado = newDado;
        }
    }
}
