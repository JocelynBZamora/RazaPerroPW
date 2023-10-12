namespace RazaPerroPW.Models.viewmodels
{
    public class IndexViewModel
    {
      public List<Perros> perro { get; set; } = null!;

    }
    public class Perros 
    {
        public int Id { get; set; } 
        public string Nombre { get; set;} = null!;
    }
}
