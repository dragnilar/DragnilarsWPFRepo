using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlJoinyJoins.Models;

namespace SqlJoinyJoins.Factories
{
    public class DefaultDataFactory
    {

        public List<WeaponAttribute> GetWeaponAttributeSeed()
        {
            var weaponAttributes = new List<WeaponAttribute>
            {
                new WeaponAttribute
                {
                    WeaponId = 1,
                    AttributeName = "Awkward",
                    AttributeWeaponType = "Sword"
                },
                new WeaponAttribute
                {
                    WeaponId = 2,
                    AttributeName = "Cheap",
                    AttributeWeaponType = null
                },
                new WeaponAttribute
                {
                    WeaponId = 3,
                    AttributeName = "Weak",
                    AttributeWeaponType = "Gun"
                },
                new WeaponAttribute
                {
                    WeaponId = 4,
                    AttributeName = "Squeeky",
                    AttributeWeaponType = "Rake"
                },
                new WeaponAttribute
                {
                    WeaponId = 5,
                    AttributeName = "Offensive",
                    AttributeWeaponType = null
                },
                new WeaponAttribute
                {
                    WeaponId = null,
                    AttributeName = "Annoying",
                    AttributeWeaponType = "Kitchen Utensil"
                },
            };
            return weaponAttributes;
        }

        public List<Weapon> GetWeaponSeed()
        {
            var weapons = new List<Weapon>
            {
                new Weapon
                {
                    WeaponName = "Wooden Sword",
                    WeaponType = "Sword"
                },
                new Weapon
                {
                    WeaponName = "Squirt Gun",
                    WeaponType = null
                },
                new Weapon
                {
                    WeaponName = "Air Gun",
                    WeaponType = "Gun"
                },
                new Weapon
                {
                    WeaponName = "Plastic Rake",
                    WeaponType = "Rake"
                },
                new Weapon
                {
                    WeaponName = "Wooden Mallet",
                    WeaponType = null
                },
                new Weapon
                {
                    WeaponName = "Stringy Spatula",
                    WeaponType = "Kitchen Utensil"
                }
            };
            return weapons;
        }
    }
}
