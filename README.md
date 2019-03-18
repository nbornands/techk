# techk
Actividad Trainee empresa Tech-K
Descripción de actividad solicitada: 
1.	Crear una vista (para cada uno) para ver los eventos, regiones y alumnos.
2.	El botón debe tener la siguiente funcionalidad (se entregan tres url para consumir Json)
2.1	Para Eventos debe ordenar por el campo time. Ejemplo: Si lo presiono la primera vez ordenara Ascenderte, luego, si lo vuelvo a presionar, lo debe ordenar de manera descendente
2.2	Para Regiones debe ordenar por el campo number. Mismo ejemplo que en la vista de eventos.
2.3	Para Alumnos debe ordenar o por edad o por el promedio de las notas. Ejemplo: En este caso, debe existir alguna manera de decidir porque quiero ordenar, pero el botón debe tener la misma funcionalidad que los 2 ejemplos anteriores.

Tecnología utilizada:
1.	ASP.Net
2.	NetFramework 4.0
3.	C#
4.	Visual Studio 2017 Community Edition (para desarrollo asp.net webforms)
5.	Librería para trabajos con objetos Json Newtonsoft.Json versión 12.0.0.0 (disponible en https://www.newtonsoft.com/)
6.	Framework Bootstrap 4.0  (disponible en https://getbootstrap.com/)
7.	Animaciones css mediante Animated.css (disponible en https://daneden.github.io/animate.css/)

Descripción del desarrollo:
Front-End:
Se crea una página de tipo webform y se maqueta con bloques de tipo div para contener todas las vistas solicitadas (alumnos, eventos, regiones y adicionalmente un bloque de inicio). Se crea una cabecera responsiva con cuatro botones de tipo asp:button para poner visible cada uno de los bloques según sea requerido. En cada bloque se utiliza un elemento asp:gridview para mostrar los datos del objeto Json consumido, y elementos de asp:button para controlar su orden. 
Se aplican estilos de Framework Bootstrap y Animate.css.
Back-End:
Se crean tres variables de tipo string para alojar el contenido de los objetos Json facilitados mediante url, estos son consumidos a través de objetos WebClient con encoding utf-8 para mostrar los caracteres que contengan acentos u otros símbolos. Mediante la librería Json.Net de NewtonSoft se deserializan los objetos Json y se convierten en objetos de tipo DataTable.
Finalmente se crean métodos para dar orden ascendente o descendente según los campos indicados en la descripción de la actividad utilizando objetos DataView para generar vistas de los DataTables antes mencionados y posteriormente ser convertidos a DataTable Nuevamente para ser usados como fuente de datos para cada objeto asp:gridview.
