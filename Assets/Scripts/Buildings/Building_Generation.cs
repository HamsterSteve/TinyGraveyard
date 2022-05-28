using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.Buildings
{
    public class Building_Generation : MonoBehaviour
{
    [SerializeField] int resourceGeneratedPerTick = 10;
    [SerializeField] float tick = 5f;

    [SerializeField] ResourcesEnums buildingResource;

    int tempResCount;

    float timer;

    CityBuilderManager cityBuilderManager; 

    private void Awake() 
    {
        cityBuilderManager = FindObjectOfType<CityBuilderManager>();
    }
    void Start() 
    {
        timer = tick; 
        //Debug.Log(buildingResource);
        
    }

    void LateUpdate() 
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            GenerateResource();
            timer += tick;
        }
    }

    void GenerateResource()
    {
        //checks to see what enum is selected. Then adds it to the correct resource
        if(buildingResource.ToString().Equals("Bones") && cityBuilderManager.canGenerateBones)
        {
            cityBuilderManager.SetBones(cityBuilderManager.GetMyBones() + resourceGeneratedPerTick);
            //Debug.Log("This building is generating BONES");
        }

        if(buildingResource.ToString().Equals("Wood") && cityBuilderManager.canGenerateWood)
        {
            cityBuilderManager.SetWood(cityBuilderManager.GetMyWood() + resourceGeneratedPerTick);
            //Debug.Log("This building is generating WOOD");
        }

        if(buildingResource.ToString().Equals("Stone") && cityBuilderManager.canGenerateStone)
        {
            cityBuilderManager.SetStone(cityBuilderManager.GetMyStone() + resourceGeneratedPerTick);
            
        }

        if(buildingResource.ToString().Equals("Gold") && cityBuilderManager.canGenerateGold)
        {
            cityBuilderManager.SetGold(cityBuilderManager.GetMyGold() + resourceGeneratedPerTick);
        }
    }
}
}

