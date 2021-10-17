using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacles : Level
{
    public int numMoves;
    public Layer.PieceType[] obstacleTypes;

    private int movesUsed = 0;
    private int numObstaclesLeft;
    // Start is called before the first frame update
    void Start()
    {
        var type = LevelType.OBSTACLE;

        for (int i = 0; i < obstacleTypes.Length; i++)
	    {
	        numObstaclesLeft += grid.GetPiecesOfType(obstacleTypes[i]).Count;
	    }

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

    public override void OnMove()
    {
        movesUsed++;

        hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if (obstacleTypes[i] != piece.Type) continue;
            
            numObstaclesLeft--;
            hud.SetTarget(numObstaclesLeft);

            if (numObstaclesLeft != 0) continue;
            currentScore += 1000 * (numMoves - movesUsed);
            hud.SetScore(currentScore);
            GameWin();
        }
    }
}
