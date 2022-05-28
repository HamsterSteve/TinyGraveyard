using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    [SerializeField] GameObject buildPoint = null;
    [SerializeField] GameObject worldFloor = null;

    [SerializeField] int rowWidth = 10;
    [SerializeField] int rowHeight = 10;

    [SerializeField] int rowWidthOffset = 1;
    [SerializeField] int rowHeightOffset = 1;

    Building_Snap building_Snap;

    void MakeGrid()
    {
        for(int i =0; i < rowWidth * rowHeight; i++)
        {
            var gridPoint = Instantiate(buildPoint, new Vector3(rowWidthOffset + (rowWidthOffset *(i % rowWidth))
                        , 1, rowHeightOffset + (rowHeightOffset *(i / rowHeight))), Quaternion.identity);
            gridPoint.transform.parent = this.gameObject.transform;
            building_Snap.snapPoints.Add(gridPoint);

            //Spawning in floor tiles
            var floor = Instantiate(worldFloor, new Vector3(rowWidthOffset + (rowWidthOffset *(i % rowWidth))
            , 0.5f, rowHeightOffset + (rowHeightOffset *(i / rowHeight))), worldFloor.transform.rotation);
            floor.transform.parent = this.gameObject.transform;
        }
    }

    private void Awake() 
    {
        building_Snap = FindObjectOfType<Building_Snap>();   
    }
    private void Start()
    {
        MakeGrid();  
    }
}
