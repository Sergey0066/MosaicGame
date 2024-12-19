using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace MyGame.UI
{
    public class ColorSelectionWindow : MonoBehaviour
    {
        [Header("UI Элементы")]
        [SerializeField] private GameObject selectionPanel;
        [SerializeField] private Button startButton;
        [SerializeField] private TMP_InputField numberInputField;
        [SerializeField] private Button randomColorButton;

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

        private List<GameObject> colorObjects = new List<GameObject>();

        private void Start()
        {
            if (startButton == null || selectionPanel == null || numberInputField == null || randomColorButton == null)
            {
                Debug.LogError("Не все необходимые UI элементы привязаны!");
                return;
            }

            numberInputField.contentType = TMP_InputField.ContentType.IntegerNumber;

            startButton.onClick.AddListener(HandleStartButton);
            randomColorButton.onClick.AddListener(HandleRandomColorButton);

            HideAllColorObjects();
            FillColorObjectsList();
        }

        private void FillColorObjectsList()
        {
            colorObjects.Add(redObject);
            colorObjects.Add(orangeObject);
            colorObjects.Add(yellowObject);
            colorObjects.Add(greenObject);
            colorObjects.Add(lightBlueObject);
            colorObjects.Add(blueObject);
            colorObjects.Add(purpleObject);
            colorObjects.Add(pinkObject);
            colorObjects.Add(magentaObject);
            colorObjects.Add(violetObject);
            colorObjects.Add(limeObject);
            colorObjects.Add(cyanObject);
            colorObjects.Add(grayObject);
            colorObjects.Add(blackObject);
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

        private void HandleRandomColorButton()
        {
            if (string.IsNullOrEmpty(numberInputField.text))
            {
                Debug.LogError("Введите число от 1 до 14.");
                return;
            }

            int number;
            bool isValidNumber = int.TryParse(numberInputField.text, out number);

            if (!isValidNumber || number < 1 || number > 14)
            {
                Debug.LogError("Введите корректное число от 1 до 14.");
                return;
            }

            SelectRandomColors(number);

            selectionPanel.SetActive(false);
        }

        private void SelectRandomColors(int number)
        {
            HideAllColorObjects();

            List<GameObject> shuffledObjects = new List<GameObject>(colorObjects);
            System.Random rng = new System.Random();
            int n = shuffledObjects.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                GameObject value = shuffledObjects[k];
                shuffledObjects[k] = shuffledObjects[n];
                shuffledObjects[n] = value;
            }

            // Случайное количество объектов
            for (int i = 0; i < number; i++)
            {
                shuffledObjects[i].SetActive(true);
            }
        }

        private void HideAllColorObjects()
        {
            foreach (var colorObject in colorObjects)
            {
                colorObject.SetActive(false);
            }
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
