using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherZombie : Enemy
{
    [SerializeField] private ParticleSystem _NewEffect;

    private void OnEnable()
    {
        _NewEffect.Play();
    }

    protected void Start()
    {
       _NewEffect= CreateEffect();
       _NewEffect.Play();
    }

    private void OnMouseDown()
    {
        _NewEffect.Play();

        if(_NewEffect.time<=0)
        Die();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<WeaponThrower>(out WeaponThrower weapon)) 
        {
            Die();
        }
    }
}
