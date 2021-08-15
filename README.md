# Library Catalog

#### Last Updated 01.11.2021


## Description

_A C#/.NET/MVC program designed to catalog a library's books and let patrons check them out._

## MySQL Designer Schema

[![Library-Schema.png](https://i.postimg.cc/zfJPFGs4/Library-Schema.png)](https://postimg.cc/RWDRM4VT)

## Specifications

<table>
<tr>
  <th>User Story #</th>
  <th>User Story</th>
  <th>Actualized</th>
</tr>
<tr>
  <td>1</td>
  <td>"As a librarian, I want to create, read, update, delete, and list books in the catalog, so that we can keep track of our inventory."</td>
  <td>True</td>
</tr>
<tr>
  <td>2</td>
  <td>"As a librarian, I want to enter multiple authors for a book, so that I can include accurate information in my catalog."</td>
  <td>True</td>
</tr>
<tr>
  <td>3</td>
  <td>"As a patron, I want to check a book out, so that I can take it home with me."</td>
  <td>Partially - librarian ("administrator") can check a patron out.</td>
</tr>
<tr>
  <td>4</td>
  <td>As a user, I want to know when a book that has been checked out is due, so that I know when it is due.</td>
  <td>True</td>
</tr>
</table>
<br>

## Setup/Installation Requirements

### Installing .NET Core Framework for Windows(10+) Users

1. _Download the 64-bit .NET Core SDK (Software Development Kit) by following this link: https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer._<br>
1a. _Follow prompts to begin your download. The download will be a .exe file. Click to install when it is finished downloading._
2. _After clicking the downloaded .exe file, follow the prompts in the installer and use suggested default settings._
3. _You can confirm a successful installation by opening a command line terminal and running the command $ dotnet --version, which should return a version number._


### Installing .NET Core Framework for Mac Users

1. _Download the .NET Core SDK by following this link: https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer._<br>
1a. _Follow prompts to begin your download. The download will be a .pkg file. Click to install when it is finished downloading._
2. _After clicking the downloaded .pkg file, follow the prompts in the installer and use suggested default settings._
3. _You can confirm a successful installation by opening a command line terminal and running the command $ dotnet --version, which should return a version number._

### Installing MySQL Workbench

1. _[Download and install](https://dev.mysql.com/downloads/workbench/) the version of MySQL Workbench suitable for your machine._

#### Import Database in MySQL Workbench
1. _Open MySQL Workbench and enter your password to open a server._
2. _From the top navigation bar, follow:_ `Server > Data Import`._
4. _Select the option_ `Import from Self-Contained File`._
5. _Click the `...` button to navigate to the project file folder `Library` and select `library.sql`._
5. _Set_ `Default Target Schema` _or create new schema._
6. _Select the schema objects you would like to import_
7. _To finalize, click_ `Start Import`._

#### Import Database with SQL Schema

_Open MySQL Workbench and paste the following Schema Create Statement to replicate the database and its tables._

```
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `authorbook`;
CREATE TABLE `authorbook` (
  `AuthorBookID` int NOT NULL AUTO_INCREMENT,
  `AuthorId` int DEFAULT NULL,
  `BookId` int DEFAULT NULL,
  PRIMARY KEY (`AuthorBookID`),
  KEY `IX_AuthorBook_AuthorId` (`AuthorId`),
  KEY `IX_AuthorBook_BookId` (`BookId`),
  CONSTRAINT `FK_AuthorBook_Authors_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `authors` (`AuthorId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_AuthorBook_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`BookId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `authors`;
CREATE TABLE `authors` (
  `AuthorId` int NOT NULL AUTO_INCREMENT,
  `AuthorName` longtext,
  PRIMARY KEY (`AuthorId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `bookpatron`;
CREATE TABLE `bookpatron` (
  `BookPatronId` int NOT NULL AUTO_INCREMENT,
  `BookId` int DEFAULT NULL,
  `PatronId` int DEFAULT NULL,
  PRIMARY KEY (`BookPatronId`),
  KEY `IX_BookPatron_BookId` (`BookId`),
  KEY `IX_BookPatron_PatronId` (`PatronId`),
  CONSTRAINT `FK_BookPatron_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`BookId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_BookPatron_Patrons_PatronId` FOREIGN KEY (`PatronId`) REFERENCES `patrons` (`PatronId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `books`;
CREATE TABLE `books` (
  `BookId` int NOT NULL AUTO_INCREMENT,
  `CheckedOut` bit(1) NOT NULL,
  `DueDate` datetime(6) NOT NULL,
  `Overdue` bit(1) NOT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `CopyId` int DEFAULT NULL,
  `Title` longtext,
  PRIMARY KEY (`BookId`),
  KEY `IX_Books_CopyId` (`CopyId`),
  KEY `IX_Books_UserId` (`UserId`),
  CONSTRAINT `FK_Books_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Books_Copies_CopyId` FOREIGN KEY (`CopyId`) REFERENCES `copies` (`CopyId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `checkout`;
CREATE TABLE `checkout` (
  `CheckoutId` int NOT NULL AUTO_INCREMENT,
  `PatronId` int DEFAULT NULL,
  `BookId` int DEFAULT NULL,
  PRIMARY KEY (`CheckoutId`),
  KEY `IX_Checkout_CopyId` (`BookId`),
  KEY `IX_Checkout_PatronId` (`PatronId`),
  CONSTRAINT `FK_Checkout_Copies_CopyId` FOREIGN KEY (`BookId`) REFERENCES `copies` (`CopyId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Checkout_Patrons_PatronId` FOREIGN KEY (`PatronId`) REFERENCES `patrons` (`PatronId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `copies`;
CREATE TABLE `copies` (
  `CopyId` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`CopyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `patrons`;
CREATE TABLE `patrons` (
  `PatronId` int NOT NULL AUTO_INCREMENT,
  `PatronName` longtext,
  PRIMARY KEY (`PatronId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```

#### Final Steps
1. _Navigate to the Library folder and enter "dotnet restore" in the command line to install packages._
2._After packages are installed in each of these folders, you may use "dotnet run" to both run and build the program._

## Technologies Used

_VS Code_ <br>
_C# 7.3.0_<br>
_.NET Core 2.2.0_<br>
_ASP.NET Core MVC_<br>
_Entity Framework Core 2.2.6_<br>
_MySQL Workbench 8.0 for Windows_
