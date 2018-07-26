using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJoinyJoins.Models
{
    public class WeaponAttribute
    {
        [Required, Key]
        public int AttributeId { get; set; }
        [StringLength(1000)]
        public string AttributeName { get; set; }
        [StringLength(250)]
        public string AttributeWeaponType { get; set; }
        public int? WeaponId { get; set; }
    }
}
