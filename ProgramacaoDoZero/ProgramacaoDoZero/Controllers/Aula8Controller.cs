using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        
        public string OlaMUndo()
        {
            var mensagem = "Olá Mundo via API";
            return mensagem;
        }
        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string olaMUndoPersonlizado(string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;
            return mensagem;
        }

        [Route("calcular")]
        [HttpGet]
        public string calcular( int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "A soma é " + soma;
            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string media(int valor1, int valor2)
        {
            var media = (valor1 + valor2) / 2;
            var mensagem = "A média é " + media;
            return mensagem;
           
        }

        [Route("terreno")]
        [HttpGet]
        public string terreno(int largura, int cumprimento, int valor)
        {
            var area = largura * cumprimento;
            var areaMensagem = "O terreno tem " + area + " m2";
            var preco = area * valor;
            var precoMensagem = "O valor total do terreno é R$ " + preco;

            return areaMensagem;
            
        }
        [Route("troco")]
        [HttpGet]
        public string troco(int valorProduto, int qtdProduto, int valorDoCliente)
        {
            var totalDaCompra = valorProduto * qtdProduto;
            var troco = valorDoCliente - totalDaCompra;
            var mensagem = "O troco será " + troco;
            return mensagem;
        }

        [Route("salario")]
        [HttpGet]
        public string pagamento(int valorPorHora, int horasTrabalhadas)
        {
            var salario = valorPorHora * horasTrabalhadas;
            var mensagem = "O funcionario irá receber ao final do mês R$ " + salario;
            return mensagem;
        }


        [Route("combustivel")]
        [HttpGet]

        public string combustivel(int distancia, int combustivel )
        {
            var consumoMedio = distancia / combustivel;
            var mensagem = "O consumo médio foi de " + consumoMedio + " km por litro";
            return mensagem;
        }

    }
}
