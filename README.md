# please at first check the link for  se Sql Part Exercises:
```sh
https://github.com/guga2002/Unicard.Api/blob/ca2aa1b864a137ae2091cb27b1565897de1b3548/SQLSIdeReadMe.md
```
# Bank.Unicard.API
The Unicard Universal Loyalty Program provides you an opportunity to get three types of benefits:
- points
- discounts
- gifts with any purchase at participating partner organizations.

# Project Description
Unicard.APi is designed to support various aspects of Online Store management, including Crud operation, The API offers endpoints for managing data related cases, fields,
Orders, and resources<br>

# Getting Started
Here you can find instructions to set up and configure the project on your
local machine for development and testing purposes.

# Prerequisites
To set up the project, you need to have the following tools installed:<br>

```sh
NET Core SDK (version 8.0 or later)
  ```

```sh
Visual Studio or Visual Studio Code
```
```sh
SQL Server or another compatible database
```

# Installation
Clone the repository to your local machine:
```sh
git clone https://github.com/guga2002/Unicard.Api.git
```
Navigate to the project directory:<br>
```sh
cd UniCard.Api
```

- install the required packages:
```sh
dotnet restore
```
# Configuration:
- Configure the appsettings.json file with your database connection settings.
- Run the database migrations:
```sh
dotnet ef database update
```

# Running the Application
- You can run the application using the following command:
```sh
dotnet run
```

The project will be available at Localhost 
```sh
http://localhost:5000 or port check in appseting.json
```

# Usage
You can use any API client to interact with the API
```sh
Postman
```
```sh
 Swagger
```

# Some Endpoints

- GET /api/Orders - Retrieve a list of all Orders
- POST /api/Order - Create a new Order
- GET /api/Product - Retrieve a list of all Products
- GET /api/Users - getting users from DB
  For detailed API documentation and further usage examples, refer to the API documentation available at
  http://localhost:5000/swagger.

# Relational models:
![2024-07-06 (1)](https://github.com/guga2002/Unicard.Api/assets/74540934/b61880c4-599e-4cec-9842-a801d17f9bd3)


# Used Architecture:

![image](https://github.com/guga2002/Unicard.Api/assets/74540934/63a00d4a-8b11-48e0-9de1-dc5d7c2bd068)

- **onion Architecture**
- **UniteOfWork Pattern**
- **solid Pricncipes**
- **DI for IOC** ( Inversion of controll)
- **Restfull principes**
- Dapper  For Data access
- Ef for Code First

# License
This project is licensed under the MIT License 
- contanct me  for licence : **aapkhazava22@gmail.com**

 # Contributing
If you would like to contribute to the project, please:
- **fork the repository**
- **submit a pull request**
- for major changes,please open an issue first to discuss what you would like to change.
# Contact
For any questions or suggestions, please contact:
- **Author**: Guga Apkhazava
- **Email**: guram.apkhazava908@ens.tsu.ge



