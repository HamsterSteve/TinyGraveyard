using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] Building_Default[] possibleBuildingsToPlace;
    [SerializeField] LayerMask floorLayer = new LayerMask();
    [SerializeField] AudioSource buildSound;
    Camera mainCamera;

    Building_Default selectedBuilding;
    Building_Snap buildingSnap;
    CityBuilderManager cityBuilder;
    int setSelectedBuildingID = -1;

    public void GetSelectedBuildingID(int value)
    {
        setSelectedBuildingID = value;
        Debug.Log(setSelectedBuildingID);
    }
    private void Awake() 
    {
        cityBuilder = FindObjectOfType<CityBuilderManager>();
        mainCamera = Camera.main;
        buildingSnap = FindObjectOfType<Building_Snap>();
    }

    void LateUpdate()
    {
        if(selectedBuilding == null) return;
        if(CanPlaceBuilding() && Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }


    void PlaceBuilding()
    {

        Instantiate(selectedBuilding, buildingSnap.GetSnapLocation(), selectedBuilding.transform.rotation);
        buildSound.Play();
        
        buildingSnap.snapPoints.Remove(buildingSnap.GetGameObject());
        Destroy(buildingSnap.GetGameObject());
        buildingSnap.ClearObjects();
        cityBuilder.SetResources(
                                cityBuilder.GetMyBones() - selectedBuilding.GetBoneCost(), 
                                cityBuilder.GetMyWood() - selectedBuilding.GetWoodCost(),
                                cityBuilder.GetMyStone() - selectedBuilding.GetStoneCost(),
                                cityBuilder.GetMyGold() - selectedBuilding.GetGoldCost());
    }

    void FindSelectedBuilding(int buildingId)
    {
        //foreach Gameobject in possibleBuildingsToPlace. Check to make sure that the IDs match. Then make that game object the select one. 
        foreach(Building_Default building in possibleBuildingsToPlace)
        {
            if(building.GetBuildingId() == buildingId)
            {
                selectedBuilding = building;
                break;
            }
        }
    }

    public bool CanPlaceBuilding()
    {
        if(buildingSnap.snapPoints.Count == 0) return false;
        //Check to make sure cursor is over "ground".
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, floorLayer))
        {
            return false;
        }

        if(EventSystem.current.IsPointerOverGameObject()) return false;

        //Scuffed "Null" check.
        if(buildingSnap.GetSnapLocation() == Vector3.zero) return false;
        //Input the building that you have selected

        FindSelectedBuilding(setSelectedBuildingID);
        
        if(selectedBuilding.GetBoneCost() > cityBuilder.GetMyBones())
        {
            Debug.Log("Not enough bones!");
            return false;
        }
        if(selectedBuilding.GetWoodCost() > cityBuilder.GetMyWood())
        {
            Debug.Log("Not enough wood");
            return false;
        }
        if(selectedBuilding.GetStoneCost() > cityBuilder.GetMyStone())
        {
            Debug.Log("Not enough stone");
            return false;
        }
        if(selectedBuilding.GetGoldCost() > cityBuilder.GetMyGold())
        {
            Debug.Log("Not enough gold!");
            return false;
        }
        if(selectedBuilding.gameObject.CompareTag("Road"))
        {
            return true;
        }

        return true;
    }
}
