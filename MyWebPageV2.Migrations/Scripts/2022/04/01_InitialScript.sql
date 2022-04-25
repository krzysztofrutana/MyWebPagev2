CREATE TABLE [FileAttachments] (
	[Id] int NOT NULL PRIMARY KEY,
    [Path] varchar(400) NOT NULL,
    [Name] varchar(255) NOT NULL,
    [Mime] varchar(255) NOT NULL,
    [Type] varchar(255) NOT NULL,
)
GO

CREATE TABLE [Projects] (
	[Id] int NOT NULL PRIMARY KEY,
    [NameJSON] varchar(400) NOT NULL,
    [LogoId] int NULL,
    [ShortDiscriptionJSON] varchar(800) NULL,
    [DiscriptionJSON] MEDIUMTEXT NULL,
    [RequirementsJSON] varchar(1000) NULL,
    [Technologies] varchar(500) NULL,
    [License] varchar(255) NULL,
    [SourceLink] varchar(255) NULL,
    [Platform] varchar(255) NULL,
    [DownloadFileId] int NULL,
    [ProjectType] varchar(255) NULL,

    CONSTRAINT FK_ProjectsLogoId FOREIGN KEY ([LogoId]) REFERENCES [FileAttachments]([Id]),
    CONSTRAINT FK_ProjectsDownloadFileId FOREIGN KEY ([DownloadFileId]) REFERENCES [FileAttachments]([Id])
)
GO

CREATE INDEX IX_ProjectsLogoId ON [Projects]([LogoId])
GO

CREATE INDEX IX_ProjectsDownloadFileId ON [Projects]([DownloadFileId])
GO


CREATE TABLE [ProjectToFileRelations] (
	[Id] int NOT NULL PRIMARY KEY,
     [FileId] int NOT NULL,
     [ProjectId] int NOT NULL,

     CONSTRAINT FK_ProjectToFileRelationsFileId FOREIGN KEY ([FileId]) REFERENCES [FileAttachments]([Id]),
     CONSTRAINT FK_ProjectToFileRelationsProjectId FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]),
)
GO

CREATE INDEX IX_ProjectToFileRelationsFileId ON [ProjectToFileRelations]([FileId])
GO

CREATE INDEX IX_ProjectToFileRelationsProjectId ON [Projects]([ProjectId])
GO

ALTER TABLE [ProjectToFileRelations]
ADD CONSTRAINT UX_FileIdProjectId UNIQUE ([FileId], [ProjectId]);