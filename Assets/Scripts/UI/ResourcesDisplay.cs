using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text boneText = null;
    [SerializeField] TMP_Text woodText = null;
    [SerializeField] TMP_Text stoneText = null;
    [SerializeField] TMP_Text goldText = null;

    CityBuilderManager cityBuilderManager;

    void Awake() 
    {
         cityBuilderManager = FindObjectOfType<CityBuilderManager>();
    }
    void Update()
    {
        boneText.text = $"{cityBuilderManager.GetMyBones()}/{cityBuilderManager.GetMaxBones()}";
        woodText.text = $"{cityBuilderManager.GetMyWood()}/{cityBuilderManager.GetMaxWood()}";
        stoneText.text = $"{cityBuilderManager.GetMyStone()}/{cityBuilderManager.GetMaxStone()}";
        goldText.text = $"{cityBuilderManager.GetMyGold()}/{cityBuilderManager.GetMaxGold()}";
    }
}
