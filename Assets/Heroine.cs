using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroine : MonoBehaviour
{
    private HeroineState _state = new StandingState();
    public ParticleSystem ps;
    public Animator anim;

    private void Start()
    {
        _state.Enter(this);
        anim.SetBool("Backflip", false);
    }

    private void Update()
    {
        HeroineState state = _state.HandleInput(this);
        if (state != null)
        {
            _state.Exit(this);
            _state = state;
            _state.Enter(this);
        }
        _state.Update(this);
    }
}