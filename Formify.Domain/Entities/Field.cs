using System.ComponentModel.DataAnnotations;

namespace Formify.Domain.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public bool Required { get; set; } // Alanın zorunlu olup olmadığını belirten özellik
        public string Name { get; set; } // Alan adı (örneğin, "Ad" veya "Soyad")

        // Veri türünü temsil eden enum tipi
        public DataType DataType { get; set; }

        // Alanın hangi form ile ilişkili olduğunu belirten özellik
        public int FormId { get; set; }

        public Form Form { get; set; }
    }
}