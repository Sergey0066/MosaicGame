using UnityEngine;

public class SettingsPanelOpener : MonoBehaviour
{
    [Header("UI Ёлементы")]
    public GameObject selectionPanel;

    private void OnMouseDown()
    {
        if (selectionPanel != null)
        {
            selectionPanel.SetActive(true);
            Debug.Log("ѕанель выбора открыта.");
        }
        else
        {
            Debug.LogError("SelectionPanel не прив€зана!");
        }
    }
}
