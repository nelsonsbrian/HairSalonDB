# Hair Salon

#### Hair Salon with clients and stylists - September 21, 2018

#### By **Brian Nelson**

## Description

A simple website app that allows users to input hair salon stylists and clients in to a database within a html page. The ability to create, delete, view, and modify the database is available.

### Specs    

Game and GamePlay

| Spec | Input | Output | Why |
| :-----------------  | :------------- | :---------- | :----------- |
| **Create stylist class** |  |  |  |
| *Test ClearAll function* | 0 = "stylist.GetAll()" | true | Make sure that the database is able to properly remove all of the items |
| *Test create function* | "Jose" = "Jose" | true | Make sure the create command is properly storing data in the database |
| *Test GetAll function** | 3 = "stylist.GetAll()" | true | Make sure the GetAll is properly retrieving all of the items in the database |
| *Test Delete function* | 2 = "stylist.GetAll()" | true | Make sure the create command is properly storing data in the database |
| *Test Find function** | newstylist.Id = "Stylist.Find(id).Name" | true | Ensure the database returns the proper stylist after a find method is called |
| **Create client class** |  |  |  |
| *Test ClearAll function* | 0 = "client.GetAll()" | true | Make sure that the database is able to properly remove all of the items |
| *Test create function* | "Maggie" = "Maggie" | true | Make sure the create command is properly storing data in the database |
| *Test GetAll function* | 2 = "client.GetAll()" | true | Make sure the GetAll is properly retrieving all of the items in the database |
| *Test Delete function* | 0 = "client.GetAll()" | true | Make sure the create command is properly storing data in the database |
| *Test Find function* | "Maggie" = "client.Find().Name" | true | Ensure the database returns the proper client after a find method is called |

## Setup/Installation Requirements

* Clone this repository: https://github.com/nelsonsbrian/HairSalonDB.git

* To reproduce the database:
1. Create database named 'brian_nelson'
2. Create table named 'stylists' with columns 'id (primary), name, wage, start_date'
3. Create table named 'clients' with columns 'id (primary), name, address, phone, stylist_id'
* -or just host the included database.

## Known Bugs
* No known bugs at this time.

## Technologies Used
* C#
* Atom
* HTML/CSS
* MS Test
* MAMP
* MySql

## Support and contact details

_Brian Nelson nelsonsbrian@gmail.com_

### License

*{This software is licensed under the MIT license}*

Copyright (c) 2018 **_Brian Nelson_**
