using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.Entities
{
    [Owned]
    public class AuditEntity
    {
        [Column("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Column("CreatorId")]
        public Guid? CreatorId { get; set; }
        [Column("CreatorName")]
        public string CreatorName { get; set; }
        [Column("ModifiedOn")]
        public DateTime? ModifiedOn { get; set; }
        [Column("ModifiedByUserId")]
        public Guid? ModifiedByUserId { get; set; }
        [Column("ModifiedByUserName")]
        public string ModifiedByUserName { get; set; }
    }
}
