using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public static event UnityAction Killed;
    [SerializeField] private ParticleSystem _effect;
    private Animator _animator;

    protected void Die() 
    {
        Killed?.Invoke();
        this.gameObject.SetActive(false);
    }

    protected ParticleSystem CreateEffect()
    {
        ParticleSystem newEffect = Instantiate(_effect, this.transform);
        return newEffect;
    }
    
    protected void TakeDamage() 
    {
        
    }
}
