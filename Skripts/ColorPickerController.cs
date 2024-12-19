using UnityEngine;

namespace YourNamespace.ColorPicker
{
    public class ColorPickerController : MonoBehaviour
    {
        [Header("Цветовые кнопки")]
        [SerializeField] private SpriteRenderer redButton;
        [SerializeField] private SpriteRenderer orangeButton;
        [SerializeField] private SpriteRenderer yellowButton;
        [SerializeField] private SpriteRenderer greenButton;
        [SerializeField] private SpriteRenderer cyanButton;
        [SerializeField] private SpriteRenderer blueButton;
        [SerializeField] private SpriteRenderer purpleButton;
        [SerializeField] private SpriteRenderer pinkButton;
        [SerializeField] private SpriteRenderer magentaButton;
        [SerializeField] private SpriteRenderer violetButton;
        [SerializeField] private SpriteRenderer limeButton;
        [SerializeField] private SpriteRenderer grayButton;
        [SerializeField] private SpriteRenderer blackButton;
        [SerializeField] private SpriteRenderer lightBlueButton;
        [SerializeField] private SpriteRenderer whiteButton;

        private void Start()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            AssignColorToButton(redButton, HexToColor("#cc0000")); // Красный
            AssignColorToButton(orangeButton, HexToColor("#ff9900")); // Оранжевый
            AssignColorToButton(yellowButton, HexToColor("#ffff00")); // Жёлтый
            AssignColorToButton(greenButton, HexToColor("#38761d")); // Зелёный
            AssignColorToButton(lightBlueButton, HexToColor("#9fc5e8")); // Голубой
            AssignColorToButton(blueButton, HexToColor("#1c4587")); // Синий
            AssignColorToButton(purpleButton, HexToColor("#741b47")); // Фиолетовый
            AssignColorToButton(pinkButton, HexToColor("#dd7e6b")); // Розовый
            AssignColorToButton(magentaButton, HexToColor("#ff0067")); // Малиновый
            AssignColorToButton(violetButton, HexToColor("#c27ba0")); // Сиреневый
            AssignColorToButton(limeButton, HexToColor("#a0d358")); // Салатовый
            AssignColorToButton(cyanButton, HexToColor("#00ffff")); // Бирюзовый
            AssignColorToButton(grayButton, HexToColor("#666666")); // Серый
            AssignColorToButton(blackButton, Color.black); // Чёрный
            AssignColorToButton(whiteButton, Color.white); // Белый
        }

        private Color HexToColor(string hex)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }
            return Color.white;
        }

        private void AssignColorToButton(SpriteRenderer button, Color color)
        {
            if (button == null)
            {
                Debug.LogWarning("Кнопка не назначена!");
                return;
            }

            var collider = button.gameObject.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;

            var colorButton = button.gameObject.AddComponent<ColorButton>();
            colorButton.Initialize(color);
        }
    }

    public static class ColorPickerModel
    {
        private static Color selectedColor = Color.white;

        public static void SelectColor(Color color)
        {
            selectedColor = color;
        }

        public static Color GetSelectedColor()
        {
            return selectedColor;
        }
    }

    public class ColorButton : MonoBehaviour
    {
        private Color buttonColor;

        public void Initialize(Color color)
        {
            buttonColor = color;
        }

        private void OnMouseDown()
        {
            ColorPickerModel.SelectColor(buttonColor);
        }
    }
}