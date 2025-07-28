using System.ComponentModel.DataAnnotations;

namespace ArabaSatis.Models
{
    public class YakitEkle
    {
        [Key] 
        public int YakitId { get; set; }
        public string YakitAdi { get; set; } = string.Empty;
        
    }
}
