using UnityEngine;

public class BuildingPlacementService
{
    private readonly Grid grid;
    private readonly LayerMask buildingLayer;
    private readonly Vector2 buildingSize;

    public BuildingPlacementService(Grid grid, LayerMask buildingLayer, Vector2 buildingSize)
    {
        this.grid = grid;
        this.buildingLayer = buildingLayer;
        this.buildingSize = buildingSize;
    }

    public Vector3 GetGridPosition(Vector3 worldPosition, Vector3 offset)
    {
        Vector3Int cellPosition = grid.WorldToCell(worldPosition);
        return grid.GetCellCenterWorld(cellPosition) + offset;
    }

    public bool CanPlaceBuilding(Vector3 position)
    {
        Collider2D collider = Physics2D.OverlapBox(position, buildingSize, 0f, buildingLayer);
        return collider == null;
    }

    public GameObject PlaceBuilding(GameObject buildingPrefab, Vector3 position)
    {
        return UnityEngine.Object.Instantiate(buildingPrefab, position, Quaternion.identity);
    }
}