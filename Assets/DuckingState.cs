using UnityEngine;

public class DuckingState : HeroineState
{
    public override void Enter(Heroine heroine)
    {
        Debug.Log("Ducking");
        heroine.transform.localScale = new Vector3(1, 0.4f, 1);
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        if (!Input.GetKey(KeyCode.S))
            return new StandingState();
        else if (Input.GetKey(KeyCode.W))
            return new SuperJumpingState();
        return null;
    }
}