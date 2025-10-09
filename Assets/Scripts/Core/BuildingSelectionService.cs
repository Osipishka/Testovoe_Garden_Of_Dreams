using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSelectionService
{
    private readonly Camera mainCamera;
    private readonly LayerMask buildingLayer;

    public BuildingSelectionService(LayerMask layer)
    {
        mainCamera = Camera.main;
        buildingLayer = layer;
    }

    public GameObject GetBuildingAtMousePosition()
    {
        if (IsPointerOverUI()) return null;

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;

        Collider2D hit = Physics2D.OverlapPoint(worldPos, buildingLayer);
        return hit?.gameObject;
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }
}