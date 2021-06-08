using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liftmash.Domain.Entities
{
    public class Materials
    {
        public long Id { get; set; }

        [Column("Код")]
        public string Code { get; set; }

        [Column("Артикул")]
        public string Article { get; set; }

        [StringLength(200)]
        [Column("Наименование")]
        public string Name { get; set; }

        [Column("Единица измерения")]
        public string Unit { get; set; }

        [Column("Количество")]
        public long Count { get; set; }

        [Column("Цена",TypeName = "money")]
        public decimal Price { get; set; }
    }
}
