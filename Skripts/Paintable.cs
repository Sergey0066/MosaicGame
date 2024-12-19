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
                Debug.LogError($"На объекте {gameObject.name} отсутствует компонент SpriteRenderer!");
            }
        }

        private void OnMouseDown()
        {
            if (_spriteRenderer == null)
            {
                Debug.LogError($"SpriteRenderer не найден на объекте {gameObject.name}.");
                return;
            }

            // Получение цвета из ColorPickerModel
            Color selectedColor = YourNamespace.ColorPicker.ColorPickerModel.GetSelectedColor();
            _spriteRenderer.color = selectedColor;
        }
    }
}
