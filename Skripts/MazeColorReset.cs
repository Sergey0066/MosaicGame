using UnityEngine;
using UnityEngine.UI;

namespace YourNamespace.MazeColorReset
{
    public class MazeColorReset : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer resetSprite;
        [SerializeField] private Button unblockButton1; // ������ ������ ��� ������ ����������
        [SerializeField] private Button unblockButton2; // ������ ������ ��� ������ ����������

        private void Start()
        {
            if (resetSprite != null)
            {
                AddSpriteClickListener(resetSprite);
            }
            else
            {
                Debug.LogError("������ ��� ������ �� ��������!");
            }

            if (unblockButton1 != null)
            {
                unblockButton1.onClick.AddListener(EnableMazeInteraction); // ���������� ����������� �� ������ ������
            }
            else
            {
                Debug.LogError("������ ������ ��� ������ ���������� �� ���������!");
            }

            if (unblockButton2 != null)
            {
                unblockButton2.onClick.AddListener(EnableMazeInteraction); // ���������� ����������� �� ������ ������
            }
            else
            {
                Debug.LogError("������ ������ ��� ������ ���������� �� ���������!");
            }
        }

        private void AddSpriteClickListener(SpriteRenderer sprite)
        {
            if (sprite != null)
            {
                if (sprite.gameObject.GetComponent<BoxCollider2D>() == null)
                {
                    sprite.gameObject.AddComponent<BoxCollider2D>();
                }

                sprite.gameObject.AddComponent<ClickableSprite>().OnSpriteClicked += ResetAllMazeColorsToWhite;
            }
        }

        private void ResetAllMazeColorsToWhite()
        {
            GameObject[] mazeObjects = GameObject.FindGameObjectsWithTag("Maze");
            foreach (GameObject mazeObject in mazeObjects)
            {
                SpriteRenderer spriteRenderer = mazeObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.white;
                }
                else
                {
                    Renderer renderer = mazeObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = Color.white;
                    }
                }
            }
        }

        private void EnableMazeInteraction()
        {
            GameObject[] mazeObjects = GameObject.FindGameObjectsWithTag("Maze");

            foreach (GameObject mazeObject in mazeObjects)
            {
                Collider2D collider = mazeObject.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = true;
                }
                else
                {
                    Debug.LogWarning($"������ {mazeObject.name} �� ����� Collider2D.");
                }
            }
        }
    }

    public class ClickableSprite : MonoBehaviour
    {
        public delegate void SpriteClicked();
        public event SpriteClicked OnSpriteClicked;

        private void OnMouseDown()
        {
            OnSpriteClicked?.Invoke();
        }
    }
}
