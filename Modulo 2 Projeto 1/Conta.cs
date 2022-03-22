using Modulo_2_Projeto_1.DTO;

namespace Modulo_2_Projeto_1
{
    public abstract class Conta
    {
        public Conta(string nome, string cPF, string endereco, double rendaMensal, int agencia, double saldo)
        {
           
                Nome = nome;
                CPF = cPF;
                Endereco = endereco;
                RendaMensal = rendaMensal;
                NumeroDeConta = IdConta++;
                Agencia = agencia;
                Saldo = saldo;
            


        }
        private static int IdConta = 0;
        public string Nome { get; private set; }
    
        public string CPF { get; private set; }
        public string Endereco { get; private set; }
   
        public double RendaMensal { get; private set; }
  
        public int NumeroDeConta { get; private set; }
        public int Agencia { get; private set; }
      
        public double Saldo { get; protected set; }

        public List<RegistroTransferencia> Transferencias { get; protected set; } = new List<RegistroTransferencia>();
        public virtual double Saque(double valor) {
            if(valor < Saldo)
            {
                Saldo -= valor;
                Transferencias.Add(new RegistroTransferencia((int)RegistroTransferencia.TiposDeTransferencia.Saque, NumeroDeConta, valor));
                return 1;
            }
                
            return 0;
        }
        public virtual void Depositar(double valor, int tipo) {
            Saldo += valor;
            Transferencias.Add(new RegistroTransferencia((int)RegistroTransferencia.TiposDeTransferencia.Deposito, NumeroDeConta, valor));

        }
     
        public void Depositar(double valor, Conta Origem)
        {
            Saldo += valor;
            Transferencias.Add(new RegistroTransferencia((int)RegistroTransferencia.TiposDeTransferencia.Transferencia, Origem.NumeroDeConta, NumeroDeConta, valor));
        }
        public virtual double VerificarSaldo() { return Saldo; }
        public virtual List<RegistroTransferencia> Extrato() {
            return Transferencias;
        }
        public virtual void Transferencia(double valor, Conta contaDestino)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday || contaDestino.NumeroDeConta == NumeroDeConta)
                return;
            if (valor < Saldo)
            {
                Saldo -= valor;
                contaDestino.Depositar(valor, this);
                Transferencias.Add(new RegistroTransferencia((int)RegistroTransferencia.TiposDeTransferencia.Transferencia, NumeroDeConta,contaDestino.NumeroDeConta, valor));
            }
        }
        public virtual void AlterarDadosCadastrais(AlterarDadoCadastral request) {
            switch (request.IdentificadorDado)
            {
                case (int)AlterarDadoCadastral.Identificadores.nome:
                    Nome = request.NewDado;
                    break;
                case (int)AlterarDadoCadastral.Identificadores.endereco:
                    Endereco = request.NewDado;
                    break;
                case (int)AlterarDadoCadastral.Identificadores.renda:
                    RendaMensal = Convert.ToDouble(request.NewDado);
                    break;
                case (int)AlterarDadoCadastral.Identificadores.agencia:
                    Agencia = Convert.ToInt32(request.NewDado);
                    break;
            }

        }

        public static int validaDados(ContaDTO dados) {
           
            if (dados.Nome.Length < 10)
                return (int)Mock.DadosCriarAcc.NomeIncompleto;

            if(!Utils.IsCpf(dados.CPF))
                return (int)(Mock.DadosCriarAcc.CpfInvalido);
            if (dados.Endereco.Length < 10)
                return(int)(Mock.DadosCriarAcc.EnderecoInvalido);

            // RendaMensal
            try
            {
                
                if(Convert.ToInt32(dados.RendaMensal) < 0)
                    return (int)(Mock.DadosCriarAcc.RendaMensalInvalida);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (int)(Mock.DadosCriarAcc.RendaMensalInvalida);
            }



            // Agencia;
            if (Convert.ToInt32(dados.Agencia) >3 || Convert.ToInt32(dados.Agencia) < 0)
                return (int)(Mock.DadosCriarAcc.AgenciaInvalida);
     
     

            return 1; 
        }
    }
}
