using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Level level;
    public GameOver gameOver;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;
    public Image[] stars;

     private int starIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i == starIndex;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if  (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = (i == visibleStar);
        }

         starIndex = visibleStar;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    //Update sub_text object depending on level type
    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                remainingSubText.text = "moves remaining";
                targetSubtext.text = "target score";
                break;
            case Level.LevelType.OBSTACLE:
                remainingSubText.text = "moves remaining";
                targetSubtext.text = "bubbles remaining";
                break;
            case Level.LevelType.TIMER:
                remainingSubText.text = "time remaining";
                targetSubtext.text = "target score";
                break;
        }
    }

    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, starIndex);
        if (starIndex > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, starIndex);
        }
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
