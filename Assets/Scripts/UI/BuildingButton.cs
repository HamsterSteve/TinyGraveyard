using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuildingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Building_Default buildingAssignedToThisButton = null;
    [SerializeField] Button thisButton = null;
    [SerializeField] BuildingButton[] buildingButtons;
    
    [SerializeField] Color activeButtonColor;
    [SerializeField] LayerMask groundLayer = new LayerMask();

    string toolTipString;
    float toolTipHoverTime = 0.5f;
    [SerializeField] Renderer previewRenderer; 

    BuildingPlacer buildingPlacer;
    GameObject buildingPreview;
    Building_Snap building_Snap;
    ColorBlock cb;
    public bool thisButtonActive = false;

    Camera mainCamera;
    
    public Building_Default GetThisButtonBuilding()
    {
        return buildingAssignedToThisButton;
    }
    private void Awake()
    {
        building_Snap = FindObjectOfType<Building_Snap>();
        mainCamera = Camera.main;
        buildingPlacer = FindObjectOfType<BuildingPlacer>();
        thisButton = GetComponent<Button>();

        toolTipString = buildingAssignedToThisButton.GetBuildingInfo();
        buildingButtons = FindObjectsOfType<BuildingButton>();
    }
    private void Update()
    {
        if(!thisButtonActive)
        {
            Destroy(buildingPreview);
            DeactivateButtonColor();
            
        }
    }
    private void LateUpdate()
    {
        if(buildingPreview == null) return;
        
        MoveBuildingPreviewWithSnapLocation();
    }

    //When the button is clicked. Pass the buildingID 
    //When a new button is pressed clear all other active buttons. Set the button that the button that is 
    //pressed to active.
    public void MouseDown() 
    {
        ClearActiveButtons();
        

        ActiveButtonColor();
        
        thisButtonActive = true;
        Debug.Log(this.gameObject + "is active");
        if(thisButtonActive)
        {
            var buildingID = buildingAssignedToThisButton.GetBuildingId();
            buildingPlacer.GetSelectedBuildingID(buildingID);
            
            buildingPreview = Instantiate(buildingAssignedToThisButton.GetBuildingPreview());
            previewRenderer = buildingPreview.GetComponentInChildren<Renderer>();
            buildingPreview.SetActive(false);
        }
    }

    void MoveBuildingPreviewWithSnapLocation()
    {
        buildingPreview.transform.position = building_Snap.GetSnapLocation();

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        { 
            buildingPreview.SetActive(false);
            return; 
        }

        buildingPreview.SetActive(true);

        
        Color color = buildingPlacer.CanPlaceBuilding() ? Color.green : Color.red;
        previewRenderer.material.SetColor("_BaseColor", color);
    }

    void ClearActiveButtons()
    {
        foreach(BuildingButton buildingButton in buildingButtons)
        {
            buildingButton.thisButtonActive = false;
        }
    }

    //These 2 methods change the color of the button
    void ActiveButtonColor()
    {
        cb = thisButton.colors;
        cb.normalColor = activeButtonColor;
        thisButton.colors = cb;
    }
    void DeactivateButtonColor()
    {
        cb = thisButton.colors;
        cb.normalColor = ColorBlock.defaultColorBlock.normalColor;
        thisButton.colors = cb;
    }
    
    //code for hover over tooltips
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(HoverTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        ToolTipManager.onMouseNotHover();
    }

    void DisplayToolTip()
    {
        ToolTipManager.onMouseHover(toolTipString, Mouse.current.position.ReadValue());
    }
    
    IEnumerator HoverTimer()
    {
        yield return new WaitForSeconds(toolTipHoverTime);

        DisplayToolTip();
    }
}
