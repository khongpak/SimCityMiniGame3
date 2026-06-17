using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int gold {get; private set;} = 100;
    public TMP_Text goldText;

    void OnEnable()
    {
        GridManager.OnBuildingPlaced += HandleBuildingPlaced;
    }

    void OnDisable()
    {
        GridManager.OnBuildingPlaced -= HandleBuildingPlaced;
    }

    void HandleBuildingPlaced(int cost)
    {
        DeductGold(cost);
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void DeductGold(int amount)
    {
        gold -= amount;
        if(gold < 0) gold =0;
    }
}
