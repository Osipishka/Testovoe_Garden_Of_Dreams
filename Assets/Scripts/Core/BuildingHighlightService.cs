using UnityEngine;
using System.Collections.Generic;

public class BuildingHighlightService
{
    private readonly int highlightSortingOrder;
    private readonly List<GameObject> highlightedBuildings = new List<GameObject>();

    public BuildingHighlightService(int sortingOrder = 6)
    {
        highlightSortingOrder = sortingOrder;
    }

    public void HighlightAllBuildings()
    {
        var allBuildings = UnityEngine.Object.FindObjectsOfType<BuildingData>();

        foreach (var buildingData in allBuildings)
        {
            CreateHighlightEffect(buildingData.gameObject);
            highlightedBuildings.Add(buildingData.gameObject);
        }
    }

    public void RemoveAllHighlights()
    {
        foreach (var building in highlightedBuildings)
        {
            if (building != null)
                RemoveHighlightEffect(building);
        }
        highlightedBuildings.Clear();
    }

    private void CreateHighlightEffect(GameObject building)
    {
        GameObject highlight = new GameObject("DemolitionHighlight");
        highlight.transform.SetParent(building.transform);
        highlight.transform.localPosition = Vector3.zero;
        highlight.transform.localScale = Vector3.one;

        SpriteRenderer highlightRenderer = highlight.AddComponent<SpriteRenderer>();
        highlightRenderer.sprite = building.GetComponent<SpriteRenderer>().sprite;
        highlightRenderer.color = new Color(1f, 0f, 0f, 0.4f);
        highlightRenderer.sortingOrder = highlightSortingOrder;
    }

    private void RemoveHighlightEffect(GameObject building)
    {
        foreach (Transform child in building.transform)
        {
            if (child.name == "DemolitionHighlight")
                UnityEngine.Object.Destroy(child.gameObject);
        }
    }
}