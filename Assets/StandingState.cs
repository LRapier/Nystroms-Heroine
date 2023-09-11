using UnityEngine;
public class StandingState : HeroineState
{
    public override void Enter(Heroine heroine)
    {
        Debug.Log("Standing");
        heroine.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public override HeroineState HandleInput(Heroine heroine)
    {
        if (Input.GetKey(KeyCode.S))
            return new DuckingState();
        else if (Input.GetKeyDown(KeyCode.W))
            return new JumpingState();
        return null;
    }
}