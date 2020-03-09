using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [RegularExpression("[A-Za-z]*")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [JsonIgnore]
        public decimal Price { get; set; }

        [NotMapped]
        [JsonPropertyName("price")]
        public string PriceFormatted
        {
            get => Price.ToString("N2");
            set => Price = string.IsNullOrEmpty(value) ? -1 : decimal.Parse(value, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-GB"));
        }
    }
}
