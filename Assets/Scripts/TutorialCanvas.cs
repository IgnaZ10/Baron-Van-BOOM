using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Text text;

    [SerializeField] Button[] buttonList;
    [SerializeField] List<string> textList;

    int indexActualText = 0;

    private void Start()
    {
        if (buttonList.Length > 2)
        {
            Debug.LogError("Debes utilizar solo dos botones, el primero sera Preview, el segundo Next");
        }
        else
        {
            ViewActualText(0);
            ResetButtons();

        }
    }

    private void ResetButtons()
    {
        buttonList[0].onClick.AddListener(Previous);
        buttonList[1].onClick.AddListener(Next);

        buttonList[0].gameObject.SetActive(false);
        buttonList[1].gameObject.SetActive(true);
    }
    public void ViewTutorial()
    {
        canvas.SetActive(!canvas);
    }


    [SerializeField] void Previous()
    {
        indexActualText -= 1;
        if (indexActualText == 1)
        {
            buttonList[0].gameObject.SetActive(false);
            buttonList[1].gameObject.SetActive(true);
        }

        ViewActualText(indexActualText);

    }
    [SerializeField] void Next()
    {
        indexActualText += 1;
        if (indexActualText == textList.Count - 1)
        {
            buttonList[0].gameObject.SetActive(true);
            buttonList[1].gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Nivel 1");
        }

        ViewActualText(indexActualText);
    }


    private void ViewActualText(int index)
    {
        for (int c = 0; c < textList.Count; c++)
        {
            if (c == index)
            {
                text.text = textList[c];
            }
        }
    }
}
