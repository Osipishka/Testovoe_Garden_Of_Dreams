using UnityEngine;
using System.Collections.Generic;

public class BuildingDataService
{
    public List<BuildingData> GetAllBuildingsInScene()
    {
        return new List<BuildingData>(UnityEngine.Object.FindObjectsOfType<BuildingData>());
    }

    public List<SavedBuilding> ConvertToSaveData(List<BuildingData> buildings)
    {
        var savedBuildings = new List<SavedBuilding>();

        foreach (var building in buildings)
        {
            if (!string.IsNullOrEmpty(building.buildingId))
            {
                savedBuildings.Add(new SavedBuilding
                {
                    buildingId = building.buildingId,
                    position = building.transform.position,
                    rotation = building.transform.rotation,
                    scale = building.transform.localScale
                });
            }
        }

        return savedBuildings;
    }

    public GameObject FindBuildingPrefabById(string buildingId)
    {
        BuildingData[] allPrefabs = Resources.FindObjectsOfTypeAll<BuildingData>();

        foreach (BuildingData buildingData in allPrefabs)
        {
            if (buildingData.buildingId == buildingId && buildingData.gameObject.scene.name == null)
                return buildingData.gameObject;
        }

        return null;
    }

    public void ClearAllBuildings()
    {
        var allBuildings = GetAllBuildingsInScene();
        foreach (var building in allBuildings)
            UnityEngine.Object.Destroy(building.gameObject);
    }
}