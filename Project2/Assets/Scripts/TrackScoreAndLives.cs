using UnityEngine;
using UnityEngine.UI;

public class TrackScoreAndLives : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text livesText;

    public int score;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "  Score: " + score;
        livesText.text = "  Lives: " + lives;
    }
}