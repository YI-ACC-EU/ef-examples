﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Euris.AirportExample
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AeroportiEntities : DbContext
    {
        public AeroportiEntities()
            : base("name=AeroportiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aereo> Aereos { get; set; }
        public virtual DbSet<Aeroporto> Aeroportoes { get; set; }
        public virtual DbSet<Volo> Voloes { get; set; }
    }
}
