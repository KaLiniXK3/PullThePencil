using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameManager gameManager;

    private BallBaseState currentState;

    public BallBaseState CurrentState { get => currentState; }

    public readonly BallActiveState activeState = new BallActiveState();

    public readonly BallDeactiveState deactiveState = new BallDeactiveState();

    private void Start()
    {
        this.TransitionToState(this.deactiveState);
    }

    public void TransitionToState(BallBaseState state)
    {
        this.currentState = state;
        this.currentState.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
            this.currentState.OnCollisionEnter(this, collision);
    }

}
