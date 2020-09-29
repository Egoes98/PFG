using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogQuestionsLogic : MonoBehaviour
{
    public TextAsset dialogue_text;
    string[] textLines;

    GameManager gM;

    [Header("Toggle References")]
    public GameObject dialogCamera;
    public GameObject uI_elements;
    public GameObject player;
    public ObjectInteraction obj_interaction;
    public GameObject btn_the_end;
    public Text correct_display;

    [Header("Dialog Display")]
    public Text text_display;

    [Header("ChoiceButtons")]
    public List<GameObject> choices;
    int actualQuestion;
    List<int> rightChoices = new List<int>();


    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        actualQuestion = 0;
        dialogCamera.SetActive(false);
        uI_elements.SetActive(false);
        LoadText();

        rightChoices.Add(1);
        rightChoices.Add(3);
        rightChoices.Add(1);
        rightChoices.Add(2);
        rightChoices.Add(2);
    }

    public void StartDialog()
    {
        if (!gM.HaveClues()) return;
        obj_interaction.enabled = false;
        dialogCamera.SetActive(true);
        uI_elements.SetActive(true);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        text_display.text = textLines[0];
        choices[actualQuestion].SetActive(true);
    }

    public void ExitDialog()
    {
        obj_interaction.enabled = true;
        dialogCamera.SetActive(false);
        uI_elements.SetActive(false);
        player.SetActive(true);
        choices[actualQuestion].SetActive(false);
        actualQuestion = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void NextQuestion()
    {
        if (actualQuestion == 5)
        {
            Check();
            return;
        }
        choices[actualQuestion].SetActive(false);
        actualQuestion++;
        text_display.text = textLines[actualQuestion];
        choices[actualQuestion].SetActive(true);
    }

    public void Restart()
    {
        choices[actualQuestion].SetActive(false);
        actualQuestion = 0;
        text_display.text = textLines[actualQuestion];
        choices[actualQuestion].SetActive(true);
    }

    void Check()
    {
        choices[actualQuestion].SetActive(false);
        actualQuestion++;
        bool allCorrect = true;
        int correct = 5;
        for (int n = 1; n < 6; n++)
        {
            if (rightChoices[n-1] != choices[n].GetComponent<ChoiceData>().GetChoice())
            {
                allCorrect = false;
                correct--;
            }
        }
        if (allCorrect)
        {
            text_display.text = textLines[6];
            btn_the_end.SetActive(true);
        }
        else
        {
            text_display.text = textLines[7];
            choices[actualQuestion].SetActive(true);
            correct_display.text = correct+""+correct_display.text;
        }
    }

    public void LoadCredits()
    {
        Destroy(GameObject.FindGameObjectWithTag("Managers"));
        SceneManager.LoadScene(2);
    }

    void LoadText()
    {
        if (dialogue_text != null) textLines = (dialogue_text.text.Split('\n'));
    }
}
