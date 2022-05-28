using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;

    public void OnButtonDown()
    {
        menuCanvas.gameObject.SetActive(true);
    }
}
