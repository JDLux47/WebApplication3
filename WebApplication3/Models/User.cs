using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public partial class User: IdentityUser<int>
    {
        public User()
        {
            Transact = new HashSet<Transact>();
        }

        [Key]
        public override int Id { get; set; }

        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        public double? SumLimiter { get; set; }

        [Column(TypeName = "date")] 
        public DateTime DateUpdateBalance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transact> Transact { get; set; }

    }
}
