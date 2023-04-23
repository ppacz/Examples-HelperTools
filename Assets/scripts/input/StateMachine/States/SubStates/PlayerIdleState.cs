using UnityEngine;
using Unknown.StateMachine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name, player, data)
    {
    }

    public override void Check()
    {
        base.Check();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(movementInput.magnitude != 0)
        {
            stateMachine.ChangeState(player.WalkState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
