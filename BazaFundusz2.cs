namespace Fundusz2 {
    using System;
    using Fundusz2.Model;
    using System.Data.Entity;
    using System.Linq;

    public class BazaFundusz2 : DbContext {
        public BazaFundusz2() : base("name=BazaFundusz2") {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BazaFundusz2>());
        }
        public virtual DbSet<Fundusz> FunduszMain { get; set; }
        public virtual DbSet<Inwestycja> Inwestycje { get; set; }
        public virtual DbSet<Lokata> Lokaty { get; set; }
        public virtual DbSet<Operacja> Operacje { get; set; }
        public virtual DbSet<Pozyczka> Pozyczki { get; set; }
        public virtual DbSet<Uczestnik> Uczestnicy { get; set; }
    }
}