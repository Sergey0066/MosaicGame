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
                BlockMazeObjects(true);
            }
            else
            {
                Debug.LogError("SelectionPanel не прив€зана.");
            }
        }

        public void HidePanel()
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(false);
                Debug.Log("ѕанель выбора скрыта.");
                BlockMazeObjects(false);
            }
            else
            {
                Debug.LogError("SelectionPanel не прив€зана.");
            }
        }

        private void BlockMazeObjects(bool block)
        {
            GameObject[] mazeObjects = GameObject.FindGameObjectsWithTag("Maze");

            foreach (GameObject mazeObject in mazeObjects)
            {
                Collider2D collider = mazeObject.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = !block;
                }
                else
                {
                    Debug.LogWarning($"ќшибка в SettingsPanelOpener");
                }
            }
        }
    }
}
