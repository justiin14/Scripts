using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTeller : MonoBehaviour
{
    public TMP_Text left, right, middle, instruction;

    List<string> leftChoice, rightChoice, story;
    int i = 0;
    bool isTransitioning = false;
    void Start()
    {
        leftChoice = new List<string>() { "Jake", "Fishing", "Rihanna" };
        rightChoice = new List<string>() { "John", "Hunting", "Shakira"  };
        story = new List<string>() { "You are a 9-year old boy.\r\n Your name is",
            "You all go for a trip to the old cabin. \r\nYou will be",
            "You get to choose the music.\r\n The song heard on the radio is"};

        left.text = leftChoice[i];
        right.text = rightChoice[i];
        middle.text = story[i];
    }

    void Update()
    {
        if (!isTransitioning)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (i == 1)
                {
                    GeneralVariables.carSong = (AudioClip)Resources.Load("2");
                }
                isTransitioning = true;
                DisplayChoice(right);
                StartCoroutine(ProcessChoice());
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (i == 1)
                {
                    GeneralVariables.carSong = (AudioClip)Resources.Load("1");
                }
                isTransitioning = true;
                DisplayChoice(left);
                StartCoroutine(ProcessChoice());

            }
        }
        if (i == story.Count)
        {
            StartCoroutine(ChangeScene());
        }
    }

    void DisplayChoice(TMP_Text text)
    {
        text.fontSize = 80;
        text.color = Color.yellow;
        text.fontStyle = FontStyles.Bold;
    }

    void ResetChoice(TMP_Text text)
    {
        text.fontSize = 70;
        text.color = Color.white;
        text.fontStyle = FontStyles.Normal;
    }

    IEnumerator ProcessChoice()
    {
        i++;
        //wait 2s
        yield return new WaitForSeconds(1.5f);

        //play disappear animation for all items on screen
        left.text = "";
        right.text = "";
        middle.text = "";
        instruction.text = "";
        //wait 1s
        yield return new WaitForSeconds(1);

        //reset styles of choice
        ResetChoice(left);
        ResetChoice(right);

        //load next dialogue and options
        left.text = leftChoice[i];
        right.text = rightChoice[i];
        middle.text = story[i];
        isTransitioning = false;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneChanger.LoadNextScene();
    }
}
