﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EduvetKonovalov.DataFolder
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Coming> Coming { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Passport> Passport { get; set; }
        public DbSet<Password> Password { get; set; }
        public DbSet<Remainder> Remainder { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TypeVeterinaryEquipment> TypeVeterinaryEquipment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<VeterinaryEquipment> VeterinaryEquipment { get; set; }
    }
}
