using UnityEngine;
using Unknown.StateMachine;
public class PlayerState : State
{
    protected Player player;
    protected PlayerData playerData;
    public PlayerState(StateMachine stateMachine, string name, Player player, PlayerData data) : base(stateMachine, name)
    {
        this.player = player;
        this.playerData = data;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this.name);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

}
