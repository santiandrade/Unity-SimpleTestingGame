# Game Description

El juego consistirá en defender una posición del ataque de unos cubos malvados, durante un
tiempo determinado.

El jugador estará en un punto central del escenario, y podrá mirar a su alrededor, pero no
desplazarse. Podrá usar primera y tercera persona. El avatar puede ser una simple esfera.

El jugador tendrá un punto de mira para apuntar, y podrá disparar con el botón izquierdo.

El jugador tendrá un ‘retrovisor’, con el que verá qué ocurre a sus espaldas.

El escenario estará compuesto por un entorno abierto, con suelo, donde reposa el jugador. Se
puede decorar como se prefiera. Los cubos vendrán de lejos (preferiblemente apareciendo de
forma gradual, con algún efecto de transparencia, o por efecto de la niebla o la luz, en la
distancia), en dirección al jugador, moviéndose a base de ‘pasos de cubo’, rotando, no
deslizándose.

Los cubos, según el tipo, tendrán un color, un tamaño, un comportamiento, y unos puntos de
vida. A medida que el jugador les quite vida con sus disparos, el color de los cubos irá
apagándose, hasta perderlo. Entonces explotarán.

Si un cubo alcanza al jugador, explotará y hará que el jugador pierda una cantidad de vida
variable, dependiendo del tipo de cubo que sea.

Los cubos no deben solaparse entre sí. Si un cubo bloquea el camino de otro cubo, este último
deberá esperar a que el camino esté libre.

Existirán los siguientes tipos de cubos:

- Cubos simples: De tamaño mediano y velocidad media. Avanzan hacia el jugador en
línea recta. Tienen una cantidad media de vida, y quitan una cantidad media de vida.
- Pequeños cubos saltarines: Cubos pequeños, con poca vida y que hacen poco daño,
pero que ocasionalmente son capaces de saltar.
- Cubos zig-zag: Avanzan un número de pasos hacia el jugador, cambian de dirección
hacia la izquierda o la derecha (alternando en cada ocasión), y tras otro número de
pasos en esa dirección, vuelven a seguir avanzando hacia el jugador, y repiten la
secuencia. Cantidad media de vida, velocidad media, y daño medio.
- Cubos grandes: Más grandes, lentos, con más vida, y harán más daño.
- Cubos titán: Enormes, muy lentos, y con muchísima vida. Sólo podrá aparecer uno de
estos a la vez, y tras eliminar un número determinado de los demás cubos. Hará un
daño muy grande.

Cada tipo de cubo tendrá una probabilidad de aparición, salvo el Titán, que irá en función de
eliminaciones de cubos. Habrá un intervalo de apariciones, y un máximo de cubos vivos en
pantalla, todo configurable.

El jugador tendrá 3 tipos de armas:

- Ametralladora: Cadencia de disparo alta, cada proyectil hace un daño bajo, dispersión
de proyectiles media.
- Francotirador: Cadencia de disparo baja, cada proyectil hace un daño alto, dispersión
de proyectiles muy baja.
- Escopeta: Cadencia de disparo media, lanza varios proyectiles por disparo, daño medio
de proyectiles, dispersión de proyectiles alta.

Podrá cambiar de arma usando el teclado o la rueda del ratón.

La partida termina cuando el jugador pierde toda su vida o resiste hasta que se agote el tiempo.

La aplicación tendrá un menú inicial, donde se podrá seleccionar lo siguiente:

- Comenzar partida.
- Salir de la aplicación.

Habrá un menú durante el juego, el cual se invocará pulsando la tecla Escape, el cual pausará
la partida, y permitirá reanudarla, o abandonarla y volver al menú inicial.

La configuración podrá modificarse bien en un inspector de editor, o a través de un fichero en
disco (tipo texto, json, etc…).

El juego deberá anunciar el comienzo de la partida, y la razón por la que termina (mejor si se
anima de forma distinta cada caso, para por ejemplo, mostrar una celebración de victoria
cuando se resista hasta agotarse el tiempo). Cuando termine la partida por perder la vida o por
agotarse el tiempo, tras mostrarse el mensaje y animaciones correspondientes, se volverá al
menú inicial.

El jugador, durante la partida, tendrá un HUD en el que podrá ver el tiempo restante, la vida
que tiene, y el arma seleccionada.
