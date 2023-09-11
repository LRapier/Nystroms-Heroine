using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroine : MonoBehaviour
{
    private HeroineState standState = new StandingState();
    public ParticleSystem ps;
    public Animator anim;

    private void Start()
    {
        standState.Enter(this);
        anim.SetBool("Backflip", false);
    }

    private void Update()
    {
        HeroineState state = standState.HandleInput(this);
        if (state != null)
        {
            standState.Exit(this);
            standState = state;
            standState.Enter(this);
        }
        standState.Update(this);
    }
}