public class LevelMoves : Level
{
    public int numMoves;
    public int targetScore;

    private int movesUsed = 0;
    // Start is called before the first frame update
    void Start()
    {
       var type = LevelType.MOVES;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(numMoves); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        movesUsed++;

        hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed != 0) return;
        
        if (currentScore >= targetScore)
        {
            GameWin();
        }
        else
        {
            GameLose();
        }
    }
}
