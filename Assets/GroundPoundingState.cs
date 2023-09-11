using UnityEngine;

public class GroundPoundingState : HeroineState
{
    float diveForce = 30f;
    bool grounded = false;
    bool jumpStart = true;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Ground Pounding");
        Rigidbody rb = heroine.GetComponent<Rigidbody>();
        rb.AddForce(diveForce * Vector3.down, ForceMode.Impulse);
        heroine.transform.localScale = new Vector3(0.6f, 1.5f, 0.6f);
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
        ParticleSystem ps = heroine.GetComponent<ParticleSystem>();
        if (tr.position.y >= 2f)
            jumpStart = false;
        if (tr.position.y <= 1.51f && !jumpStart)
        {
            grounded = true;
            jumpStart = true;
            heroine.ps.Play();
        }
    }
}