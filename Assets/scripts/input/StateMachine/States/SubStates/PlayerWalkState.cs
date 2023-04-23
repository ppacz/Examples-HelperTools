using UnityEngine;
using Unknown.StateMachine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name, player, data)
    {
    }

    public override void Check()
    {
        base.Check();
        isRunning();
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
        if (movementInput.magnitude == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.Move(movementInput, playerData.walkingSpeed);
    }

    private void isRunning()
    {
        if (player.InputHandler.IsRunning)
        {
            stateMachine.ChangeState(player.RunState);
        }
    }
}
