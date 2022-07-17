using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGun : MonoBehaviour
{
    [SerializeField] GameObject shootD6;
    [SerializeField] GameObject shootD2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            shootD6.SetActive(true);
            shootD2.SetActive(false);
        }
        if(Input.GetKeyDown("2")){
            shootD6.SetActive(true);
            shootD2.SetActive(false);
        }
    }
}
