using UnityEngine;

public class SettingsPanelOpener : MonoBehaviour
{
    [Header("UI ��������")]
    public GameObject selectionPanel;

    private void OnMouseDown()
    {
        if (selectionPanel != null)
        {
            selectionPanel.SetActive(true);
            Debug.Log("������ ������ �������.");
        }
        else
        {
            Debug.LogError("SelectionPanel �� ���������!");
        }
    }
}
