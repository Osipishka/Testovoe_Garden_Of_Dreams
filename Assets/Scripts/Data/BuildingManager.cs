using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Transform buildingsPanel;
    [SerializeField] private GameObject[] buildingButtons;

    public void FillPanelWithButtons()
    {
        if (buildingsPanel == null)
        {
            Debug.LogError("Buildings panel not assigned!");
            return;
        }

        if (buildingButtons == null || buildingButtons.Length == 0)
        {
            Debug.LogError("No building buttons assigned!");
            return;
        }

        foreach (Transform child in buildingsPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (GameObject buttonPrefab in buildingButtons)
        {
            if (buttonPrefab != null)
            {
                GameObject buttonInstance = Instantiate(buttonPrefab, buildingsPanel);
                buttonInstance.transform.localScale = Vector3.one;
            }
        }
    }

    public void ClearPanel()
    {
        if (buildingsPanel == null) return;

        foreach (Transform child in buildingsPanel)
        {
            Destroy(child.gameObject);
        }
    }
}