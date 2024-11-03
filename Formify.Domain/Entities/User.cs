namespace Formify.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } // Kullanıcının benzersiz kimliği
        public string Username { get; set; } // Kullanıcı adı
        public string Password { get; set; } // Kullanıcının şifre bilgisi (şifreleme yapılmalı)

        // Kullanıcının oluşturduğu formları içeren koleksiyon
        public List<Form> Forms { get; set; } = new List<Form>();
    }
}