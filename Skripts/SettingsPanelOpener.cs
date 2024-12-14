using UnityEngine;

namespace MyGame.UI
{
    public class SettingsPanelOpener : MonoBehaviour
    {
        [Header("UI Ёлементы")]
        [SerializeField] private GameObject selectionPanel;

        private void OnMouseDown()
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(true);
                Debug.Log("ѕанель выбора открыта.");
            }
            else
            {
                Debug.LogError("SelectionPanel не прив€зана.");
            }
        }
    }
}
