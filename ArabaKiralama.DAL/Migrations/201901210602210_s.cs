namespace ArabaKiralama.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Musteris", "MusteriKartadı");
            DropColumn("dbo.Musteris", "MusteriKartno");
            DropColumn("dbo.Musteris", "MusteriKartsonkullanmatarihi");
            DropColumn("dbo.Musteris", "MusteriKartCvc");
            DropColumn("dbo.Musteris", "MusteriTakipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musteris", "MusteriTakipId", c => c.Int());
            AddColumn("dbo.Musteris", "MusteriKartCvc", c => c.String());
            AddColumn("dbo.Musteris", "MusteriKartsonkullanmatarihi", c => c.DateTime(nullable: false));
            AddColumn("dbo.Musteris", "MusteriKartno", c => c.String());
            AddColumn("dbo.Musteris", "MusteriKartadı", c => c.String());
        }
    }
}
