This readme is an brief overview of each item inside the project as well as background.

ABOUT THE PROJECT:
This project is based upon the layout from Complete Asp.Net Web Development Course by Brett Hargreaves on Udemy. After completion of the course I modified the solution and items to better fit my own wants and constraints of this project.

This project had a few goals in mind

1. Implement a useful God Team Rostering System with costs to purchase in relation to each god for the Hattiesburg Smite Amateur League. This allows new members to determine what gods work if they can not afford the Ultimate God pack as each god is only $4.99 while the Ultimate God Pack can run upwards of $99.99 while no on sale.
2. Create A resuable system that can be modified and used for multiple projects down the line.
3. Implement something that I had never done (In this case Microsoft Azure Cloud Database) in a way I had not used before.
4. Have fun and learn something new.

After completion I learned a fair bit more into how to properly use and create ASP.NET MVC applications and how to better apply SOLID principles to the design patterns involved in making a MVC project as well as how to leverage only a small fraction of the AZURE ecosystem to my advantage. 

The project in itself is a database system that updates product tables to display information and excerpts about gods for the oline MOBA SMITE. The main functionality allows for connection to a cloud database, creation, update, and deletion of items listed as products. I have also implemented a cool system for the ASP.NET Index homepage to allow the users to look at all gods and also sort by respective catagories. Also implemented is a cool basket system that uses stored cookies to load items about the application through HttpContext to display a currently saved team inside the basket that expires after seven days.

At a core level this works similarly to a ECommerce application as that was its' original intent. I used what I learned to leverage the system into a reimplementable multi class library system with an added WebUI. All in all I feel successful and plan on creating a much nicer looking V2 using Bootstrap at a later date. I will post this project as soon as I am able. 

PROJECT DETAILS:
Items are divided into two groups with respective detailed readmes at the bottom of each project:

1. Class Libraries
2. WebUI and relevent MVC systems

In comparison to traditional projects this project stems from a desire to segregate items from inside the normal ASP.NET MVC WEBUI style project into manageable class libraries for seperation of concerns and features.

The breakdown of Class Libraries

MyShop.Core - contains all releveant Models, Contract Interfaces, Root Classes, and View Models needed for the project. For Further Documentation check under the class Library Project MyShop.Core for a README at the bottom for further detail.

MyShop.DataAcess.InMemory - deprecated class library before the inclusion of a Microsoft Azure Database System. The original purpose of this library was to allow memory storage of items for testing of inital product and product category testing. Subsequent information can be found in the projects readme

MyShop.DataAcess.SQL - the primary link to the Azure Cloud DB. This linked library implements a connection through App.config as well as Handles all CodeFirst Migrations for the project. Subsequent information can be found in the projects respective readme.

MyShop.Services - this file is mainly used for cookie data use and HttpContext. This class library allows us to create a item basket as well as implement core requirements for storing items in cookies. The time limit for these cookies before timeout is 7 days. Further information can be found in the Projects README.

ASP.NET MVC Project:

MyShop.WebUI - the primary ASP.NET MVC project. This integrates all non deprecated class libraries to create a display of Main Shopping Menu, Cart Selection, Category items, and product managment systems. We also implement Untiy DI inside of App.Start UnityConfig. For further details on this part please please PLEASE take a look at the README at the bottom of the WebUI project.


Getting the project working:

primarily it should be good to go functionality wise out of the box. Major changes needed are as follows:

update SQL connection string to pertinent SQL implementation:

This current project used Microsoft Azure Cloud Database Storage through the Azure Software as a Platform system. If you are using this method a simple addition to MyShop.DataAccess.SQL/App.cong <connection string> as well as MyShop.WebUI/Web.Config  <connection string> will be necessary.

Other notes are to update the MyShop.DataAccess.SQL/DataContext connection string to be appropriately named to your current named connection string.

Quick TrobleShooting Errors to avoid:

1. Name your connection string to something other than the default connection name. MyShop.DataAccess.SQL and MyShop.WebUI both get grumpy when you do not rename connection strings. This bug is currently unknown and has not been successfully replicated in all scenarios.

2. For Code First Migrations Clear the Current Migrations Folder and implement your own migrations. This project works best when using proper Long Hand Entity Commands via the Package Manager Console (PMC)

examples:

EntityFramework\Enable-Migratons
EntityFramework\Add-Migration mymigrationName
EntityFramework\Update-Database 

More Detailed Models and View Models can be impletmented under MyShop.Core but make sure after installing the project that you run your Entity migrations and Enable Migrations for the project. 


for further issues, comments, questions, or concerns please contact me through github or comment under this project folder. I will be glad to be of assistance when ever possible.

-James Zachary Sherman


License:
SmiteVault is a Azure Connected ASP.NET MVC project implementing multiple class libraries, Depedency injection containers and MVC views and controls.
    Copyright (C) 2019  James Zachary Sherman

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

