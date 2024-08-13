-- Create the database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CampusEventMS')
BEGIN
    CREATE DATABASE CampusEventMS;
END
GO

-- Switch to the database context
USE CampusEventMS;
GO

-- Create the Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

-- Create the Events table
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Date DATETIME NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Create the AspNetUsers table
CREATE TABLE AspNetUsers (
    Id NVARCHAR(450) PRIMARY KEY,
    UserName NVARCHAR(256),
    NormalizedUserName NVARCHAR(256),
    Email NVARCHAR(256),
    NormalizedEmail NVARCHAR(256),
    EmailConfirmed BIT,
    PasswordHash NVARCHAR(MAX),
    SecurityStamp NVARCHAR(MAX),
    ConcurrencyStamp NVARCHAR(MAX),
    PhoneNumber NVARCHAR(MAX),
    PhoneNumberConfirmed BIT,
    TwoFactorEnabled BIT,
    LockoutEnd DATETIMEOFFSET,
    LockoutEnabled BIT,
    AccessFailedCount INT
);

-- Create the AspNetRoles table
CREATE TABLE AspNetRoles (
    Id NVARCHAR(450) PRIMARY KEY,
    Name NVARCHAR(256),
    NormalizedName NVARCHAR(256),
    ConcurrencyStamp NVARCHAR(MAX)
);

-- Create the AspNetUserRoles table
CREATE TABLE AspNetUserRoles (
    UserId NVARCHAR(450),
    RoleId NVARCHAR(450),
    PRIMARY KEY (UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id)
);

-- Create the AspNetUserClaims table
CREATE TABLE AspNetUserClaims (
    Id INT PRIMARY KEY IDENTITY,
    UserId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX),
    ClaimValue NVARCHAR(MAX),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

-- Create the AspNetUserLogins table
CREATE TABLE AspNetUserLogins (
    LoginProvider NVARCHAR(450),
    ProviderKey NVARCHAR(450),
    ProviderDisplayName NVARCHAR(MAX),
    UserId NVARCHAR(450) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

-- Create the AspNetUserTokens table
CREATE TABLE AspNetUserTokens (
    UserId NVARCHAR(450),
    LoginProvider NVARCHAR(450),
    Name NVARCHAR(450),
    Value NVARCHAR(MAX),
    PRIMARY KEY (UserId, LoginProvider, Name),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);

-- Create the AspNetRoleClaims table
CREATE TABLE AspNetRoleClaims (
    Id INT PRIMARY KEY IDENTITY,
    RoleId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX),
    ClaimValue NVARCHAR(MAX),
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id)
);
