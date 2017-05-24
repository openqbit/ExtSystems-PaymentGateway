namespace OpenQbit.PaymentGateway.DataAccess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        CreaditCardSequence = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Merchant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MerchantName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreaditCardNo = c.String(),
                        CreaditCardCCV = c.String(),
                        CreaditCardName = c.String(),
                        ExpiaryDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                        MarchantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Merchant", t => t.MarchantId, cascadeDelete: true)
                .Index(t => t.MarchantId);
            
            CreateTable(
                "dbo.Responce",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        MessageDetails = c.String(),
                        RespondTime = c.DateTime(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Request", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        TransactionTime = c.DateTime(nullable: false),
                        BankId = c.Int(nullable: false),
                        ResponceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bank", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Responce", t => t.ResponceId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.ResponceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ResponceId", "dbo.Responce");
            DropForeignKey("dbo.Transaction", "BankId", "dbo.Bank");
            DropForeignKey("dbo.Responce", "RequestId", "dbo.Request");
            DropForeignKey("dbo.Request", "MarchantId", "dbo.Merchant");
            DropIndex("dbo.Transaction", new[] { "ResponceId" });
            DropIndex("dbo.Transaction", new[] { "BankId" });
            DropIndex("dbo.Responce", new[] { "RequestId" });
            DropIndex("dbo.Request", new[] { "MarchantId" });
            DropTable("dbo.Transaction");
            DropTable("dbo.Responce");
            DropTable("dbo.Request");
            DropTable("dbo.Merchant");
            DropTable("dbo.Bank");
        }
    }
}
