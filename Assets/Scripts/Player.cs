using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private Ball ball;
    private FixedJoint2D joint;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float playerWidth = 2.5f;
    private float leftBorder;
    private float rightBorder;
    private Vector2 dragDistance;

    [SerializeField] private float width = 2f;

    [SerializeField] private Transform leftCircle; // extremo izquierdo del player
    [SerializeField] private Transform center; // centro (rectangulo) del player
    [SerializeField] private Transform rightCircle; // extremo derecho del player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();         
        mainCamera = Camera.main; 
        leftBorder = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x + playerWidth / 2; // calculamos el borde izquierdo de la pantalla sumando la mitad del ancho del jugador, si no sobresaldría
        rightBorder = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x - playerWidth / 2; // igual pero en esta ocasión restando la mitad del jugador

        joint = GetComponent<FixedJoint2D>();
        StartCoroutine(LaunchBall());
        UpdateWidth();


    }

    private IEnumerator LaunchBall()
    {
        yield return new WaitForSeconds(2f);

        joint.enabled = false;

        float playerVelocityX = rb.linearVelocity.x; 
        Vector2 directionBall = new Vector2(playerVelocityX, 1f); 

        ball.Launch(directionBall);
    }




    void Update()
    {
        // Control por teclado (flechas izq y der)
        float moveInput = Input.GetAxis("Horizontal"); // entrada en el eje x
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, 0); // asignamos la velocidad al rigidbody (solo eje x , y = 0)


    }

    // Control con el ratón
    void OnMouseDown()
    { // método que se llama automaticamente cuando haces clic en el player
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); // convertimos la posición del ratón a coordenadas del mundo
        dragDistance = new Vector2(transform.position.x - mousePosition.x, 0f); // calculamos la distancia entre el centro del player y el clic
    }

    void OnMouseDrag()
    { // método que se llama automaticamente mientras haces clic en el player
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); // obtenemos la posicion del raton en coordenadas del mundo
        float targetX = mousePosition.x + dragDistance.x; // posicion del player ajustada a la distancia del clic respecto del centro del player

        targetX = Mathf.Clamp(targetX, leftBorder, rightBorder); // limitamos dentro de los bordes

        Vector2 newPosition = new Vector2(targetX, rb.position.y); // creamos la nueva posición
        rb.MovePosition(newPosition); // movemos el player a la nueva posición
    }

    public void RespawnBall() // metodo para hacer Respawn de la pelota
    {

        ball.transform.position = (Vector2)transform.position + Vector2.up * 0.5f; // movemos la pelota a la posicion por encima del player
        joint.enabled = true; // volvemos a activar el fixed
        StartCoroutine(LaunchBall()); // volvemos a iniciar la corutina
    }

    private void OnValidate() // método que se llama automáticamente cada vez que se hace una modificacion en tiempo de ejecucion desde el inspector
    {
        UpdateWidth();
    }

    private void UpdateWidth() // metodo para cambiar el tamaño del jugador
    {
        center.localScale = new Vector2(width, center.localScale.y);

        float halfWidth = width / 2f;
        leftCircle.localPosition = new Vector2(-halfWidth, 0);
        rightCircle.localPosition = new Vector2(halfWidth, 0);
    }


}

