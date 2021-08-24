using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltButton : MonoBehaviour
{
    [SerializeField] float _lerpDuration;
    [SerializeField] Image _ultImage;
    [SerializeField] Button _button;
    [SerializeField] Axe _axe;
    private float nextValue;
    float elapsed;
    bool isCooldown;
    private void Awake()
    {
        _ultImage = GetComponent<Image>();
        _ultImage.fillAmount = 0;
        _button.interactable = false;
        isCooldown = true;
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (isCooldown)
        {
            if (elapsed < _lerpDuration)
            {
                nextValue = Mathf.Lerp(0, 1, elapsed / _lerpDuration);
                _ultImage.fillAmount = nextValue;
                elapsed += Time.deltaTime; 
            }
        }

        if (nextValue > 0.98f) 
        {
            _button.interactable = true;
        }
    }
    
    public void ThrowAxe() 
    {
        _axe.gameObject.SetActive(true);

        _button.interactable = false;
        _ultImage.fillAmount = 0;
        isCooldown = true;
        elapsed = 0;
        nextValue = 0;
    }
}
