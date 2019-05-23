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
  ![SplashPage](Assassin/wwwroot/img/splash-screenshot.jpg?raw=true)
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| :-----:|
| Create a new game | Click "Start a new game" | redirected to new game instance create page |
| Create an account to play a game of assassin | Click "Sign Up" | redirected to join game view with game lobby authentication |
| Login to view your account details | Click "Login" | redirected to account authentication page |
| Review rules of the game | Click "Rules of the Game" | Taken to Rules page |

## Specs - "Rules" - Rules.cshtml

<p  align="center">
  ![SplashPage](Assassin/wwwroot/img/rules-screenshot.jpg?raw=true)
</p>


| Behavior | Input | Output |
| ------------- |:-------------:| :-----:|
| No user interactability Required | Effort | Knowledge |

## Specs - "New Game" - Games/New.cshtml

<p  align="center">
  ![SplashPage](Assassin/wwwroot/img/newgame-screenshot.jpg?raw=true)
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| :-----:|
| Input new lobby group name and password and personal player information |lobby name: -u Epicodus -p isgreat Player info: ... -CodeName Agent 007| New Game Lobby: Epicodus with one agent, Agent 007 as Admin |


## Specs - "Sign Up" - Players/New.cshtml

<p  align="center">
  ![SplashPage](Assassin/wwwroot/img/signup-screenshot.jpg?raw=true)
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| :-----:|
| Prompts user for game lobby name and password| -u Epicodus -p isgreat | Shows signup page |
| Allows player to create new agent for that specific game instance | Name: Oliver K. Email: Olly@DoA.com Password: pa55w0rd ... Code Name: Bobbers | Creates new Agent Bobbers in Epicodus game |

## Specs - "Login" - Login.cshtml

<p  align="center">
  ![SplashPage](Assassin/wwwroot/img/login-screenshot.jpg?raw=true)
</p>

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|
| Input email and password to enter agent player portal | Email: Olly@DoA.com Password: pa55w0rd | returns Agent Bobber's player view |

## Known Bugs

* URL security; any user can navigate through URLs into restricted views without any authentication given they know correct routing values
* IsGameOver() with one player will never evaluated to true and end the game. There must always be (n > 1) players.
* Using numbers as agent names confuses some of the Model references and will create infinite contract generation loops, resulting in an unwinnable game
* End game accolades ignore ties for kill-count awards and will grab the first instance without a tiebreaker or split
* Lots of missing authentication checks for form inputs throughout


## Support and contact details

_Should any problems occur, or any bugs discovered, please contact Brooke Kullberg at brookezkullberg@gmail.com_

## Technologies Used

_This program was written in C#/.Net with Entity Framework Core, using MVC and MySql.

### License

*This software is licensed under MIT license.*

Copyright (c) 2019 **_Brooke Kullberg, Reese Lee, Katlin Anderson, and Stuart McKay_**
