# BrickBreaker

Juego de romper ladrillos en 2D hecho con Unity. Práctica del ciclo de Desarrollo de Aplicaciones Multiplataforma.

**Jugar en el navegador: https://fjvidalg.github.io/BrickBreaker/**

La pala lanza la pelota a los dos segundos de empezar. Hay que romper todos los ladrillos antes de que se acabe el tiempo.

## Controles

| Control | Acción |
|---|---|
| Flechas izquierda y derecha | Mover la pala |
| Arrastrar con el ratón | Mover la pala |

## Mecánicas

- Tres vidas y 90 segundos por partida.
- La dirección de salida de la pelota depende de cómo se esté moviendo la pala al lanzarla.
- El muro de ladrillos se genera por código al empezar, en una cuadrícula de 5 x 5.
- Al ganar, perder o quedarse sin tiempo se muestra un mensaje y la partida vuelve a empezar.

## Estructura

| Script | Qué hace |
|---|---|
| `Player` | Movimiento con teclado y ratón, lanzamiento de la pelota y ancho de la pala |
| `Ball` | Velocidad constante y choque con los ladrillos |
| `BrickWall` | Genera la cuadrícula de ladrillos a partir de prefabs |
| `Brick` | Identifica a los ladrillos |
| `LevelController` | Puntos, vidas, tiempo, marcador y fin de partida |
| `DieDetector` | Zona inferior que resta una vida |

## Tecnologías

Unity 6 (6000.0.31f1), C#, física 2D.

Los gráficos son de dominio público o generados con IA.

## Abrir el proyecto

Clonar el repositorio y abrir la carpeta desde Unity Hub con la versión 6000.0.31f1 o posterior. La primera vez Unity regenera la carpeta `Library`, que no se sube al repositorio.

## Autor

Francisco Jesús Vidal García. [Portfolio](https://fjvidalg.github.io) | [LinkedIn](https://www.linkedin.com/in/francisco-jesus-vidal-garcia)
