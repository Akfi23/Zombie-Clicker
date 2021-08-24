using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponThrower : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    bool isComplete;
    TweenCallback tweenCallback;
    private void OnEnable()
    {
        Tween tween = transform.DOPath(_points, 5, PathType.CatmullRom).SetOptions(true);
        tween.OnComplete(() => { this.gameObject.SetActive(false);});

    }
    private void Start()
    {
    }

    void Update()
    {

    }
}
