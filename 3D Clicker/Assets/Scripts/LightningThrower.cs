using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningThrower : MonoBehaviour
{
    [SerializeField] private Vector3 _newPosition;
    [SerializeField] private ParticleSystem _lightningEffect;

    private void Start()
    {       
        _newPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    private void Throw() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _newPosition = hit.point;
            transform.position = _newPosition;
            _lightningEffect.gameObject.transform.position = new Vector3(_newPosition.x,7,_newPosition.z);
            _lightningEffect.gameObject.SetActive(true);
        }
    }
}