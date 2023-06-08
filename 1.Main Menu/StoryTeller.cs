using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTeller : MonoBehaviour
{
    public TMP_Text left, right, middle, instruction;
    public static string characterName;
    List<string> story;
    bool isTransitioning = false, hasChosen=false;
    void Start()
    {
        story = new List<string>() { "You are a 9-year old boy.\r\n Your name is",
            "You and your parents go for a trip to the old cabin. \r\n",
            "You will be fishing, playing football and hunting.",
            "You leave home. It is heavily raining.",
            "You can barely see anything on the road.",
            "However, your father seems to be handling the driving.",
            "When suddenly..."};

        left.text = "Jake";
        right.text ="John";
        middle.text = story[0];
    }

    void Update()
    {
        if (!isTransitioning)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterName = "John";
                isTransitioning = true;
                DisplayChoice(right);
                StartCoroutine(ProcessChoice());
                
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characterName = "Jake";
                isTransitioning = true;
                DisplayChoice(left);
                StartCoroutine(ProcessChoice());
            }
            Debug.Log(characterName);    
        }

        if (hasChosen && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            story.RemoveAt(0);

            if (story.Count == 0)
                StartCoroutine(ChangeScene());
            else
            {
                StartCoroutine(Wait());
                middle.text = story[0];
            }
        }
    }

    void DisplayChoice(TMP_Text text)
    {
        text.fontSize = 80;
        text.color = Color.yellow;
        text.fontStyle = FontStyles.Bold;
    }

    IEnumerator ProcessChoice()
    {
        //wait 2s
        yield return new WaitForSeconds(1.5f);

        //play disappear animation for all items on screen
        left.text = "";
        right.text = "";
        middle.text = story[0];
        instruction.text = "";
        hasChosen = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneChanger.LoadNextScene();
    }
}
