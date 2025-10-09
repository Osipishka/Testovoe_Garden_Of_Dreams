using UnityEngine;
using System.Collections.Generic;

public class SaveLoadController : MonoBehaviour
{
    private IBuildingRepository repository;
    private BuildingDataService dataService;

    private void Awake()
    {
        repository = new JsonBuildingRepository();
        dataService = new BuildingDataService();
    }

    public void SaveBuildings()
    {
        var buildings = dataService.GetAllBuildingsInScene();
        var saveData = dataService.ConvertToSaveData(buildings);
        repository.SaveBuildings(saveData);
    }

    public void LoadBuildings()
    {
        var savedBuildings = repository.LoadBuildings();

        dataService.ClearAllBuildings();

        foreach (var savedBuilding in savedBuildings)
        {
            GameObject prefab = dataService.FindBuildingPrefabById(savedBuilding.buildingId);
            if (prefab != null)
            {
                GameObject building = UnityEngine.Object.Instantiate(
                    prefab, savedBuilding.position, savedBuilding.rotation);
                building.transform.localScale = savedBuilding.scale;
            }
        }
    }

    public void DeleteSave() => repository.DeleteSave();
}