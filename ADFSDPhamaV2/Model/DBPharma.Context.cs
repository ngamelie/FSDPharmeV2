﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADFSDPhamaV2.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PharmaConn : DbContext
    {
        public PharmaConn()
            : base("name=pharmaConn")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<Usr> Usrs { get; set; }
    }
}