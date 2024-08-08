using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
         var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Vermelha";
            meuVeiculo.Marca = "Yamaha";
            meuVeiculo.Modelo = "XT 660";
            meuVeiculo.Placa = "KAZ 2Y5";
            meuVeiculo.Pneus = "Pirelli";
            meuVeiculo.Ano = "2018";
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]
        public object obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Cor = "Preto";
            meuCarro.Marca = "Chevrollet";
            meuCarro.Modelo = "Camaro";
            meuCarro.Ano = "2024";
            meuCarro.Placa = "KAZ 2Y5";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public object obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Cor = "Vermelha";
            minhaMoto.Marca = "Yamaha";
            minhaMoto.Modelo = "XT 660";
            minhaMoto.Placa = "KAZ 2Y5";
            minhaMoto.Pneus = "Pirelli";
            minhaMoto.Ano = "2018";

            minhaMoto.Acelerar();

            return minhaMoto;

        }
    }
}
