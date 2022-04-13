## BackEnd Proyecto TruckSite

Este proyecto es una api hecha en C#, la cual es consumida por el proyecto en angular de TruckSite, permite agregar Clientes con conceptos diferentes
e ir recibiendo y mostrando los datos en una tabla, ademas contiene la logica para poder hacer un inicio de sesion; en esta api se pueden recibir 
modelos y enviar un objeto que contiene 3 propiedades:

exito: que puede ser 0 para un error y 1 para confirmar la respuesta correcta.

data: que puede contener cualquier objeto de este tipo, en este caso se va a llenar de una coleccion de datos para mostrar la lista de clientes y 
tambien una propiedad especifica.

mensajes: que es una propiedad extra, si queremos recibir un mensaje expecifico dependiendo de la respuesta.

Proyecto en Angular que consume la api: https://github.com/JosephGengar/AngularTruckSite

Muestra con Postman de los datos que envia y recibe la api:

![truck1](https://user-images.githubusercontent.com/102115164/163219427-8b3cbef4-0d16-419d-854b-b9a718b83612.png)

La solicitud Get devuelve la lista de clientes.

![truck2](https://user-images.githubusercontent.com/102115164/163219717-3e3fd0f4-f242-4dcb-85f1-ea6c44102d5e.png)

La solicitud Post Nos permite enviar datos para ser insertados en la base de datos, y vemos como recibimos una respuesta en base a la accion efectuada.

![truck3](https://user-images.githubusercontent.com/102115164/163219994-93180eb5-e667-48f0-b310-023498abd460.png)

Con la solicitud Delete eliminamos el regitro que elegimos por medio del Id del cliente, en esta caso asociado a la URL.

![truck4](https://user-images.githubusercontent.com/102115164/163220321-528bc979-8020-44ee-9c4b-c46246703155.png)

En esta caso vemos el Inicio de sesion que por medio de una solicitud post envia los datos a corroborar a la base de datos en nuestro controller y 
se efectua una respuesta, la cual en caso de ser exitosa, tambien devuelve un dato especifico en un objeto que luego sera usado en el localstorage 
del proyecto de angular.

Tecnologias Utilizadas: Lenguaje C# con Visual Studio Net Core, Entity Framework, SqlServer y Postman.
