using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Storage : MonoBehaviour
{
    CityBuilderManager cityBuilder;

    [SerializeField] int AmountToIncreaseStorage = 100;

    private void Awake()
    {   
        cityBuilder = FindObjectOfType<CityBuilderManager>();
    }

    private void Start()
    {
        cityBuilder.SetMaxStorage(AmountToIncreaseStorage);
    }
}
