# Phone Plan API C#

## Overview

The purpose is to demonstrate an implementation of how to create CRUD of Phone plans, with the following parameter.
- Minutes
- Internet
- Value
- Type (Pos, Pre, Control)
- Operator

To run this kind of project you need the minimum requirement **below**.

---

## Minimum Requirements:

* .NET 6
* Cmd plataform
* Git (to clone)

This is how you will install the .NET 6

https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60

---

## Run in cmd

After you cloned the project in your project folder, follow the folder and run this command on your CMD platform.

```
dotnet run
```

Must show a link hosted on the server like "localhost:7249".

This command could be run on different platforms, like Linux and macOS

---

### Tips
#### How to clone 

https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository

#### Command usage examples - dotnet run
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run

---

## Examples
The API to search the real estate will be:

### APIs

Swagger
```
https://localhost:7249/swagger/index.html
```

Example of request 
```
https://localhost:7249/api/{endpoint}
```

DDD
```
GET ​/api​/DDD
```

Operator
```
GET​/api​/Operator
```

PhonePlan
```
GET     /api​/PhonePlan
POST​    /api​/PhonePlan
GET​     /api​/PhonePlan​/ddd​/{ddd}
GET​     /api​/PhonePlan​/{id}
PUT​     /api​/PhonePlan​/{id}
DELETE​  /api​/PhonePlan​/{id}
```

PlanType
```
GET​/api​/PlanType
```

## OData Example for test by parameter
https://docs.microsoft.com/en-us/dynamics-nav/using-filter-expressions-in-odata-uris
```
GET​/api​/PhonePlan​/ddd​/48?filter:Value eq 50
GET​/api​/PhonePlan​/ddd​/48?filter:planType eq 1
GET​/api​/PhonePlan​/ddd​/48?filter:Operator eq 1
GET​/api​/PhonePlan​/ddd​/48?filter:Minutes gt 60
GET​/api​/PhonePlan​/ddd​/48?filter:Internet gt 500 
```
## Test

To test the project everything you need to do is execute this command below on your command platform on folder test.

```
dotnet test
```
---

## Docker
If you want to run this in a Container like Docker, you need to generate de image, and run the docker, and after that, 
you probly able to run like the request above.

```
Example docker run --rm -it p 7249:7249 phoneplan:latest
```
