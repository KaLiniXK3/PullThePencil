using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Balls[] startBalls;

    public List<Balls> activeBalls;


    private void Start()
    {
        foreach (Balls ball in startBalls)
        {
            ball.TransitionToState(ball.activeState);
        }
    }
}
