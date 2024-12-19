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
                BlockMazeObjects(true);
            }
            else
            {
                Debug.LogError("SelectionPanel �� ���������.");
            }
        }

        public void HidePanel()
        {
            if (selectionPanel != null)
            {
                selectionPanel.SetActive(false);
                Debug.Log("������ ������ ������.");
                BlockMazeObjects(false);
            }
            else
            {
                Debug.LogError("SelectionPanel �� ���������.");
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
                    Debug.LogWarning($"������ � SettingsPanelOpener");
                }
            }
        }
    }
}
