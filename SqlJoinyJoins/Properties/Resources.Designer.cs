﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlJoinyJoins.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SqlJoinyJoins.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - A Cross Join returns the rows in table A multiplied by the number of rows in table B. In other words, it shows all possible combinations. 
        ///The end result is also called a &quot;Cartesian Product&quot;.  This type of join will take a VERY long time to complete on big tables.
        ///
        ///Note: IF you use a Where clause in a Cross Join, the Cross Join instead behaves exactly like a regular &quot;Full Inner&quot; Join!.
        /// </summary>
        public static string CrossJoinExplanation {
            get {
                return ResourceManager.GetString("CrossJoinExplanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From WeaponAttributes
        ///	CROSS Join Weapons
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string CrossJoinQuery {
            get {
                return ResourceManager.GetString("CrossJoinQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - A &quot;Full Inner Join&quot; returns records that match in both tables. So for this example, you are seeing records that match in WeaponAttributes and Weapons.
        ///● The Squirt gun has a matching ID with attribute name cheap, but its weapon type is null and the attribute weapon type are null
        ///● The Wooden Mallet has a matching ID with the attribute name offensive, but its weapon type is null and the attribute weapon type are null
        ///● The Stringy Spatula has no match on WeaponId in the two tables, so you don&apos;t get anyt [rest of string was truncated]&quot;;.
        /// </summary>
        public static string FullInnerJoinExplanation {
            get {
                return ResourceManager.GetString("FullInnerJoinExplanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From WeaponAttributes
        ///	 Join Weapons 
        ///	on WeaponAttributes.WeaponId = Weapons.WeaponId
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string FullInnerJoinQuery {
            get {
                return ResourceManager.GetString("FullInnerJoinQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - A &quot;Full Outer Join&quot; returns records in both tatbles that match on both sides where available. However, if there is no match then anything missing is null!
        ///Thus a Full Outer Join can return more rows than a regular Inner Join.
        ///
        ///● The spatula has no matching weapon attribute or name due to a lack of common ID, so you get two nulls in the left table.
        ///● The squirt gun and mallet have no matching attribute weapon type or weapon type, so you get nulls on left and right since the two columns are null.
        ///● The [rest of string was truncated]&quot;;.
        /// </summary>
        public static string FullOuterJoinExplanation {
            get {
                return ResourceManager.GetString("FullOuterJoinExplanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From WeaponAttributes
        ///	Full Join Weapons 
        ///	on WeaponAttributes.WeaponId = Weapons.WeaponId
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string FullOuterJoinQuery {
            get {
                return ResourceManager.GetString("FullOuterJoinQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///FROM   WeaponAttributes 
        ///       LEFT JOIN Weapons 
        ///          ON WeaponAttributes.WeaponId = Weapons.WeaponId
        ///UNION ALL
        ///SELECT WeaponAttributes.AttributeWeaponType, WeaponAttributes.AttributeName, WeaponName, WeaponType
        ///FROM  Weapons
        ///       LEFT JOIN WeaponAttributes
        ///          ON WeaponAttributes.WeaponId = Weapons.WeaponId
        ///WHERE  WeaponAttributes.WeaponId IS NULL
        ///order by AttributeWeaponType.
        /// </summary>
        public static string FullOuterJoinQuerySqlite {
            get {
                return ResourceManager.GetString("FullOuterJoinQuerySqlite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create Table Weapons(
        ///WeaponId int identity not null Primary Key,
        ///WeaponName nvarchar(1000) not null,
        ///WeaponType nvarchar(250) null,
        ///)
        ///
        ///Create Table WeaponAttributes(
        ///AttributeId int identity not null Primary Key,
        ///AttributeName nvarchar(1000) not null,
        ///AttributeWeaponType nvarchar(250) null,
        ///WeaponId int null
        ///)
        ///
        ///
        ///insert into Weapons values(&apos;Wooden Sword&apos;, &apos;Sword&apos;)
        ///insert into Weapons values(&apos;Squirt Gun&apos;, null)
        ///insert into Weapons values(&apos;Air Gun&apos;, &apos;Gun&apos;)
        ///insert into Weapons values(&apos;Plastic  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string JoinyJoinsDatabaseFill {
            get {
                return ResourceManager.GetString("JoinyJoinsDatabaseFill", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - A Left Join returns all records from table A. If there are any matches in table B, they display. Otherwise you will get nulls.
        ///
        ///● The null attribute weapon type with attribute name cheap has a matching weapon named squirt gun. The weapon type is null.
        ///● The same is the case with offensive / wooden mallet.
        ///● Annoying Kitchen utensil has no matches in the right table based off of weapon Id..
        /// </summary>
        public static string LeftJoinExplanation {
            get {
                return ResourceManager.GetString("LeftJoinExplanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From WeaponAttributes
        ///	Left Join Weapons
        ///	on WeaponAttributes.WeaponId = Weapons.WeaponId
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string LeftJoinQuery {
            get {
                return ResourceManager.GetString("LeftJoinQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to - A Right Join returns all records from table B. If there are any matches in table A, they display. Otherwise you will get nulls.
        ///
        ///● The squirt gun has a match on the left for the weapon attribute named cheap. Since there are no weapon types, they are null.
        ///● The same is the case for the offensive/wooden mallet.
        ///● Nothing in WeaponAttributes matches the Stringy Spatula, so you get nulls on the left
        ///
        ///Note: Some databases do not support Full Outer Join. 
        ///
        ///For example,
        ///Sqlite does not support it. So y [rest of string was truncated]&quot;;.
        /// </summary>
        public static string RightJoinExplanation {
            get {
                return ResourceManager.GetString("RightJoinExplanation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From WeaponAttributes
        ///	Right Join Weapons
        ///	on WeaponAttributes.WeaponId = Weapons.WeaponId
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string RightJoinQuery {
            get {
                return ResourceManager.GetString("RightJoinQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select AttributeWeaponType, AttributeName, WeaponName, WeaponType
        ///From Weapons
        ///	Left Join WeaponAttributes
        ///	on Weapons.WeaponId = WeaponAttributes.WeaponId
        ///Order By AttributeWeaponType.
        /// </summary>
        public static string RightJoinQuerySqlite {
            get {
                return ResourceManager.GetString("RightJoinQuerySqlite", resourceCulture);
            }
        }
    }
}
