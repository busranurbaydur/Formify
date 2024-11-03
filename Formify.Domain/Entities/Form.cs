namespace Formify.Domain.Entities
{
    public class Form
    {
        public int Id { get; set; }  // Formun benzersiz kimliği
        public string Name { get; set; } // Form adı
        public string Description { get; set; } // Form açıklaması
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public int CreatedBy { get; set; } // Formu oluşturan kullanıcının ID'si

        // Formun içindeki alanları tutan koleksiyon
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}