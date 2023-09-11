using UnityEngine;

public class SuperJumpingState : HeroineState
{
    float jumpForce = 15f;
    bool grounded = false;
    bool jumpStart = true;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Super Jumping");
        Rigidbody rig = heroine.GetComponent<Rigidbody>();
        rig.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        heroine.transform.localScale = new Vector3(0.8f, 1.3f, 0.8f);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (grounded)
            return new StandingState();
        else if (Input.GetKey(KeyCode.S) && !jumpStart)
            return new GroundPoundingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        Transform tr = heroine.GetComponent<Transform>();
        if (tr.position.y >= 11f)
        {
            jumpStart = false;
            heroine.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (tr.position.y <= 1.15f && !jumpStart)
        {
            jumpStart = true;
            grounded = true;
        }
    }
}