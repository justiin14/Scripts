using TMPro;
using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryUIManager : MonoBehaviour
{
    List<string> story;
    static TextAsset textAsset;
    public TMP_Text line, left, middle, right, arrows;
    int i = 0;

    bool isTransitioning = false;

    void Start()
    {
        textAsset = Resources.Load<TextAsset>("story");
        string fileContents = textAsset.text;

        story = new List<string>();
        try
        {
            using (StringReader sr = new StringReader(fileContents))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    story.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        line.text   = story[i];
        left.text   = story[++i];
        middle.text = story[++i];
        right.text  = story[++i];
    }

    void Update()
    {
        if (!isTransitioning)
        {
            if (Input.anyKey)
            {
                arrows.text = "";
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (left.text != "")
                    StartCoroutine(DisplayChoice(0));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (middle.text != "")
                    StartCoroutine(DisplayChoice(1));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (right.text != "")
                    StartCoroutine(DisplayChoice(2));
            }
        }
        
    }

    IEnumerator DisplayChoice(int choice)
    {
        isTransitioning = true;
        switch (choice)
        {
            case 0:
                left.fontStyle = FontStyles.Underline;
                break;

            case 1:
                middle.fontStyle = FontStyles.Underline;
                break;

            case 2:
                right.fontStyle = FontStyles.Underline;
                break;
        }

        yield return new WaitForSeconds(1f);
        ResetTexts(choice);

        yield return new WaitForSeconds(0.5f);
        ContinueStory();
    }

    private void ContinueStory()
    {
        isTransitioning = false;
        i++;
        if (i < story.Count)
        {
            line.text = story[i];
            left.text = story[++i];
            middle.text = story[++i];
            right.text  = story[++i];
        }
        else
        {
            SceneChanger.LoadNextScene();
        }
    }

    private void ResetTexts(int choice)
    {
        switch (choice)
        {
            case 0:
                left.fontStyle = FontStyles.Normal;
                break;

            case 1:
                middle.fontStyle = FontStyles.Normal;
                break;

            case 2:
                right.fontStyle = FontStyles.Normal;
                break;
        }
        
        line.text = "";
        left.text = "";
        middle.text = "";
        right.text = "";
    }
}
