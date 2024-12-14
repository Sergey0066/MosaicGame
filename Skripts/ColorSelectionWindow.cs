using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
    public class ColorSelectionWindow : MonoBehaviour
    {
        [Header("UI Элементы")]
        [SerializeField] private GameObject selectionPanel;
        [SerializeField] private Button startButton;

        [Header("Цветовые элементы")]
        [SerializeField] private Toggle redToggle;
        [SerializeField] private GameObject redObject;

        [SerializeField] private Toggle orangeToggle;
        [SerializeField] private GameObject orangeObject;

        [SerializeField] private Toggle yellowToggle;
        [SerializeField] private GameObject yellowObject;

        [SerializeField] private Toggle greenToggle;
        [SerializeField] private GameObject greenObject;

        [SerializeField] private Toggle lightBlueToggle;
        [SerializeField] private GameObject lightBlueObject;

        [SerializeField] private Toggle blueToggle;
        [SerializeField] private GameObject blueObject;

        [SerializeField] private Toggle purpleToggle;
        [SerializeField] private GameObject purpleObject;

        [SerializeField] private Toggle pinkToggle;
        [SerializeField] private GameObject pinkObject;

        [SerializeField] private Toggle magentaToggle;
        [SerializeField] private GameObject magentaObject;

        [SerializeField] private Toggle violetToggle;
        [SerializeField] private GameObject violetObject;

        [SerializeField] private Toggle limeToggle;
        [SerializeField] private GameObject limeObject;

        [SerializeField] private Toggle cyanToggle;
        [SerializeField] private GameObject cyanObject;

        [SerializeField] private Toggle grayToggle;
        [SerializeField] private GameObject grayObject;

        [SerializeField] private Toggle blackToggle;
        [SerializeField] private GameObject blackObject;

        private void Start()
        {
            if (startButton == null || selectionPanel == null)
            {
                Debug.LogError("Кнопка или панель выбора не привязаны!");
                return;
            }

            startButton.onClick.AddListener(HandleStartButton);
            HideAllColorObjects();
        }

        private void HandleStartButton()
        {
            if (selectionPanel == null)
            {
                Debug.LogError("Панель выбора не установлена!");
                return;
            }

            SetActiveObject(redObject, redToggle?.isOn ?? false);
            SetActiveObject(orangeObject, orangeToggle?.isOn ?? false);
            SetActiveObject(yellowObject, yellowToggle?.isOn ?? false);
            SetActiveObject(greenObject, greenToggle?.isOn ?? false);
            SetActiveObject(lightBlueObject, lightBlueToggle?.isOn ?? false);
            SetActiveObject(blueObject, blueToggle?.isOn ?? false);
            SetActiveObject(purpleObject, purpleToggle?.isOn ?? false);
            SetActiveObject(pinkObject, pinkToggle?.isOn ?? false);
            SetActiveObject(magentaObject, magentaToggle?.isOn ?? false);
            SetActiveObject(violetObject, violetToggle?.isOn ?? false);
            SetActiveObject(limeObject, limeToggle?.isOn ?? false);
            SetActiveObject(cyanObject, cyanToggle?.isOn ?? false);
            SetActiveObject(grayObject, grayToggle?.isOn ?? false);
            SetActiveObject(blackObject, blackToggle?.isOn ?? false);

            selectionPanel.SetActive(false);
        }

        private void HideAllColorObjects()
        {
            SetActiveObject(redObject, false);
            SetActiveObject(orangeObject, false);
            SetActiveObject(yellowObject, false);
            SetActiveObject(greenObject, false);
            SetActiveObject(lightBlueObject, false);
            SetActiveObject(blueObject, false);
            SetActiveObject(purpleObject, false);
            SetActiveObject(pinkObject, false);
            SetActiveObject(magentaObject, false);
            SetActiveObject(violetObject, false);
            SetActiveObject(limeObject, false);
            SetActiveObject(cyanObject, false);
            SetActiveObject(grayObject, false);
            SetActiveObject(blackObject, false);
        }

        private void SetActiveObject(GameObject obj, bool isActive)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
            else
            {
                Debug.LogWarning("Объект не привязан!");
            }
        }
    }
}
