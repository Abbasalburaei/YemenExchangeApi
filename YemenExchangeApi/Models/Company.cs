using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class Company
    {
        public Company()
        {
            Transforms = new HashSet<Transform>();
        }

        [Key]
        [StringLength(20)]
        [Unicode(false)]
        public string Id { get; set; } = null!;
        [StringLength(255)]
        public string Description { get; set; } = null!;
        [Required]
        public bool? Active { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<Transform> Transforms { get; set; }
    }
}
