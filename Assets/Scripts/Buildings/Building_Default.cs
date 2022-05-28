using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Default : MonoBehaviour
{
    [SerializeField] string buildingInfo = null;
    [SerializeField] int buildingId = -1;
    [SerializeField] int boneCost = 100;
    [SerializeField] int woodCost = 0;
    [SerializeField] int stoneCost = 0;
    [SerializeField] int goldCost = 0;
    [SerializeField] GameObject buildingPreview = null;
    
    public string GetBuildingInfo()
    {
        return buildingInfo;
    }
    public GameObject GetBuildingPreview()
    {
        return buildingPreview;
    }

    public int GetBuildingId()
    {
        return buildingId;
    }

    #region GetResourceCost
    public int GetBoneCost()
    {
        return boneCost;
    }
    public int GetWoodCost()
    {
        return woodCost;
    }

    public int GetStoneCost()
    {
        return stoneCost;
    }

    public int GetGoldCost()
    {
        return goldCost;
    }
    #endregion
}
