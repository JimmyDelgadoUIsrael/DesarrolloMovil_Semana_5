using SQLite;

namespace jdelgadoS5A.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nombre { get; set; }


    }
}
