using UnityEngine;

namespace Unknown.StateMachine
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("base physics data")]
        public float gravity = -9.81f;

        [Header("base movement data")]
        public float walkingSpeed = 10f;
        public float runningSpeed = 15f;
        public float jumpForce = 10f;
        public float groundDrag = 6f;
        public float inAirDrag = 2f;
        public LayerMask isGround;

        [Header("look data")]
        public Vector2 mouseSensitivity = new Vector2(30,30);
    }

}
