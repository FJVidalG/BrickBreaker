using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int score = 0;
    private int totalBricks;
    [SerializeField] int lives = 3;
    [SerializeField] float timeLimit = 90f;

    private Player player;
    private string message = "";
    private bool finished = false;

    void Start()
    {
        StartCoroutine(InitLevel());
    }

    void Update()
    {
        if (finished) return;

        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0)
        {
            timeLimit = 0;
            StartCoroutine(Restart("Tiempo agotado"));
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = Screen.height / 25;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 10, 400, 60), "Puntos: " + score, style);
        GUI.Label(new Rect(Screen.width / 2 - 60, 10, 200, 60), "Vidas: " + lives, style);
        GUI.Label(new Rect(Screen.width - 200, 10, 200, 60), "Tiempo: " + Mathf.CeilToInt(timeLimit), style);

        if (message != "")
        {
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = Screen.height / 12;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), message, style);
        }
    }

    private void RemoveBrick(Brick brick)
    {
        Destroy(brick.gameObject);
    }

    public void OnBrickCollided(Brick brick)
    {
        RemoveBrick(brick);
        score++;

        if (score >= totalBricks)
        {
            StartCoroutine(Restart("¡Has ganado!"));
        }
    }

    private IEnumerator Restart(string text)
    {
        finished = true;
        message = text;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnDie()
    {
        if (finished) return;

        lives--;
        if (lives > 0)
        {
            player.RespawnBall();
        }
        else
        {
            StartCoroutine(Restart("Fin de la partida"));
        }
    }

    private IEnumerator InitLevel() // para retrasar la obtencion de totalBricks y que no salte la victoria del tiron
    {
        yield return null;
        totalBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        player = FindFirstObjectByType<Player>();
    }
}
