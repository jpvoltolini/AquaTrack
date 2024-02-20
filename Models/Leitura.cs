namespace AquaTrack.Models
{
    public class Leitura
    {
        public int Id { get; set; }
        public int Apartamento { get; set; }
        public string Bloco { get; set; }
        public int LeituraAnterior { get; set;}
        public int LeituraAtual { get; set; }
        public int Consumo { get; set; }
        //public DateTime DataLeitura { get; set; }
    }


}
