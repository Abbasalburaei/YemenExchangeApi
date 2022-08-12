using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TransformRecievers = new HashSet<Transform>();
            TransformSenders = new HashSet<Transform>();
        }

        [Key]
        [StringLength(20)]
        [Unicode(false)]
        public string Id { get; set; } = null!;
        [StringLength(255)]
        public string FullName { get; set; } = null!;
        [StringLength(1000)]
        public string? Address { get; set; }
        public string? IdentityCardPath { get; set; }

        [InverseProperty("Reciever")]
        public virtual ICollection<Transform> TransformRecievers { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<Transform> TransformSenders { get; set; }
    }
}
