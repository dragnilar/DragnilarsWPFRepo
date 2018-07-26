using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlJoinyJoins.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        [StringLength(1000)]
        public string WeaponName { get; set; }
        [StringLength(250)]
        public string WeaponType { get; set; }
    }
}
