
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2011 15:03:47
-- Generated from EDMX file: E:\Development\uManage\src\EF\App.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [uManage];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Offices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offices];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[Notices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notices];
GO
IF OBJECT_ID(N'[dbo].[EmailTemplates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailTemplates];
GO
IF OBJECT_ID(N'[dbo].[AppSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppSettings];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[AuditLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuditLogs];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[SiteMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteMenus];
GO
IF OBJECT_ID(N'[dbo].[QuickLinks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuickLinks];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [LocationId] uniqueidentifier  NOT NULL,
    [LocationName] nvarchar(50)  NOT NULL,
    [OrganizationName] nvarchar(50)  NULL,
    [Address] nvarchar(100)  NULL,
    [City] nvarchar(50)  NULL,
    [Province] nvarchar(50)  NULL,
    [PostalCode] nvarchar(15)  NULL,
    [Country] nvarchar(30)  NULL,
    [Phone] nvarchar(20)  NULL,
    [DistinguishedPath] nvarchar(200)  NOT NULL,
    [NewUsernameFormat] nvarchar(50)  NOT NULL,
    [UmsDirectoryGroup] nvarchar(100)  NOT NULL,
    [IsEnabled] bit  NOT NULL,
    [Directory] nvarchar(100)  NOT NULL,
    [DirectoryNt] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Offices'
CREATE TABLE [dbo].[Offices] (
    [OfficeId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [Description] nvarchar(75)  NULL,
    [IsEnabled] bit  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [EmailId] uniqueidentifier  NOT NULL,
    [Address] nvarchar(200)  NOT NULL,
    [Subject] nvarchar(100)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [SubmittedOn] datetime  NOT NULL,
    [StartedOn] datetime  NULL,
    [CompletedOn] datetime  NULL,
    [EffectiveDate] datetime  NOT NULL,
    [Attempts] int  NULL,
    [IsComplete] bit  NOT NULL
);
GO

-- Creating table 'Notices'
CREATE TABLE [dbo].[Notices] (
    [NoticeId] uniqueidentifier  NOT NULL,
    [Username] nvarchar(25)  NOT NULL,
    [UsernameUpn] nvarchar(45)  NOT NULL,
    [DisplayName] nvarchar(35)  NOT NULL,
    [Type] nvarchar(20)  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [NoticeDate] datetime  NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [EmailAddress] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'EmailTemplates'
CREATE TABLE [dbo].[EmailTemplates] (
    [TemplateId] uniqueidentifier  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdatedOn] datetime  NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [UpdatedBy] nvarchar(50)  NULL,
    [IsEnabled] bit  NOT NULL
);
GO

-- Creating table 'AppSettings'
CREATE TABLE [dbo].[AppSettings] (
    [SettingId] uniqueidentifier  NOT NULL,
    [Key] nvarchar(50)  NOT NULL,
    [Value] nvarchar(2048)  NULL,
    [IsEncrypted] bit  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] uniqueidentifier  NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [UpnUsername] nvarchar(75)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(40)  NOT NULL,
    [Description] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'AuditLogs'
CREATE TABLE [dbo].[AuditLogs] (
    [LogId] uniqueidentifier  NOT NULL,
    [LogDate] datetime  NOT NULL,
    [LogDateUtc] datetime  NOT NULL,
    [SubmittedBy] nvarchar(150)  NOT NULL,
    [FirstName_Old] nvarchar(30)  NULL,
    [MiddleName_Old] nvarchar(30)  NULL,
    [LastName_Old] nvarchar(30)  NULL,
    [Email_Old] nvarchar(50)  NULL,
    [Website_Old] nvarchar(50)  NULL,
    [JobTitle_Old] nvarchar(30)  NULL,
    [Office_Old] nvarchar(50)  NULL,
    [Company_Old] nvarchar(50)  NULL,
    [Department_Old] nvarchar(50)  NULL,
    [EmployeeId_Old] nvarchar(15)  NULL,
    [Manager_Old] nvarchar(60)  NULL,
    [Address1_Old] nvarchar(30)  NULL,
    [Address2_Old] nvarchar(30)  NULL,
    [City_Old] nvarchar(40)  NULL,
    [PostalCode_Old] nvarchar(20)  NULL,
    [Province_Old] nvarchar(30)  NULL,
    [Country_Old] nvarchar(30)  NULL,
    [HomePhone_Old] nvarchar(20)  NULL,
    [OfficePhone_Old] nvarchar(20)  NULL,
    [Pager_Old] nvarchar(20)  NULL,
    [MobilePhone_Old] nvarchar(20)  NULL,
    [Fax_Old] nvarchar(20)  NULL,
    [SipPhone_Old] nvarchar(50)  NULL,
    [UpnUsername] nvarchar(150)  NOT NULL,
    [FirstName] nvarchar(30)  NULL,
    [MiddleName] nvarchar(30)  NULL,
    [LastName] nvarchar(30)  NULL,
    [Email] nvarchar(50)  NULL,
    [Website] nvarchar(50)  NULL,
    [JobTitle] nvarchar(30)  NULL,
    [Office] nvarchar(50)  NULL,
    [Company] nvarchar(50)  NULL,
    [Department] nvarchar(50)  NULL,
    [EmployeeId] nvarchar(15)  NULL,
    [Manager] nvarchar(60)  NULL,
    [Address1] nvarchar(30)  NULL,
    [Address2] nvarchar(30)  NULL,
    [City] nvarchar(40)  NULL,
    [PostalCode] nvarchar(20)  NULL,
    [Province] nvarchar(30)  NULL,
    [Country] nvarchar(30)  NULL,
    [HomePhone] nvarchar(20)  NULL,
    [OfficePhone] nvarchar(20)  NULL,
    [Pager] nvarchar(20)  NULL,
    [MobilePhone] nvarchar(20)  NULL,
    [Fax] nvarchar(20)  NULL,
    [SipPhone] nvarchar(50)  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [Description] nvarchar(75)  NULL,
    [IsEnabled] bit  NOT NULL,
    [Number] int  NOT NULL
);
GO

-- Creating table 'SiteMenus'
CREATE TABLE [dbo].[SiteMenus] (
    [MenuID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [URL] nvarchar(max)  NULL,
    [Roles] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [routeName] nvarchar(max)  NULL,
    [Enabled] bit  NULL
);
GO

-- Creating table 'QuickLinks'
CREATE TABLE [dbo].[QuickLinks] (
    [LinkId] uniqueidentifier  NOT NULL,
    [Url] nvarchar(1024)  NOT NULL,
    [DisplayText] nvarchar(150)  NOT NULL,
    [DisplayOrder] int  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostId] uniqueidentifier  NOT NULL,
    [Subject] nvarchar(140)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [PostedBy] nvarchar(200)  NOT NULL,
    [PostedOn] datetime  NOT NULL,
    [VisibleFrom] datetime  NOT NULL,
    [VisibileTo] datetime  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [User_UserId] uniqueidentifier  NOT NULL,
    [Roles_RoleId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LocationId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([LocationId] ASC);
GO

-- Creating primary key on [OfficeId] in table 'Offices'
ALTER TABLE [dbo].[Offices]
ADD CONSTRAINT [PK_Offices]
    PRIMARY KEY CLUSTERED ([OfficeId] ASC);
GO

-- Creating primary key on [EmailId] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([EmailId] ASC);
GO

-- Creating primary key on [NoticeId] in table 'Notices'
ALTER TABLE [dbo].[Notices]
ADD CONSTRAINT [PK_Notices]
    PRIMARY KEY CLUSTERED ([NoticeId] ASC);
GO

-- Creating primary key on [TemplateId] in table 'EmailTemplates'
ALTER TABLE [dbo].[EmailTemplates]
ADD CONSTRAINT [PK_EmailTemplates]
    PRIMARY KEY CLUSTERED ([TemplateId] ASC);
GO

-- Creating primary key on [SettingId] in table 'AppSettings'
ALTER TABLE [dbo].[AppSettings]
ADD CONSTRAINT [PK_AppSettings]
    PRIMARY KEY CLUSTERED ([SettingId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [LogId] in table 'AuditLogs'
ALTER TABLE [dbo].[AuditLogs]
ADD CONSTRAINT [PK_AuditLogs]
    PRIMARY KEY CLUSTERED ([LogId] ASC);
GO

-- Creating primary key on [DepartmentId] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC);
GO

-- Creating primary key on [MenuID] in table 'SiteMenus'
ALTER TABLE [dbo].[SiteMenus]
ADD CONSTRAINT [PK_SiteMenus]
    PRIMARY KEY CLUSTERED ([MenuID] ASC);
GO

-- Creating primary key on [LinkId] in table 'QuickLinks'
ALTER TABLE [dbo].[QuickLinks]
ADD CONSTRAINT [PK_QuickLinks]
    PRIMARY KEY CLUSTERED ([LinkId] ASC);
GO

-- Creating primary key on [PostId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostId] ASC);
GO

-- Creating primary key on [User_UserId], [Roles_RoleId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY NONCLUSTERED ([User_UserId], [Roles_RoleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_UserId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_RoleId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Roles_RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRole]
    ([Roles_RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------