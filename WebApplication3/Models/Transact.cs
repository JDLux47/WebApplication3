using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public partial class Transact
    {
        [Key]
        public int Id { get; set; }

        public int Type { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal Sum { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
