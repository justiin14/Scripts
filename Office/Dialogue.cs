using UnityEngine;
using TMPro;
using System.Collections;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]public struct SubtitleText
    {
        public string text;
        public float time;
    }

    public TextMeshProUGUI textComponent;
    public SubtitleText[] lines;

    void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(TypeLines());
    }

    IEnumerator TypeLines()
    {
        foreach(var line in lines)  
        {
            textComponent.text = line.text;
            yield return new WaitForSeconds(line.time);
            if (line.text == lines.Last().text)
            {
                InterractionKey.hasDialogEnded = true;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}

