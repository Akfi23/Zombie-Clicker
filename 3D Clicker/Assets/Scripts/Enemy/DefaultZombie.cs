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

    private void Start()
    {
        _NewEffect = CreateEffect();
        _NewEffect.Play();
    }

    private void OnMouseDown()
    {
        Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Axe>(out Axe axe))
        {
            Die();
        }
    }
}
