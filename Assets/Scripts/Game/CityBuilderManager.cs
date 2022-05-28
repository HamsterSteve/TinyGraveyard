using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilderManager : MonoBehaviour
{
    int myBones  = 0;
    int myWood = 150;
    int myStone = 0;
    int myGold = 0;

    int maxBones = 200;
    int maxWood = 200;
    int maxStone = 200;
    int maxGold = 200;

    public bool canGenerateBones = true;
    public bool canGenerateWood = true;
    public bool canGenerateStone = true;
    public bool canGenerateGold = true;

    private void Update()
    {
        //checks to see if storage limit has been reached. If so. Sets the currentbones to max bones(Just to be safe)
        //Then disables the resource generation until the storage limit is increased.
        //Shouldn't be called in update, but when a resource is generated. 
        if(maxBones <= myBones)
        {
            myBones = maxBones;
            canGenerateBones = false;
        }
        else
        {
            canGenerateBones = true;
        }

        if(maxWood <= myWood)
        {
            myWood = maxWood;
            canGenerateWood = false;
        }
        else
        {
            canGenerateWood = true;
        }

        if(maxStone <= myStone)
        {
            myStone = maxStone;
            canGenerateStone = false;
        }
        else
        {
            canGenerateStone = true;
        }

        if(maxGold <= myGold)
        {
            myGold = maxGold;
            canGenerateGold = false;
        }
        else
        {
            canGenerateGold = true;
        }   
    }

    public int GetMyBones()
    {
        return myBones;
    }

    public int GetMyWood()
    {
        return myWood;
    }

    public int GetMyStone()
    {
        return myStone;
    }
    
    public int GetMyGold()
    {
        return myGold;
    }

    public int GetMaxBones()
    {
        return maxBones;
    }
    public int GetMaxWood()
    {
        return maxWood;
    }

    public int GetMaxStone()
    {
        return maxStone;
    }

    public int GetMaxGold()
    {
        return maxGold;
    }

    
    public void SetResources(int boneCost, int woodCost, int stoneCost, int goldCost)
    {
        myBones = boneCost;
        myWood = woodCost;
        myStone = stoneCost;
        myGold = goldCost;
    }

    public void SetMaxStorage(int value)
    {
        //increases the max storage foreach resource
        maxBones = maxBones + value;
        maxWood = maxWood + value;
        maxStone = maxStone + value;
        maxGold = maxGold + value;
    }

    public void SetBones(int value)
    {
        myBones = value;
    }

    public void SetWood(int value)
    {
        myWood = value;
    }

    public void SetStone(int value)
    {
        myStone = value;
    }

    public void SetGold(int value)
    {
        myGold = value;
    }

}
