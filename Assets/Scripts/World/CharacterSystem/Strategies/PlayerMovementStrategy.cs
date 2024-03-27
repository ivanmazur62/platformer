using UnityEngine;

public class PlayerMovementStrategy : IMovementStrategy
{
    public void Move(Rigidbody2D rigidbody2D, float speed)
    {
        float moveInput = Input.GetAxis("Horizontal");
     
        rigidbody2D.velocity = new Vector2(moveInput * speed, rigidbody2D.velocity.y);
    }

    public void Jump(Rigidbody2D rigidbody2D, float jumpForce)
    {
        rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}

