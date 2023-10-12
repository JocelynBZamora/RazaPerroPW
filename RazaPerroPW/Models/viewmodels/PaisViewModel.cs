using RazaPerroPW.Models.misentitades;

namespace RazaPerroPW.Models.viewmodels
{
    public class PaisViewModel
    {
        public List<Pais> pais { get; set; } = null!;

    }
    public class Pais 
    {
        public string NombrePais { get; set; } = null!;
        public int IdRaza { get; set; }
        public IEnumerable<Perro> perros { get; set;} = null!;
        
    }



}
