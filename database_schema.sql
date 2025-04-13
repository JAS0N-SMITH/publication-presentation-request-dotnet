-- SQL script for Users Table
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    AzureAdObjectId NVARCHAR(64) NOT NULL,
    DisplayName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Department NVARCHAR(255),
    DeletedAt DATETIME
);

-- Added UNIQUE constraints to ensure data integrity
ALTER TABLE Users ADD CONSTRAINT UQ_AzureAdObjectId UNIQUE (AzureAdObjectId);
ALTER TABLE Users ADD CONSTRAINT UQ_Email UNIQUE (Email);

-- SQL script for Requests Table
CREATE TABLE Requests (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Type NVARCHAR(50) NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Abstract NVARCHAR(MAX),
    Authors NVARCHAR(MAX),
    SubmitterId UNIQUEIDENTIFIER NOT NULL,
    CurrentStage NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy UNIQUEIDENTIFIER,
    UpdatedBy UNIQUEIDENTIFIER,
    DeletedAt DATETIME,
    FOREIGN KEY (SubmitterId) REFERENCES Users(Id)
);

-- Added indexes for frequently queried columns
CREATE INDEX IDX_Requests_Status ON Requests (Status);
CREATE INDEX IDX_Requests_SubmitterId ON Requests (SubmitterId);

-- SQL script for RequestStages Table
CREATE TABLE RequestStages (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RequestId UNIQUEIDENTIFIER NOT NULL,
    Stage NVARCHAR(50) NOT NULL,
    StartedAt DATETIME NOT NULL,
    EndedAt DATETIME,
    ActorId UNIQUEIDENTIFIER NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (RequestId) REFERENCES Requests(Id),
    FOREIGN KEY (ActorId) REFERENCES Users(Id)
);

-- Added indexes for frequently queried columns
CREATE INDEX IDX_RequestStages_RequestId ON RequestStages (RequestId);

-- SQL script for RequestDetails Table
CREATE TABLE RequestDetails (
    RequestId UNIQUEIDENTIFIER PRIMARY KEY,
    FundingInfo NVARCHAR(MAX),
    PresentationType NVARCHAR(100),
    Venue NVARCHAR(255),
    PresentationDate DATETIME,
    NeedsTravel BIT DEFAULT 0,
    MaterialsUrl NVARCHAR(500),
    FOREIGN KEY (RequestId) REFERENCES Requests(Id)
);

-- SQL script for RequestLogs Table
CREATE TABLE RequestLogs (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    RequestId UNIQUEIDENTIFIER NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    ActorId UNIQUEIDENTIFIER NOT NULL,
    Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (RequestId) REFERENCES Requests(Id),
    FOREIGN KEY (ActorId) REFERENCES Users(Id)
);

-- Added indexes for frequently queried columns
CREATE INDEX IDX_RequestLogs_RequestId ON RequestLogs (RequestId);