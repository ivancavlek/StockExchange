namespace Acme.StockExchange.Repository.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "broker.Stocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OfferingAmount = c.Int(nullable: false),
                        OfferingPrice = c.Decimal(nullable: false, precision: 9, scale: 2),
                        TickerSymbol = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("broker.Stocks");
        }
    }
}
