namespace ProgramacaoDoZero.Models
{
    public class Veiculo
    {
        //construtor
        public Veiculo() {
            TanqueDeCombustivel = 40;
        }

        //atributos ou propriedades
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Pneus { get; set; }
        public string Ano { get; set; }
        public int TanqueDeCombustivel { get; set; }

        //metodos
        public virtual void Acelerar()
        {
            injetarCombustivel(1);
        }

        public void Frear()
        {

        }
        private void injetarCombustivel(int quantidadeCombustivel)
        {
            TanqueDeCombustivel = TanqueDeCombustivel - quantidadeCombustivel;
        }
    }
}
