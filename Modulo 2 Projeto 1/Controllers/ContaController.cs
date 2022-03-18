using Microsoft.AspNetCore.Mvc;
using Modulo_2_Projeto_1.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modulo_2_Projeto_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {

        //INICIALIZAR CONTAS NO MOCK
        [HttpGet("Mock")]
        public List<Conta> Get()
        {
            Mock.InstanciaContas();
            return Mock.lista;
        }

        // PROCURAR DADOS DE UM ID ESPECIFICO
        [HttpGet("{id}")]
        public Conta Get(int id)
        {
            Conta j = Mock.lista[id];
            return j;
        }

        // PROCURAR CONTAS POR TIPO
        [HttpGet("Contas/tipo/{tipoConta}")]
        public List<Conta> GetList([FromRoute] int tipoConta)
        {
            if (tipoConta == 0)
                return Mock.lista;
            if (tipoConta == 1)
            {
                List<Conta> retorno = new List<Conta>();
                foreach (Conta conta in Mock.lista)
                    if (conta.GetType() == typeof(ContaCorrente))
                        retorno.Add(conta);
                return retorno;
            }
            return null;
        }
      
        //DEPOSITAR UM VALOR EM UMA CONTA
        [HttpPost("Deposito/Valor/{Valor}/Conta/{NumeroDaConta}")]
        public int PostDados([FromRoute] int NumeroDaConta, [FromRoute] int Valor)
        {
            foreach (Conta conta in Mock.lista)
                if (conta.NumeroDeConta == NumeroDaConta)
                {
                    conta.Depositar(Valor);
                    return 0;
                }

            return 1;
        }

        //SAQUE UM VALOR DE UMA CONTA
        [HttpPost("Saque/Valor/{Valor}/Conta/{NumeroDaConta}")]
        public int PostSaque([FromRoute] int NumeroDaConta, [FromRoute] int Valor)
        {
            foreach (Conta conta in Mock.lista)
                if (conta.NumeroDeConta == NumeroDaConta)
                {
                    conta.Saque(Valor);
                    return 0;
                }

            return 1;
        }

        //ALTERAR DADOS DO CADASTRO DE UMA CONTA
        [HttpPost("AlterarDadoCadastral/Conta/{Conta}/")]
        public Conta PostDados([FromBody] AlterarDadoCadastral request)
        {
            foreach(Conta conta in Mock.lista)
            {
                if(conta.NumeroDeConta == request.NumeroDaConta)
                {
                    conta.AlterarDadosCadastrais(request);
                    
                }
            }

            //Conta c = new Conta();
            return null;
        }

        //CRIAR CONTA BANCARIA
        [HttpPost("Bancaria/tipo/{tipoConta}")]
        public int PostTeste([FromBody] ContaDTO value,[FromRoute]int tipoConta)
        {
            try
            {
                if (Conta.validaDados(value) == 1)
                {
                    if (tipoConta == 1)
                    {
                        Conta c = new ContaCorrente(value.Nome, value.CPF, value.Endereco, value.RendaMensal, value.Agencia, 0);
                        Mock.lista.Add(c);
                        return c.NumeroDeConta;
                    }
                    if (tipoConta == 2)
                    {
                        // Conta c = new ContaCorrente(value.Nome, value.CPF, value.Endereco, value.RendaMensal, value.Agencia, 0);
                        // Mock.lista.Add(c);
                        // return c.NumeroDeConta;
                    }
                    if (tipoConta == 3)
                    {
                        // Conta c = new ContaCorrente(value.Nome, value.CPF, value.Endereco, value.RendaMensal, value.Agencia, 0);
                        // Mock.lista.Add(c);
                        // return (int)Mock.Respostas.ContaCriada;
                    }

                }
            }catch (Exception e)
            {
                Console.WriteLine(e);
                return (int)Mock.Respostas.FalhaNaCriacaoDaConta;
            }
            return (int)Mock.Respostas.FalhaNaCriacaoDaConta;  
        }

        
        [HttpPost("Transferencia")]
        public int PostTransferencia([FromBody] TransferenciaDTO dados)
        {
            Conta Origem = null;
            Conta Destino = null;
            foreach (Conta c in Mock.lista)
            {
                if(c.NumeroDeConta == dados.ContaOrigem)
                    Origem = c;
                if(c.NumeroDeConta == dados.ContaDestino)
                    Destino = c;
            }
            try
            {
                Origem.Transferencia(dados.Valor, Destino);
                return 0;
            }
            catch(Exception ex)
            {
                return 1;
            }   
        }

        [HttpGet("Negativados")]
        public List<Conta> GetNegativados()
        {
            List<Conta> Negativados = new List<Conta>();
            foreach (Conta c in Mock.lista)
                if(c.Saldo <0)
                    Negativados.Add(c);   
            return Negativados;
        }

        [HttpPost("RendimentoPoupanca/Conta/{NumeroConta}")]
        public double PostRendimentoPoupanca(RendimentoDTO r, int NumeroConta)
        {
            foreach (Conta c in Mock.lista)
                if (c.GetType() == typeof(ContaPoupanca) && c.NumeroDeConta == NumeroConta)
                    return ((ContaPoupanca)c).SimularRendimento(r);

            return 0;
        }

        [HttpPost("RendimentoInvestimento")]
        public double PostRendimentoInvestimento(InvestimentoDTO i, int NumeroConta)
        {
            foreach (Conta c in Mock.lista)
                if (c.GetType() == typeof(ContaInvestimento) && c.NumeroDeConta == NumeroConta)
                    return ((ContaInvestimento)c).SimularInvestimento(i);
            return 0;
        }
    }
}
