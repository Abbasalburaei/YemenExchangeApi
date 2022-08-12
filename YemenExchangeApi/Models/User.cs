using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class User
    {
        public User()
        {
            Transforms = new HashSet<Transform>();
        }

        [Key]
        [StringLength(20)]
        [Unicode(false)]
        public string Id { get; set; } = null!;
        [StringLength(255)]
        public string FullName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string UserName { get; set; } = null!;
        [StringLength(255)]
        [Unicode(false)]
        public string Password { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CreatedAccount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModify { get; set; }
        public string? ProfilePath { get; set; }
        [StringLength(1000)]
        public string? Address { get; set; }
        [Required]
        public bool? Active { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Transform> Transforms { get; set; }
    }
}
