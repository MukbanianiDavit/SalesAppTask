namespace SalesApp.Infrastructure.Data.Scripts
{
    // Additional SQL scripts to run on migration
    internal static class SqlScripts
    {
        // Creating trigger to ensure "self employed" sellers have same seller_id as seller_boss_id
        public static readonly string SellersTrigger =
                @"IF OBJECT_ID(N'[dbo].[Sellers_Boss_Update]', N'TR') IS NOT NULL
                    exec sp_executesql N'DROP TRIGGER [dbo].[Sellers_Boss_Update]';
                GO

                CREATE TRIGGER [dbo].[Sellers_Boss_Update]
                ON [dbo].[Sellers]
                AFTER INSERT
                AS
                BEGIN
                SET NOCOUNT ON;
                UPDATE s set s.[seller_boss_id] = s.[seller_id] FROM [dbo].[Sellers] s
                INNER JOIN inserted i on s.[seller_id] = i.[seller_id]
                where i.[seller_boss_id] IS NULL;
                END;";

        // Dropping Sellers_Boss_Update trigger
        public static readonly string SellersTriggerDrop =
                @"IF OBJECT_ID(N'[dbo].[Sellers_Boss_Update]', N'TR') IS NOT NULL
                    exec sp_executesql N'DROP TRIGGER [dbo].[Sellers_Boss_Update]';
                GO";

    }
}
