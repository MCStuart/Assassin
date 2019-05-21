# _Assassin_

#### _C# Group Project, 05.23.2019_

#### By _Reese Lee, Katlin Anderson, Stuart McKay, and Brooke Kullberg_

## Description
_This is a website for the Assassin game._

## Setup/Installation Requirements: Database

_To download and import the database:_

* _Start MAMP and click Open WebStart page in the MAMP window._
* _In the website you're taken to, select phpMyAdmin from the Tools dropdown._
* _Select the Import tab._
* _Note that it's important to make sure you're not importing to a database that already exists, so make sure that a database with the same name as the one you're importing isn't already present._
* _Select your database file, and click Go._

_To make your own database in MySql shell:_

* _CREATE DATABASE assassins;_
* _USE assassins;_
* _CREATE TABLE contracts (id serial PRIMARY KEY, game_id INT, assassin_id INT, contract_start DATETIME, contract_end DATETIME, is_fulfilled INT, weapon TEXT);_
* _CREATE TABLE games (id serial PRIMARY KEY, team_name TEXT, password TEXT, is_start INT, is_end INT);_
* _CREATE TABLE players (id serial PRIMARY KEY, is_alive INT, assassin_id INT, name TEXT, password TEXT, email TEXT, code_name TEXT, game_id INT, spoon_score INT, sock_score INT, phone_number TEXT, image_url TEXT, is_admin INT);_

## Setup/Installation Requirements: Program

* _Open via GitHub repository by going to <https://github.com/BrookeZK/Assassin>._
* _In your command line (Terminal or another program), navigate to your desktop._
* _In your command line, type "git clone https://github.com/BrookeZK/Assassin" to clone the repository to your desktop._
* _Open MAMP, or your equivalent. Start your servers. Navigate to the "Import" tab, and choose assassin.sql in the top level of the Assassin folder. Click "go" to import this database._
* _In your command line, navigate into the new folder "Assassin", then into the subfolder "Assassin"._
* _Once inside "Assassin," type "dotnet run", and your terminal will inform you that the program is running on <http://localhost:5000>._
* _Finally, put the url <http://localhost:5000> into your web browser and the program will open._


## Specs - "Landing Page" - Index.cshtml

<p  align="center">
  <img src="~/img/homePage.png" alt="image of homepage" height="80%" width="80%">
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|


## Specs - "Rules" - Rules.cshtml

<p  align="center">
  <img src="~/img/aboutFAQpage.png" height="80%" width="80%">
</p>


| Behavior | Input | Output |
| ------------- |:-------------:| -----:|

## Specs - "New Game" - Games/New.cshtml

<p  align="center">
  <img src="~/img/mapPage.png" height="80%" width="80%">
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|

## Specs - "Sign Up" - Players/New.cshtml

<p  align="center">
  <img src="~/img/resourcesPage.png" height="80%" width="80%">
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|

## Specs - "Login" - Login.cshtml

<p  align="center">
  <img src="~/img/resourcesPage.png" height="80%" width="80%">
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|

## Known Bugs

_There are no known bugs, but this webpage is best viewed on a full screen._

## Support and contact details

_Should any problems occur, or any bugs discovered, please contact Ashley Ancheta at ashleyjancheta@gmail.com_

## Technologies Used

_This program was written in HTML and JavaScript, using the JQuery library. It was styled with CSS, using Bootstrap as well as custom styling._

### License

*This software is licensed under MIT license.*

Copyright (c) 2019 **_Brooke Kullberg, Megan Schulte, Ashley J. Ancheta, and Hannah Melendy_**
