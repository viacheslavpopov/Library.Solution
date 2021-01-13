# Library Catalog

#### Practice Project, Last Updated 01.11.2021

#### **By Chelsea Becker and Danielle Thompson**

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
2. _Open web browser and go to https://github.com/cschweig2/Library.Solution._
3. _After clicking the green "code" button, you can copy the URL for the repository._
4. _Open a terminal window, such as Command Prompt or Git Bash._<br>
  4a. _Type in this command: "git clone", followed by the URL you just copied. The full command should look like this: "git clone https://github.com/cschweig2/Library.Solution"._
5. _View the code on your favorite text editor, such as Visual Studio Code._

#### Download
1. _Click [here](https://github.com/cschweig2/Library.Solution) to view project repository._
2. _Click "Clone or download" to find the "Download ZIP" option._
3. _Click "Download ZIP" and extract files._
4. _Open the project in a text editor by clicking on any file in the project folder._

#### Import Database in MySQL Workbench
1. _Open MySQL Workbench and enter your password to open a server._
2. _From the top navigation bar, follow:_ ```Server > Data Import```.
4. _Select the option_ `Import from Self-Contained File`.
5. _Set_ `Default Target Schema` _or create new schema._
6. _Select the schema objects you would like to import_
7. _To finalize, click_ `Start Import`.

#### Import Database with SQL Schema

_Open MySQL Workbench and paste the following Schema Create Statement to replicate the database and its tables._

//TODO need to place schema here

#### Final Steps
1. _Navigate to the Library folder and enter "dotnet restore" in the command line to install packages._
2._After packages are installed in each of these folders, you may use "dotnet run" to both run and build the program._

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
    <td>Create a Bread class</td>
    <td>Bread bread = new Bread();</td>
    <td>bread</td>
  </tr>
</table>
<br>

## Stretch Goals

- Calling a logged-in user's name in the welcome message, not their user name (email, currently).


## Support and contact details

_If you run into any issues, you can contact the creators at chelraebecker@gmail.com & danithompson74@gmail.com, or make contributions to the code on GitHub via forking and creating a new branch._

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
  <tr>
    <td>Danielle Thompson</td>
    <td>https://github.com/dani-t-codes/</td>
    <td>danithompson74@gmail.com</td>
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

Copyright (c) 2020 **Chelsea Becker and Danielle Thompson**

Notes: For copies - if AuthorId and BookId in db are equal to new entry, increment 1 copy

Wed Notes:
- Delete button for "author this book belongs to" returns "Something went wrong" - looked like the route was incorrect in the browser's url
- Still can't correctly delete entries with join entry keys - might need to check if all join relationships are accounted for in the controllers in delete/deleteconfirmed
- Work on adding copies model back in & tie into checked out checkbox.