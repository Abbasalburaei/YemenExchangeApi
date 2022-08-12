using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class Area
    {
        public Area()
        {
            Transforms = new HashSet<Transform>();
        }

        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;

        [ForeignKey("CityId")]
        [InverseProperty("Areas")]
        public virtual City City { get; set; } = null!;
        [InverseProperty("Area")]
        public virtual ICollection<Transform> Transforms { get; set; }
    }
}
