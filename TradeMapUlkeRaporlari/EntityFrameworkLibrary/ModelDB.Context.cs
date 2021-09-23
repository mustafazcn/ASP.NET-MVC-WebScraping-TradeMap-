﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TradeMapTicaretDB : DbContext
    {
        public TradeMapTicaretDB()
            : base("name=TradeMapTicaretDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<binaryProduct_Ulke_Raporu> binaryProduct_Ulke_Raporu { get; set; }
        public virtual DbSet<Genel_Ulke_Raporu> Genel_Ulke_Raporu { get; set; }
        public virtual DbSet<Ozel_Ulke_Raporu> Ozel_Ulke_Raporu { get; set; }
        public virtual DbSet<Product_Ulke_Raporu> Product_Ulke_Raporu { get; set; }
        public virtual DbSet<Ulkeler> Ulkeler { get; set; }
        public virtual DbSet<View_Base_BinaryProductUlkeRaporu> View_Base_BinaryProductUlkeRaporu { get; set; }
        public virtual DbSet<View_Base_GenelUlkeRaporu> View_Base_GenelUlkeRaporu { get; set; }
        public virtual DbSet<View_Base_OzelUlkeRaporu> View_Base_OzelUlkeRaporu { get; set; }
        public virtual DbSet<View_Base_ProductUlkeRaporu> View_Base_ProductUlkeRaporu { get; set; }
        public virtual DbSet<View_Base_Ulkeler> View_Base_Ulkeler { get; set; }
        public virtual DbSet<View_Presentation_GenelUlke> View_Presentation_GenelUlke { get; set; }
        public virtual DbSet<View_Presentation_OzelUlke> View_Presentation_OzelUlke { get; set; }
    
        public virtual ObjectResult<Proc_GenelUlkeRapor_Islem_Result> Proc_GenelUlkeRapor_Islem(string islem, string ulkeAd, string yil, string ithalat_ulkeAd, Nullable<long> ithalat, string ihracat_ulkeAd, Nullable<long> ihracat)
        {
            var islemParameter = islem != null ?
                new ObjectParameter("Islem", islem) :
                new ObjectParameter("Islem", typeof(string));
    
            var ulkeAdParameter = ulkeAd != null ?
                new ObjectParameter("ulkeAd", ulkeAd) :
                new ObjectParameter("ulkeAd", typeof(string));
    
            var yilParameter = yil != null ?
                new ObjectParameter("yil", yil) :
                new ObjectParameter("yil", typeof(string));
    
            var ithalat_ulkeAdParameter = ithalat_ulkeAd != null ?
                new ObjectParameter("Ithalat_ulkeAd", ithalat_ulkeAd) :
                new ObjectParameter("Ithalat_ulkeAd", typeof(string));
    
            var ithalatParameter = ithalat.HasValue ?
                new ObjectParameter("ithalat", ithalat) :
                new ObjectParameter("ithalat", typeof(long));
    
            var ihracat_ulkeAdParameter = ihracat_ulkeAd != null ?
                new ObjectParameter("Ihracat_ulkeAd", ihracat_ulkeAd) :
                new ObjectParameter("Ihracat_ulkeAd", typeof(string));
    
            var ihracatParameter = ihracat.HasValue ?
                new ObjectParameter("ihracat", ihracat) :
                new ObjectParameter("ihracat", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_GenelUlkeRapor_Islem_Result>("Proc_GenelUlkeRapor_Islem", islemParameter, ulkeAdParameter, yilParameter, ithalat_ulkeAdParameter, ithalatParameter, ihracat_ulkeAdParameter, ihracatParameter);
        }
    
        public virtual ObjectResult<Proc_OzelUlkeRapor_Islem_Result> Proc_OzelUlkeRapor_Islem(string islem, string ulkeAd, string yil, Nullable<long> ithalat, Nullable<long> ihracat, Nullable<long> hacim, Nullable<long> denge)
        {
            var islemParameter = islem != null ?
                new ObjectParameter("Islem", islem) :
                new ObjectParameter("Islem", typeof(string));
    
            var ulkeAdParameter = ulkeAd != null ?
                new ObjectParameter("ulkeAd", ulkeAd) :
                new ObjectParameter("ulkeAd", typeof(string));
    
            var yilParameter = yil != null ?
                new ObjectParameter("yil", yil) :
                new ObjectParameter("yil", typeof(string));
    
            var ithalatParameter = ithalat.HasValue ?
                new ObjectParameter("ithalat", ithalat) :
                new ObjectParameter("ithalat", typeof(long));
    
            var ihracatParameter = ihracat.HasValue ?
                new ObjectParameter("ihracat", ihracat) :
                new ObjectParameter("ihracat", typeof(long));
    
            var hacimParameter = hacim.HasValue ?
                new ObjectParameter("hacim", hacim) :
                new ObjectParameter("hacim", typeof(long));
    
            var dengeParameter = denge.HasValue ?
                new ObjectParameter("denge", denge) :
                new ObjectParameter("denge", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Proc_OzelUlkeRapor_Islem_Result>("Proc_OzelUlkeRapor_Islem", islemParameter, ulkeAdParameter, yilParameter, ithalatParameter, ihracatParameter, hacimParameter, dengeParameter);
        }
    }
}
