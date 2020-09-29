using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceData : MonoBehaviour
{
    int choice;
    public DialogQuestionsLogic dialogLogic;

    public void MakeChoice(int c)
    {
        choice = c;
        dialogLogic.NextQuestion();
    }

    public int GetChoice()
    {
        return choice;
    }
}
