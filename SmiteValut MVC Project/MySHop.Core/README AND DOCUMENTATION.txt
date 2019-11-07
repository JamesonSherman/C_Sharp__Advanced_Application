This readme is an breif overview of Each item inside the project

Items are devided into two groups:

1. Class Libraries
2. WebUI and relevent MVC systems

In comparison to traditional projects this project stems from a desire to segregate items from inside the normal ASP.NET MVC WEBUI style project into manageable sup class libraries for seperate concerns and features.

The breakdown of Class Libraries

MyShop.Core - contains all releveant Models, Contract Interfaces, Root Classes, and View Models needed for the project. For Further Documentation check under the class Library Project MyShop.Core for a README at the bottom for further detail.

MyShop.DataAcess.InMemory - deprecated class library before the inclusion of a Microsoft Azure Database System. The original purpose of this library was to allow memory storage of items for testing of inital product and product category testing. Subsequent information can be found in the projects readme

MyShop.DataAcess.SQL - the primary link to the Azure Cloud DB. This linked library implements a connection through App.config as well as Handles all CodeFirst Migrations for the project. Subsequent information can be found in the projects respective readme.

MyShop.Services - this file is mainly used for cookie data use and HttpContext. This class library allows us to create a item basket as well as implement core requirements for storing items in cookies. The time limit for these cookies before timeout is 7 days.

ASP.NET MVC Project:

MyShop.WebUI - the primary ASP.NET MVC project. This integrates all non deprecated class libraries to create a display of Main Shopping Menu, Cart Selection, Category items, and product managment systems. We also implement Untiy DI inside of App.Start UnityConfig.


Getting the project working:

primarily it should be good to go functionality wise out of the box. Major changes needed are as follows:

update SQL connection string to pertinent SQL implementation:

This current project used Microsoft Azure Cloud Database Storage through the Azure Software as a Platform system. If you are using this method a simple addition to MyShop.DataAccess.SQL/App.cong <connection string> as well as MyShop.WebUI/Web.Config  <connection string> will be necessary

Other notes are to update the MySHop.DataAccess.SQL/DataContext connection string to be appropriately named to your current named connection string.

Quick TrobleShooting Errors to avoid:

1. Name your connection string to something other than the default connection name. MyShop.DataAccess.SQL and MyShop.WebUI both get grumpy when you do not rename connection strings. This bug is currently unknown and has not been successfully replicated in all scenarios.

2. For Code First Migrations Clear the Current Migrations Folder and implement your own migrations. This project works best when using proper Long Hand Entity Commands via the Package Manager Console (PMC)

examples:

EntityFramework\Enable-Migratons
EntityFramework\Add-Migration mymigrationName
EntityFramework\Update-Database 

for further issues, comments, questions, or concerns please contact me through github or comment under this project folder. I will be glad to be of assistance when ever possible.

-James Zachary Sherman


Licsense:
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

