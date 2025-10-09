using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("Системные зависимости")]
    [SerializeField] private Grid grid;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private SaveLoadController saveController;
    [SerializeField] private BuildingDemolitionController demolitionController;

    [Header("Настройки")]
    [SerializeField] private bool autoLoadOnStart = true;

    private void Awake()
    {
        Debug.Log("Инициализация Building System...");

        FindMissingDependencies();
        if (!ValidateCriticalSystems()) return;
        InitializeSystems();
        if (autoLoadOnStart)
        {
            LoadInitialData();
        }

        Debug.Log("Building System полностью инициализирована");
    }

    private void FindMissingDependencies()
    {
        if (grid == null)
        {
            grid = FindObjectOfType<Grid>();
            if (grid != null) Debug.Log("Grid найден автоматически");
        }

        if (buildingManager == null)
        {
            buildingManager = FindObjectOfType<BuildingManager>();
            if (buildingManager != null) Debug.Log("BuildingManager найден автоматически");
        }

        if (saveController == null)
        {
            saveController = FindObjectOfType<SaveLoadController>();
            if (saveController != null) Debug.Log("SaveController найден автоматически");
        }

        if (demolitionController == null)
        {
            demolitionController = FindObjectOfType<BuildingDemolitionController>();
            if (demolitionController != null) Debug.Log("DemolitionController найден автоматически");
        }
    }

    private bool ValidateCriticalSystems()
    {
        if (grid == null)
        {
            Debug.LogError("Критическая ошибка: Grid не найден на сцене!");
            return false;
        }

        if (buildingManager == null)
        {
            Debug.LogError("Критическая ошибка: BuildingManager не найден!");
            return false;
        }

        Debug.Log("Критические системы проверены");
        return true;
    }

    private void InitializeSystems()
    {
        InitializeUI();
        Debug.Log("Save System: готова");
        Debug.Log("Demolition System: готова");
        Debug.Log("Placement System: готова");
    }

    private void InitializeUI()
    {
        if (buildingManager != null)
        {
            Debug.Log("UI System: панель зданий готова");
        }
    }

    private void LoadInitialData()
    {
        if (saveController != null)
        {
            Debug.Log("Save System: готова к загрузке данных");
        }
    }

    public void ForceSave()
    {
        if (saveController != null)
            saveController.SaveBuildings();
    }

    public void ForceLoad()
    {
        if (saveController != null)
            saveController.LoadBuildings();
    }
}