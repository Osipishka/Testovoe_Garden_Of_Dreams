using UnityEngine;

public class BuildingPlacementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject buildingPrefab;

    [Header("Settings")]
    [SerializeField] private Color validColor = new Color(0f, 1f, 0.016f, 0.553f);
    [SerializeField] private Color invalidColor = new Color(1f, 0f, 0f, 0.553f);
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask buildingLayer;
    [SerializeField] private Vector2 buildingSize = new Vector2(0.9f, 0.9f);

    private BuildingPlacementService placementService;
    private BuildingVisualizer visualizer;
    private Grid grid;
    private bool canPlace;
    private bool isInitialized = false;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        grid = FindObjectOfType<Grid>();

        if (grid == null)
        {
            Debug.LogError("Grid not found on scene! Please add a Grid object.");
            Destroy(gameObject);
            return;
        }

        placementService = new BuildingPlacementService(grid, buildingLayer, buildingSize);
        visualizer = new BuildingVisualizer(spriteRenderer, validColor, invalidColor);
        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized) return;

        HandleInput();
        UpdatePlacement();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            PlaceBuilding();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

    private void UpdatePlacement()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector3 gridPosition = placementService.GetGridPosition(mouseWorldPos, offset);
        visualizer.SetPosition(gridPosition);

        canPlace = placementService.CanPlaceBuilding(gridPosition);
        visualizer.UpdateVisual(canPlace);
    }

    private void PlaceBuilding()
    {
        placementService.PlaceBuilding(buildingPrefab, transform.position);
        Destroy(gameObject);
    }
}