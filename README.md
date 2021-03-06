# Dr. Sillystringz's Factory

#### Independent Code Review, Last Updated 01.07.2021

#### **By Chelsea Becker**

## Description

_An application that will keep track of machine repairs within Dr. Sillystringz's Factory._

## Specifications

<table>
<tr>
  <th>User Story #</th>
  <th>User Story</th>
  <th>Actualized</th>
</tr>
<tr>
  <td>1</td>
  <td>"As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines."</td>
  <td>True</td>
</tr>
<tr>
  <td>2</td>
  <td>"As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it."</td>
  <td>True</td>
</tr>
<tr>
  <td>3</td>
  <td>"As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed."</td>
  <td>True</td>
</tr>
<tr>
  <td>4</td>
  <td>"As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed."</td>
  <td>True</td>
</tr>
<tr>
  <td>5</td>
  <td>"As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine."</td>
  <td>True</td>
</tr>
<tr>
  <td>6</td>
  <td>"I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it."</td>
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

### View locally/Project Setup

#### Clone
1. _Follow above steps to install .NET Core._
2. _Open web browser and go to https://github.com/cschweig2/Factory.Solution._
3. _After clicking the green "code" button, you can copy the URL for the repository._
4. _Open a terminal window, such as Command Prompt or Git Bash._<br>
  4a. _Type in this command:_ `git clone`_, followed by the URL you just copied. The full command should look like this: "git clone https://github.com/cschweig2/Factory.Solution"._
5. _View the code on your favorite text editor, such as Visual Studio Code._

#### Download
1. _Click [here](https://github.com/cschweig2/Factory.Solution) to view project repository._
2. _Click "Clone or download" to find the "Download ZIP" option._
3. _Click "Download ZIP" and extract files._
4. _Open the project in a text editor by clicking on any file in the project folder._

#### Import Database in MySQL Workbench
1. _Open MySQL Workbench and enter your password to open a server._
2. _From the top navigation bar, follow:_ `Server > Data Import`_._
4. _Select the option_ `Import from Self-Contained File`_._
5. _Click the_ `...` _button to navigate to the project file folder_ `Factory` _and select_ `factory.sql`.
5. _Set_ `Default Target Schema` _or create new schema._
6. _Select the schema objects you would like to import._
7. _To finalize, click_ `Start Import`_._

#### Import Database with Entity Framework Core/Command Line
1. _Navigate to the_ `Factory` _project folder and enter_ `dotnet ef database update` _in the command line, which will create the database in MySQL Workbench using the migrations from the_ `Migrations` _folder._

#### Import Database with SQL Schema

_Open MySQL Workbench and paste the following Schema Create Statement to replicate the database and its tables:_

```
CREATE DATABASE IF NOT EXISTS chelsea_becker;
USE chelsea_becker;

DROP TABLE IF EXISTS `_efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `engineermachine`;
CREATE TABLE `engineermachine` (
  `EngineerMachineId` int NOT NULL AUTO_INCREMENT,
  `EngineerId` int DEFAULT NULL,
  `MachineId` int DEFAULT NULL,
  PRIMARY KEY (`EngineerMachineId`),
  KEY `IX_EngineerMachine_EngineerId` (`EngineerId`),
  KEY `IX_EngineerMachine_MachineId` (`MachineId`),
  CONSTRAINT `FK_EngineerMachine_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
  CONSTRAINT `FK_EngineerMachine_Machines_MachineId` FOREIGN KEY (`MachineId`) REFERENCES `machines` (`MachineId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `engineers`;
CREATE TABLE `engineers` (
  `EngineerId` int NOT NULL AUTO_INCREMENT,
  `EngineerName` longtext,
  `License` longtext,
  PRIMARY KEY (`EngineerId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `machines`;
CREATE TABLE `machines` (
  `MachineId` int NOT NULL AUTO_INCREMENT,
  `MachineName` longtext,
  `LicenseReqd` longtext,
  PRIMARY KEY (`MachineId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```



//TODO need to place schema here

#### Final Steps
1. _Navigate to the_ `Factory` _and_ `Factory.Tests` _folders and enter_ `dotnet restore` _in the command line to install packages._
2._After packages are installed in each of these folders, navigate to the_ `Factory` _folder and enter_ `dotnet run` _in the command line to both run and build the program._

## Known Bugs

No known bugs at this time.

## Test Specs

<table>
  <tr>
    <th>Test #</th>
    <th>Expected Behavior</th>
    <th>Input</th>
    <th>Output</th>
  </tr>
  <tr>
    <td>1</td>
    <td></td>
    <td></td>
    <td></td>
  </tr>
</table>
<br>


## Support and contact details

_If you run into any issues, you can contact the creator at chelraebecker@gmail.com, or make contributions to the code on GitHub via forking and creating a new branch._

## Contributors

<table>
  <tr>
    <th>Author</th>
    <th>GitHub Profile</th>
    <th>Contact Email</th>
  </tr>
  <tr>
    <td>Chelsea Becker</td>
    <td>https://github.com/cschweig2</td>
    <td>chelraebecker@gmail.com</td>
  </tr>
</table>

## Technologies Used

_VS Code_ <br>
_C# 7.3.0_<br>
_.NET Core 2.2.0_<br>
_ASP.NET Core MVC_<br>
_Entity Framework Core 2.2.6_<br>
_MySQL Workbench 8.0 for Windows_

## Legal

*This software is licensed under the MIT license.*

Copyright (c) 2020 **Chelsea Becker**