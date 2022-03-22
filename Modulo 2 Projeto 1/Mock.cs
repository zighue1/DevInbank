namespace Modulo_2_Projeto_1
{
    public static class Mock
    {
        public static List<Conta> lista = new List<Conta>();
        public static List<RegistroTransferenciaGeral> listaRegistroTransferencias = new List<RegistroTransferenciaGeral>();
       public enum Respostas : int
        {
            ContaCriada = 1,
            FalhaNaCriacaoDaConta = -1,
        }
        public enum DadosCriarAcc : ushort
        {
            DadosCorretos = 1,
            NomeIncompleto = 2,
            CpfInvalido = 3,
            EnderecoInvalido = 4,
            RendaMensalInvalida = 5,
            AgenciaInvalida = 6,
            SaldoInvalido = 7,

        }
        public enum Agencias : ushort
        {
            Florianopolis = 001,
            SaoJose = 002,
            Biguacu = 003
        }
        public static List<Conta>  InstanciaContas (){
            //"Maria Joana da Silva, 088.269.879.63, rua marechal, 1200, 01, 50000"
            lista.Add(new ContaCorrente("striasdsssasdasdsadsadsng", "08826987963", "asdasdasdasdasdasdasd", 1200, 01, 100));
            lista.Add(new ContaInvestimento("Joao Jose Maria", "08826987963", "Rodovio Virgilho Vargas 737 ", 1200, 01, 1000,1));
            //lista.Add(new ContaCorrente("Hermino Vasconcelos", "08826987963", "Rodovio Virgilho Vargas 737 ", 1200, 01, -1000));
            lista.Add(new ContaPoupanca("Hermino Vasconcelos", "08826987963", "Rodovio Virgilho Vargas 737 ", 1200, 01, 2000));


            return lista;
        }


    }
}
