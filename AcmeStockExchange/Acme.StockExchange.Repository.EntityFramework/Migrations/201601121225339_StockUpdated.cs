namespace Acme.StockExchange.Repository.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("broker.Stocks", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("broker.Stocks", "PercentagePriceChange", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("broker.Stocks", "PriceChange", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("broker.Stocks", "PriceChange");
            DropColumn("broker.Stocks", "PercentagePriceChange");
            DropColumn("broker.Stocks", "CurrentPrice");
        }
    }
}
