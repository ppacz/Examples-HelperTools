using UnityEngine;
using Unknown.StateMachine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 movementInput;
    public PlayerGroundState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name, player, data)
    {

    }

    public override void Check()
    {
        base.Check();
        if (!player.IsGrouned())
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.drag = playerData.groundDrag;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        movementInput = player.InputHandler.RawMovementInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.applyGravity(1f);
        if (player.InputHandler.IsJumping)
        {
            player.Jump(playerData.jumpForce);
        }
    }
}
