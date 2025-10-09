using UnityEngine;

public class BuildingVisualizer
{
    private readonly SpriteRenderer spriteRenderer;
    private readonly Color validColor;
    private readonly Color invalidColor;

    public BuildingVisualizer(SpriteRenderer renderer, Color valid, Color invalid)
    {
        spriteRenderer = renderer;
        validColor = valid;
        invalidColor = invalid;
    }

    public void UpdateVisual(bool canPlace)
    {
        spriteRenderer.color = canPlace ? validColor : invalidColor;
    }

    public void SetPosition(Vector3 position)
    {
        spriteRenderer.transform.position = position;
    }
}