using UnityEngine;

public class DivingState : HeroineState
{
    float diveForce = 20f;
    bool grounded = false;
    bool jumpStart = true;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Diving");
        Rigidbody rb = heroine.GetComponent<Rigidbody>();
        rb.AddForce(diveForce * Vector3.down, ForceMode.Impulse);
        heroine.transform.localScale = new Vector3(0.8f, 1.3f, 0.8f);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (grounded)
            return new StandingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        Transform tr = heroine.GetComponent<Transform>();
        if (tr.position.y >= 2f)
            jumpStart = false;
        if (tr.position.y <= 1.31f && !jumpStart)
        {
            grounded = true;
            jumpStart = true;
        }
    }
}