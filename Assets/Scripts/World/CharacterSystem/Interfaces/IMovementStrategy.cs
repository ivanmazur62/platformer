using UnityEngine;

public interface IMovementStrategy
{
    void Move(Rigidbody2D rigidbody2D, float speed);
    void Jump(Rigidbody2D rigidbody2D, float jumpForce);
}
