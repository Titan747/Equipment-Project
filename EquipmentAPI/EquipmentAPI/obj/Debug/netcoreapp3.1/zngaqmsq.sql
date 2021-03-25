IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Equipments] (
    [EquipmentId] bigint NOT NULL IDENTITY,
    [EquipmentName] nvarchar(max) NOT NULL,
    [EquipmentAmount] int NOT NULL,
    [EquipmentPurchaseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Equipments] PRIMARY KEY ([EquipmentId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210325055114_EquipmentAPI.Models.EquipmentContext', N'5.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EquipmentId', N'EquipmentAmount', N'EquipmentName', N'EquipmentPurchaseDate') AND [object_id] = OBJECT_ID(N'[Equipments]'))
    SET IDENTITY_INSERT [Equipments] ON;
INSERT INTO [Equipments] ([EquipmentId], [EquipmentAmount], [EquipmentName], [EquipmentPurchaseDate])
VALUES (CAST(1 AS bigint), 77777, N'Titan', '1979-04-25T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EquipmentId', N'EquipmentAmount', N'EquipmentName', N'EquipmentPurchaseDate') AND [object_id] = OBJECT_ID(N'[Equipments]'))
    SET IDENTITY_INSERT [Equipments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EquipmentId', N'EquipmentAmount', N'EquipmentName', N'EquipmentPurchaseDate') AND [object_id] = OBJECT_ID(N'[Equipments]'))
    SET IDENTITY_INSERT [Equipments] ON;
INSERT INTO [Equipments] ([EquipmentId], [EquipmentAmount], [EquipmentName], [EquipmentPurchaseDate])
VALUES (CAST(2 AS bigint), 11111, N'Tony', '1981-07-13T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EquipmentId', N'EquipmentAmount', N'EquipmentName', N'EquipmentPurchaseDate') AND [object_id] = OBJECT_ID(N'[Equipments]'))
    SET IDENTITY_INSERT [Equipments] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210325060309_EquipmentAPI.Models.EquipmentContextSeed', N'5.0.4');
GO

COMMIT;
GO

