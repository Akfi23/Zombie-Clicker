using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultZombie : Enemy
{
    [SerializeField] private ParticleSystem _NewEffect;

    private void OnEnable()
    {
        _NewEffect.Play();
    }

    protected void Start()
    {
        _NewEffect = CreateEffect();
        _NewEffect.Play();
    }

    private void OnMouseDown()
    {
        Die();
    }
}
