using UnityEngine;

public class Building : MonoBehaviour
{
   public int incomePerTick = 5;
   private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = FindFirstObjectByType<ResourceManager>();

    }

    void OnEnable()
    {
        TimeManager.OnTick += ProduceResources;
    }

    void OnDisable()
    {
        TimeManager.OnTick -= ProduceResources;
    }

    void ProduceResources()
    {
        if(resourceManager != null)
        {
            resourceManager.AddGold(incomePerTick);
        }
    }
}
