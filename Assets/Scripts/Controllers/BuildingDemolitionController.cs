using UnityEngine;

public class BuildingDemolitionController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask buildingLayer;
    [SerializeField] private int highlightSortingOrder = 6;

    private bool isDemolitionMode = false;
    private BuildingHighlightService highlightService;
    private BuildingSelectionService selectionService;

    private void Start()
    {
        highlightService = new BuildingHighlightService(highlightSortingOrder);
        selectionService = new BuildingSelectionService(buildingLayer);
    }

    private void Update()
    {
        if (!isDemolitionMode) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitDemolitionMode();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryDemolishBuilding();
        }
    }

    public void EnterDemolitionMode()
    {
        isDemolitionMode = true;
        highlightService.HighlightAllBuildings();
    }

    private void ExitDemolitionMode()
    {
        isDemolitionMode = false;
        highlightService.RemoveAllHighlights();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void TryDemolishBuilding()
    {
        GameObject building = selectionService.GetBuildingAtMousePosition();

        if (building != null)
        {
            Destroy(building);
            ExitDemolitionMode();
        }
    }

    public void CancelDemolition()
    {
        if (isDemolitionMode)
            ExitDemolitionMode();
    }
}