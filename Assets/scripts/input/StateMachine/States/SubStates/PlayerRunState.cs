using UnityEngine;
using Unknown.StateMachine;

public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name, player, data)
    {
    }

    public override void Check()
    {
        base.Check();
        isWalking();
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
        player.Move(movementInput, playerData.runningSpeed);
    }

    private void isWalking()
    {
        if (!player.InputHandler.IsRunning)
        {
            stateMachine.ChangeState(player.WalkState);
        }
    }
}
