using UnityEngine;
using Unknown.StateMachine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody rb { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    [SerializeField]
    private PlayerData data;
    [SerializeField]
    private Transform groundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StateMachine = new PlayerStateMachine();
        InputHandler = GetComponent<PlayerInputHandler>();
        IdleState = new PlayerIdleState(StateMachine, "idleState", this, data);
        WalkState = new PlayerWalkState(StateMachine, "walkState", this, data);
        RunState = new PlayerRunState(StateMachine, "runState", this, data);
        InAirState = new PlayerInAirState(StateMachine, "airState", this, data);
    }

    private void Start()
    {
        StateMachine.initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #region playerPhysics

    public void Move(Vector2 movement, float multiplier)
    {
        Vector3 moveVector = transform.forward * movement.y + transform.right * movement.x;
        rb.AddForce(moveVector * multiplier, ForceMode.Acceleration);

    }

    public void Jump(float multiplier)
    {
        rb.AddForce(Vector3.up * multiplier, ForceMode.Impulse);
    }

    public void applyGravity(float force)
    {
        rb.AddForce(Vector3.down * force, ForceMode.Acceleration);
    }

    #endregion

    #region Checks
    public bool IsGrouned()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, data.isGround);
    }
    #endregion
}

