using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDead;
    public static StartGameDelegate onReSpawnPickup;

    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void ScorePointsDelegate(int amt);
    public static ScorePointsDelegate onScorePoints;

    public static void StartGame()
    {
        if(onStartGame != null)
            onStartGame();
    }

    public static void ReSpawnpickup()
    {
        if (onReSpawnPickup != null)
            onReSpawnPickup();
    }

    public static void TakeDamage(float percent)
    {
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }

    public static void PlayerDeath()
    {
        if (onPlayerDead != null)
            onPlayerDead();
    }

    public static void ScorePoints(int score)
    {
        if (onScorePoints != null)
            onScorePoints(score);
    }
}
