using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YemenExchangeApi.Models
{
    public partial class Transform
    {
        [Key]
        [StringLength(100)]
        [Unicode(false)]
        public string TransformNo { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string CompanyId { get; set; } = null!;
        public int CityId { get; set; }
        public int AreaId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string UserId { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string SenderId { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string SenderPhoneNumber { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string RecieverId { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string RecieverPhoneNumber { get; set; } = null!;
        public double Amount { get; set; }
        public double Fees { get; set; }
        public double Total { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SentDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RecievedDate { get; set; }
        public string? IdentityCardPath { get; set; }
        public bool Done { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }

        [ForeignKey("AreaId")]
        [InverseProperty("Transforms")]
        public virtual Area Area { get; set; } = null!;
        [ForeignKey("CityId")]
        [InverseProperty("Transforms")]
        public virtual City City { get; set; } = null!;
        [ForeignKey("CompanyId")]
        [InverseProperty("Transforms")]
        public virtual Company Company { get; set; } = null!;
        [ForeignKey("RecieverId")]
        [InverseProperty("TransformRecievers")]
        public virtual Customer Reciever { get; set; } = null!;
        [ForeignKey("SenderId")]
        [InverseProperty("TransformSenders")]
        public virtual Customer Sender { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Transforms")]
        public virtual User User { get; set; } = null!;
    }
}
