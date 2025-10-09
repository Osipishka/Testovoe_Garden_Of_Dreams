using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
public class JsonBuildingRepository : IBuildingRepository
{
    private readonly string savePath;
    private const string SAVE_FILE = "buildings.json";

    public JsonBuildingRepository()
    {
        savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE);
    }

    public void SaveBuildings(List<SavedBuilding> buildings)
    {
        try
        {
            SaveData saveData = new SaveData { buildings = buildings };
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(savePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка сохранения: {e.Message}");
        }
    }

    public List<SavedBuilding> LoadBuildings()
    {
        try
        {
            if (!File.Exists(savePath))
                return new List<SavedBuilding>();

            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData.buildings;
        }
        catch (Exception e)
        {
            return new List<SavedBuilding>();
        }
    }

    public bool SaveExists() => File.Exists(savePath);

    public void DeleteSave()
    {
        if (File.Exists(savePath))
            File.Delete(savePath);
    }
}