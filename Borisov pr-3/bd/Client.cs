namespace Borisov_pr_3.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string FName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Login { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string IDGroup { get; set; }

        [StringLength(255)]
        public string Email { get; set; }
    }
}
