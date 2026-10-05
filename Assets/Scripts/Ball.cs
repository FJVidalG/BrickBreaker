using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private LevelController levelController;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelController = FindFirstObjectByType<LevelController>();
    }

    void Update()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;

    }

    public void Launch(Vector2 dir)
    { 
        GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Brick") 
    {
        levelController.OnBrickCollided(collision.gameObject.GetComponent<Brick>());
    }
}

}
