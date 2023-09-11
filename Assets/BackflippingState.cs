using UnityEngine;

public class BackflippingState : HeroineState
{
    bool jumpStart = true;
    bool backflipEndGround = false;
    bool backflipEndAir = false;
    public override void Enter(Heroine heroine)
    {
        Debug.Log("Backflipping");
        heroine.anim.SetBool("Backflip", true);
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        if (backflipEndGround)
            return new StandingState();
        else if (backflipEndAir)
            return new JumpingState();
        return null;
    }

    public override void Update(Heroine heroine)
    {
        Transform tr = heroine.GetComponent<Transform>();
        if (tr.position.y >= 1.5f)
        {
            jumpStart = false;
        }
        else if (tr.position.y <= 1.01f && !jumpStart)
        {
            tr.eulerAngles = new Vector3(0f, 0f, 0f);
            heroine.anim.SetBool("Backflip", false);
            backflipEndGround = true;
        }
        else if (heroine.anim.GetCurrentAnimatorStateInfo(0).IsName("Backflip"))
        {
            heroine.anim.SetBool("Backflip", false);
            backflipEndAir = true;
        }
    }
}