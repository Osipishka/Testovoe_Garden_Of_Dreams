using System.Collections.Generic;

public interface IBuildingRepository
{
    void SaveBuildings(List<SavedBuilding> buildings);
    List<SavedBuilding> LoadBuildings();
    bool SaveExists();
    void DeleteSave();
}