using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };

    public Layer grid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected int currentScore;

    private bool didWin;
    // Start is called before the first frame update
    void Start()
    {
        hud.SetScore(currentScore);
    }

    public virtual void GameWin()
    {
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {     
        grid.GameOver();   
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {
       
    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

   protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return null;
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
