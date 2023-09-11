using UnityEngine;

public class JumpingState : HeroineState
{
    float jumpForce = 10f;
    bool grounded = false;
    bool jumpStart = true;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Jumping");
        Rigidbody rig = heroine.GetComponent<Rigidbody>();
        rig.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (grounded)
            return new StandingState();
        else if (Input.GetKey(KeyCode.S))
            return new DivingState();
        else if (Input.GetKey(KeyCode.B))
            return new BackflippingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        Transform tr = heroine.GetComponent<Transform>();
        if (tr.position.y >= 2f)
            jumpStart = false;
        if (tr.position.y <= 1.01f && !jumpStart)
        {
            jumpStart = true;
            grounded = true;
        }
    }
}