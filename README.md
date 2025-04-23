# Examen_2_AppServWEB_Mi_18_20
Examen evaluativo de la asignatura Aplicaciones y Servicios Web. 
Realiado por:
**Johan Esteba Arias y Yeison Andres Sanchez Rodas**

## Indice
- [Descripción del Problema](#Descripción-del-Problema)
	- [Se solicita](#Se-solicita)
- [Diagrama](#diagrama-modelo-relacional)

## Descripción del Problema ❔
Una natillera está interasada en crear un servicio para grabar los eventos que se definen para 
recoger fondos.



### Se solicita : ✏️ ✔️
- El registro solo está habilitado para administradores de la natillera, los cuales
deben tener un usuario y una clave (La clave es plana, sin ningún tipo de inscripción).
Para poder utilizar el servicio, se requiere de una autenticación con Bearer Token.
- Debe registrar los datos del evento: el tipo de evento (Baile, bingo, fiesta, rifa, etc), nombre
del evento, el total del ingreso del evento, la fecha en la que se realizó, la sede donde se hizo
el evento, y las actividades que se planearon y/o ejecutaron (Es un texto libre).
- Debe permitir registrar el evento, consultarlo (Por tipo, nombre y fecha), actualizarlo, y eliminarlo.
- No se debe hacer un servicio para registrar a los administradores, pero si se debe generar el token con 
base en la información del administrador (Hacer el registro del administrador por base de datos 
con instrucciones insert, o métodos similares)

  
## Diagrama (Modelo Relacional)📎
![Modelo Relacional.png]()
