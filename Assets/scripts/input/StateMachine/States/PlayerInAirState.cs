using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unknown.StateMachine;

public class PlayerInAirState : PlayerState
{
    private float currentGravity;
    private Vector2 movementInput;
    public PlayerInAirState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name, player, data)
    {
    }

    public override void Check()
    {
        base.Check();
        if (player.IsGrouned())
        {
            if (movementInput.magnitude == 0) 
            { 
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.WalkState);
            }
        }
    }

    public override void Enter()
    {
        base.Enter();
        currentGravity = playerData.gravity;
        player.rb.drag = playerData.inAirDrag;
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
        currentGravity += 0.1f;
        player.applyGravity(currentGravity * (Time.time - startTime));
        player.Move(movementInput, playerData.walkingSpeed / 2);
    }
}
