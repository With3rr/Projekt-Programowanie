﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplikacjaClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BazaUżytkownikowEntities : DbContext
    {
        public BazaUżytkownikowEntities()
            : base("name=BazaUżytkownikowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DaneKonta> DaneKontas { get; set; }
        public virtual DbSet<Karty> Karties { get; set; }
        public virtual DbSet<GrywMojejBibliotece> GrywMojejBiblioteces { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Kody> Kodies { get; set; }
        public virtual DbSet<HistoriaZakupow> HistoriaZakupows { get; set; }
        public virtual DbSet<Dane> Danes { get; set; }
        public virtual DbSet<GamesForSale> GamesForSales { get; set; }
    }
}
