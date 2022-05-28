using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;

    public void OnContinueButton()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
