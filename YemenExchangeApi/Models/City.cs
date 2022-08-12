using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class City
    {
        public City()
        {
            Areas = new HashSet<Area>();
            Transforms = new HashSet<Transform>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;

        [InverseProperty("City")]
        public virtual ICollection<Area> Areas { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Transform> Transforms { get; set; }
    }
}
