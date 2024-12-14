using UnityEngine;

namespace MyGame.UI
{
    public class SettingsPanelOpener : MonoBehaviour
    {
        [Header("UI ��������")]
        [SerializeField] private GameObject selectionPanel;

        private void OnMouseDown()
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(true);
                Debug.Log("������ ������ �������.");
            }
            else
            {
                Debug.LogError("SelectionPanel �� ���������.");
            }
        }
    }
}
