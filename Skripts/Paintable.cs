using UnityEngine;

namespace YourNamespace.Painting
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Paintable : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_spriteRenderer == null)
            {
                Debug.LogError($"�� ������� {gameObject.name} ����������� ��������� SpriteRenderer!");
            }
        }

        private void OnMouseDown()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogError($"SpriteRenderer �� ������ �� ������� {gameObject.name}.");
                return;
            }

            // ��������� ����� �� ColorPickerModel
            Color selectedColor = YourNamespace.ColorPicker.ColorPickerModel.GetSelectedColor();
            _spriteRenderer.color = selectedColor;
        }
    }
}
