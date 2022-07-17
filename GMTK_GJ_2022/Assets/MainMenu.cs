using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    [SerializeField] int firstSceneIndex = 1;
    public void StartGame() 
    {
        SceneManager.LoadScene(firstSceneIndex);
    }
    
    public void ExitButtton() {
        Application.Quit();
    }

    private void DeselectClickedButton(GameObject button)
    {
        if (EventSystem.current.currentSelectedGameObject == button)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
