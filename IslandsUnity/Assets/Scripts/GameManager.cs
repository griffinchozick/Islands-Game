using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Island allyIsland;
    public Island enemyIsland;
    public bool gameOver;

    public void CheckGameOver() {
        if (allyIsland.totalTakenUpSpots == 25)
        {
            Debug.Log("Player 2 Wins");
            gameOver = true;
        }
        else if (enemyIsland.totalTakenUpSpots == 25)
        {
            Debug.Log("Player 1 Wins");
            gameOver = true;
        }
    }
}
