namespace ProgramacaoDoZero.Models
{
    public class Carro : Veiculo
    {
        public Carro() {
            QuantidadeRodas = 4;
        }
        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            injetarCombustivel(4);
        }
        private void injetarCombustivel(int quantidadeCombustivel)

        {
        base.TanqueDeCombustivel = base.TanqueDeCombustivel - quantidadeCombustivel;

        }
    }
}
