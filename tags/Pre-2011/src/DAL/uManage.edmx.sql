
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2010 11:50:10
-- Generated from EDMX file: G:\Development\uManage\src\DAL\uManage.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [uManage-FAMILYNET.LOCAL];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ums_Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ums_Messages];
GO
IF OBJECT_ID(N'[dbo].[ums_OfficeLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ums_OfficeLocations];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageID] uniqueidentifier  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [CreatedBy] nvarchar(255)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Category] nvarchar(50)  NOT NULL,
    [IsSysMsg] bit  NOT NULL
);
GO

-- Creating table 'OfficeLocations'
CREATE TABLE [dbo].[OfficeLocations] (
    [Location] nvarchar(100)  NOT NULL,
    [IsEnabled] bit  NOT NULL,
    [CreatedBy] nvarchar(255)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedBy] nvarchar(255)  NOT NULL,
    [ModifiedOn] datetime  NOT NULL
);
GO

-- Creating table 'Applications'
CREATE TABLE [dbo].[Applications] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(100)  NOT NULL,
    [LoweredUserName] nvarchar(100)  NOT NULL,
    [LastActivityDate] datetime  NOT NULL,
    [Application_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Application_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [User_Id] uniqueidentifier  NOT NULL,
    [Roles_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MessageID] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageID] ASC);
GO

-- Creating primary key on [Location] in table 'OfficeLocations'
ALTER TABLE [dbo].[OfficeLocations]
ADD CONSTRAINT [PK_OfficeLocations]
    PRIMARY KEY CLUSTERED ([Location] ASC);
GO

-- Creating primary key on [Id] in table 'Applications'
ALTER TABLE [dbo].[Applications]
ADD CONSTRAINT [PK_Applications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY NONCLUSTERED ([User_Id], [Roles_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Application_Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_ApplicationRole]
    FOREIGN KEY ([Application_Id])
    REFERENCES [dbo].[Applications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicationRole'
CREATE INDEX [IX_FK_ApplicationRole]
ON [dbo].[Roles]
    ([Application_Id]);
GO

-- Creating foreign key on [Application_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_ApplicationUser]
    FOREIGN KEY ([Application_Id])
    REFERENCES [dbo].[Applications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ApplicationUser'
CREATE INDEX [IX_FK_ApplicationUser]
ON [dbo].[Users]
    ([Application_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRole]
    ([Roles_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------