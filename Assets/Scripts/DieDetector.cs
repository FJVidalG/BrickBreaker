using UnityEngine;

public class DieDetector : MonoBehaviour
{
    private LevelController levelController;
    void Start()
    {
        levelController = GameObject.FindFirstObjectByType<LevelController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        levelController.OnDie();
    }
}
