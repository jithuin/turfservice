
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2019 09:50:28
-- Generated from EDMX file: D:\TheBackup\OneDrive\Projects\TurfProjects\Projects\websvc\websvc\Models\TurfModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [turfmgt];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TurfUserTurfMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfMasters] DROP CONSTRAINT [FK_TurfUserTurfMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfUserTurfBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfBookings] DROP CONSTRAINT [FK_TurfUserTurfBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfUserTurfGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfGroups] DROP CONSTRAINT [FK_TurfUserTurfGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeofTurfTurfMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfMasters] DROP CONSTRAINT [FK_TypeofTurfTurfMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfMasterTurfMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfMedias] DROP CONSTRAINT [FK_TurfMasterTurfMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfFecilityMasterTurfFacilityList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfFacilityLists] DROP CONSTRAINT [FK_TurfFecilityMasterTurfFacilityList];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfMasterTurfFacilityList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfFacilityLists] DROP CONSTRAINT [FK_TurfMasterTurfFacilityList];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfBookingTurfBookingFacilityList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfBookingFacilityLists] DROP CONSTRAINT [FK_TurfBookingTurfBookingFacilityList];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfBookingFacilityListTurfFacilityList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfBookingFacilityLists] DROP CONSTRAINT [FK_TurfBookingFacilityListTurfFacilityList];
GO
IF OBJECT_ID(N'[dbo].[FK_TurfMasterTurfBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TurfBookings] DROP CONSTRAINT [FK_TurfMasterTurfBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TurfUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfUsers];
GO
IF OBJECT_ID(N'[dbo].[TurfMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfMasters];
GO
IF OBJECT_ID(N'[dbo].[TurfGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfGroups];
GO
IF OBJECT_ID(N'[dbo].[TypeofTurfs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeofTurfs];
GO
IF OBJECT_ID(N'[dbo].[TurfMedias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfMedias];
GO
IF OBJECT_ID(N'[dbo].[TurfBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfBookings];
GO
IF OBJECT_ID(N'[dbo].[TurfFecilityMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfFecilityMasters];
GO
IF OBJECT_ID(N'[dbo].[TurfFacilityLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfFacilityLists];
GO
IF OBJECT_ID(N'[dbo].[TurfBookingFacilityLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TurfBookingFacilityLists];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TurfUsers'
CREATE TABLE [dbo].[TurfUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [UserType] smallint  NOT NULL
);
GO

-- Creating table 'TurfMasters'
CREATE TABLE [dbo].[TurfMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [TurfUserId] int  NOT NULL,
    [TypeofTurfId] int  NOT NULL
);
GO

-- Creating table 'TurfGroups'
CREATE TABLE [dbo].[TurfGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [TurfUserId] int  NOT NULL
);
GO

-- Creating table 'TypeofTurfs'
CREATE TABLE [dbo].[TypeofTurfs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TurfMedias'
CREATE TABLE [dbo].[TurfMedias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileLocation] nvarchar(max)  NULL,
    [TurfMasterId] int  NOT NULL
);
GO

-- Creating table 'TurfBookings'
CREATE TABLE [dbo].[TurfBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegistrationDate] datetime  NULL,
    [RegistrationTime] datetime  NULL,
    [Amount] decimal(18,2)  NULL,
    [ApprovedStatus] int  NULL,
    [PaymentStatus] int  NULL,
    [AprovalDate] datetime  NULL,
    [TurfUserId] int  NOT NULL,
    [TurfMasterId] int  NOT NULL
);
GO

-- Creating table 'TurfFecilityMasters'
CREATE TABLE [dbo].[TurfFecilityMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TurfFacilityLists'
CREATE TABLE [dbo].[TurfFacilityLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [IsDefault] int  NOT NULL,
    [TurfMasterId] int  NOT NULL,
    [TurfFecilityMasterId] int  NOT NULL
);
GO

-- Creating table 'TurfBookingFacilityLists'
CREATE TABLE [dbo].[TurfBookingFacilityLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(18,2)  NULL,
    [TurfBookingId] int  NOT NULL,
    [TurfFacilityListId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TurfUsers'
ALTER TABLE [dbo].[TurfUsers]
ADD CONSTRAINT [PK_TurfUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfMasters'
ALTER TABLE [dbo].[TurfMasters]
ADD CONSTRAINT [PK_TurfMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfGroups'
ALTER TABLE [dbo].[TurfGroups]
ADD CONSTRAINT [PK_TurfGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeofTurfs'
ALTER TABLE [dbo].[TypeofTurfs]
ADD CONSTRAINT [PK_TypeofTurfs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfMedias'
ALTER TABLE [dbo].[TurfMedias]
ADD CONSTRAINT [PK_TurfMedias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfBookings'
ALTER TABLE [dbo].[TurfBookings]
ADD CONSTRAINT [PK_TurfBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfFecilityMasters'
ALTER TABLE [dbo].[TurfFecilityMasters]
ADD CONSTRAINT [PK_TurfFecilityMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfFacilityLists'
ALTER TABLE [dbo].[TurfFacilityLists]
ADD CONSTRAINT [PK_TurfFacilityLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TurfBookingFacilityLists'
ALTER TABLE [dbo].[TurfBookingFacilityLists]
ADD CONSTRAINT [PK_TurfBookingFacilityLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TurfUserId] in table 'TurfMasters'
ALTER TABLE [dbo].[TurfMasters]
ADD CONSTRAINT [FK_TurfUserTurfMaster]
    FOREIGN KEY ([TurfUserId])
    REFERENCES [dbo].[TurfUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfUserTurfMaster'
CREATE INDEX [IX_FK_TurfUserTurfMaster]
ON [dbo].[TurfMasters]
    ([TurfUserId]);
GO

-- Creating foreign key on [TurfUserId] in table 'TurfBookings'
ALTER TABLE [dbo].[TurfBookings]
ADD CONSTRAINT [FK_TurfUserTurfBooking]
    FOREIGN KEY ([TurfUserId])
    REFERENCES [dbo].[TurfUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfUserTurfBooking'
CREATE INDEX [IX_FK_TurfUserTurfBooking]
ON [dbo].[TurfBookings]
    ([TurfUserId]);
GO

-- Creating foreign key on [TurfUserId] in table 'TurfGroups'
ALTER TABLE [dbo].[TurfGroups]
ADD CONSTRAINT [FK_TurfUserTurfGroup]
    FOREIGN KEY ([TurfUserId])
    REFERENCES [dbo].[TurfUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfUserTurfGroup'
CREATE INDEX [IX_FK_TurfUserTurfGroup]
ON [dbo].[TurfGroups]
    ([TurfUserId]);
GO

-- Creating foreign key on [TypeofTurfId] in table 'TurfMasters'
ALTER TABLE [dbo].[TurfMasters]
ADD CONSTRAINT [FK_TypeofTurfTurfMaster]
    FOREIGN KEY ([TypeofTurfId])
    REFERENCES [dbo].[TypeofTurfs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeofTurfTurfMaster'
CREATE INDEX [IX_FK_TypeofTurfTurfMaster]
ON [dbo].[TurfMasters]
    ([TypeofTurfId]);
GO

-- Creating foreign key on [TurfMasterId] in table 'TurfMedias'
ALTER TABLE [dbo].[TurfMedias]
ADD CONSTRAINT [FK_TurfMasterTurfMedia]
    FOREIGN KEY ([TurfMasterId])
    REFERENCES [dbo].[TurfMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfMasterTurfMedia'
CREATE INDEX [IX_FK_TurfMasterTurfMedia]
ON [dbo].[TurfMedias]
    ([TurfMasterId]);
GO

-- Creating foreign key on [TurfFecilityMasterId] in table 'TurfFacilityLists'
ALTER TABLE [dbo].[TurfFacilityLists]
ADD CONSTRAINT [FK_TurfFecilityMasterTurfFacilityList]
    FOREIGN KEY ([TurfFecilityMasterId])
    REFERENCES [dbo].[TurfFecilityMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfFecilityMasterTurfFacilityList'
CREATE INDEX [IX_FK_TurfFecilityMasterTurfFacilityList]
ON [dbo].[TurfFacilityLists]
    ([TurfFecilityMasterId]);
GO

-- Creating foreign key on [TurfMasterId] in table 'TurfFacilityLists'
ALTER TABLE [dbo].[TurfFacilityLists]
ADD CONSTRAINT [FK_TurfMasterTurfFacilityList]
    FOREIGN KEY ([TurfMasterId])
    REFERENCES [dbo].[TurfMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfMasterTurfFacilityList'
CREATE INDEX [IX_FK_TurfMasterTurfFacilityList]
ON [dbo].[TurfFacilityLists]
    ([TurfMasterId]);
GO

-- Creating foreign key on [TurfBookingId] in table 'TurfBookingFacilityLists'
ALTER TABLE [dbo].[TurfBookingFacilityLists]
ADD CONSTRAINT [FK_TurfBookingTurfBookingFacilityList]
    FOREIGN KEY ([TurfBookingId])
    REFERENCES [dbo].[TurfBookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfBookingTurfBookingFacilityList'
CREATE INDEX [IX_FK_TurfBookingTurfBookingFacilityList]
ON [dbo].[TurfBookingFacilityLists]
    ([TurfBookingId]);
GO

-- Creating foreign key on [TurfFacilityListId] in table 'TurfBookingFacilityLists'
ALTER TABLE [dbo].[TurfBookingFacilityLists]
ADD CONSTRAINT [FK_TurfBookingFacilityListTurfFacilityList]
    FOREIGN KEY ([TurfFacilityListId])
    REFERENCES [dbo].[TurfFacilityLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfBookingFacilityListTurfFacilityList'
CREATE INDEX [IX_FK_TurfBookingFacilityListTurfFacilityList]
ON [dbo].[TurfBookingFacilityLists]
    ([TurfFacilityListId]);
GO

-- Creating foreign key on [TurfMasterId] in table 'TurfBookings'
ALTER TABLE [dbo].[TurfBookings]
ADD CONSTRAINT [FK_TurfMasterTurfBooking]
    FOREIGN KEY ([TurfMasterId])
    REFERENCES [dbo].[TurfMasters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurfMasterTurfBooking'
CREATE INDEX [IX_FK_TurfMasterTurfBooking]
ON [dbo].[TurfBookings]
    ([TurfMasterId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------