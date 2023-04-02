using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class TransactDTO
    {
        public int Type { get; set; }

        public int? CategoryId { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
