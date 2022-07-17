using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ChooseGun : MonoBehaviour
{
    [SerializeField] GameObject shootD6;
    [SerializeField] GameObject shootD2;

    bool selected2;

    // Start is called before the first frame update
    void Start()
    {
        selected2 = false;

        shootD6.SetActive(!selected2);
        shootD2.SetActive(selected2);
    }

    public void SwitchGun(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed)
        {
            return;
        }

        selected2 = !selected2;

        shootD6.SetActive(!selected2);
        shootD2.SetActive(selected2);
    }
}
