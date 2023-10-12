using RazaPerroPW.Models.misentitades;

namespace RazaPerroPW.Models.viewmodels
{
    public class RazaViewModel
    {
        public int Id { get; set; }
        public string Nombre0 { get; set; } = null!;
        public string Descripcion {  get; set; } = null!;
        public string Nombre2 { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public float PesoMax { get; set; }
        public float PesoMin { get; set; }
        public float AlturaMax { get; set; }
        public float AlturaMin { get; set; }
        public int EsperanzaVida {  get; set; }
        public string Color { get; set; } = null!;
        public string Pelo { get; set;} = null!;
        public string Hosico { get; set; } = null!;
        public string Cola { get;set; } = null!;
        public string Patas { get; set;}  = null!;
        public int NEnergia {  get; set; }
        public int Felicidad { get;set; }
        public int Ejercicio { get; set; }
        public int AmistadDes {  get; set; }
        public int AmistadPerros {  get; set; }
        public int Cepillado { get; set; }
        public int Idperro { get; set; }
        public IEnumerable<Perro> Perros { get; set; } = null!;


    }


}
