using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuBehaviourScript : MonoBehaviour
{
    public void Play()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (buttonName == "Button (Legacy)")
            GameManagerScript.playerIndex = 0;
        else if (buttonName == "Button (Legacy) (1)")
            GameManagerScript.playerIndex = 1;
        else
            GameManagerScript.playerIndex = 0;

        SceneManager.LoadScene("Scene01");
    }
}
