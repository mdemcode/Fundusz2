namespace Fundusz2 {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BazaFundusz2 : DbContext {
        // Your context has been configured to use a 'BazaFundusz2' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Fundusz2.BazaFundusz2' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BazaFundusz2' 
        // connection string in the application configuration file.
        public BazaFundusz2() : base("name=BazaFundusz2") {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BazaFundusz2>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}