using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] FloatVariable lifeVariable;
    Image[] images;
    int maxLife;

    void Start()
    {
        images = GetComponentsInChildren<Image>();
        maxLife = images.Length;
    }

    void Update()
    {
        for(int i = 0; i<maxLife; i++)
        {
            float fillAmount = (lifeVariable.value/2)-i;
            fillAmount = Mathf.Clamp(fillAmount, 0, 1);
            images[i].fillAmount = fillAmount;
        }
    }
}
