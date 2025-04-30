using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
    public State CurrentState { get; private set; }
    private State _previousState;

    private bool _inTransition = false;

    public void ChangeStates(State newState) 
    {
        if (CurrentState == newState || _inTransition)
            return;
        ChangeStatesSequence(newState);
    }

    private void ChangeStatesSequence(State newState) 
    {
        _inTransition = true;
        CurrentState?.Exit();
        StoreStateAsPrevious(newState);

        CurrentState = newState;
        CurrentState?.Enter();
        _inTransition = false;

    }

    private void StoreStateAsPrevious(State newState) 
    {
        if (_previousState == null && newState != null)
            _previousState = newState;
        else if (_previousState != null && newState != null)
            _previousState = CurrentState;
    }
    public void ChangeStateToPrevious() 
    {
        if (_previousState != null) 
        {
            ChangeStates(_previousState);
        }
    }

    protected virtual void Update() 
    {
        if (CurrentState != null && !_inTransition) 
        {
            CurrentState.Tick();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (CurrentState != null && !_inTransition)
        {
            CurrentState.FixedTick();
        }
    }

    protected virtual void OnDestroy() 
    {
        CurrentState?.Exit();
    }
}
