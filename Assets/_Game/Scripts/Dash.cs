using UnityEngine;

public class Dash : State
{
    private PlayerCharicter _charicter;
    private PlayerMovment _movment;
    private float _flytime =0;
    private float _speedMult = 2;
    public Dash(PlayerCharicter charicter, PlayerMovment movment) 
    {
        _charicter = charicter;
        _movment = movment;
        Debug.Log("State : Dash");
    }
    public override void Enter()
    {
        base.Enter();
        _flytime = _movment._flyTime;
        _movment._flyTime = float.MaxValue;
        _movment._moveSpeed *= _speedMult;
    }

    public override void Exit()
    {
        base.Exit();
        _movment._flyTime = _flytime;
        _movment._moveSpeed /= _speedMult;
        Debug.Log("Dash end");
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        _charicter.blood -= .5f;
       
    }
}
