namespace ProgramacaoDoZero.Models
{
    public class Moto : Veiculo
    {
        public Moto() {
            quantidadeRodas = 2;
            TanqueDeCombustivel = 16;
        }

        public override void Acelerar()
        {
            injetarCombustivel(1);
        }

        private void injetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueDeCombustivel = base.TanqueDeCombustivel - quantidadeCombustivel;
        }
        public int quantidadeRodas { get; set; }
    }
}
