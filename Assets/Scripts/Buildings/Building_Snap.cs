using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Building_Snap : MonoBehaviour
{
    public List<GameObject> snapPoints = new List<GameObject>();
    [SerializeField] LayerMask floorLayer = new LayerMask();

    float snapDistance = 1f; 
    
    Vector3 targetSnapPoint;
    GameObject targetGameObject;
    Camera mainCamera;
    BuildingButton buildingButton;

    GameObject buildingPreview;
    

    public Vector3 GetSnapLocation()
    {
        return targetSnapPoint;
    }

    public GameObject GetGameObject()
    {
        return targetGameObject;
    }

    public void ClearObjects()
    {
        targetSnapPoint = Vector3.zero;
        targetGameObject = null;
    }

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        FindClosestSnapPoint();   
    }
    //Adds this piece to List<RoadPieces> on start

    //Foreach snappoint in snappoints. Find the closest gameobject to the mouse position 
    //Then set the closest gameobject as targetSnapPoint.

    void FindClosestSnapPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, floorLayer)) return;

        foreach(GameObject snapPoint in snapPoints)
        {
            Vector3 snapPointLocation = snapPoint.transform.position;
            GameObject gameObject = snapPoint;
            
            if(Vector3.Distance(snapPointLocation, hit.point) <= snapDistance)
            {
                targetSnapPoint = snapPointLocation;
                targetGameObject = gameObject;
                return;
            }
        }

    } 

    
}
