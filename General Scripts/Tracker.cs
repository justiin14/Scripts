using UnityEngine;

public class Tracker : MonoBehaviour
{
    //Car crash
    public static AudioClip carSong;


    //missions
    public static int missionsCompleted = 0;

    public static bool isMissionInProgress = false;
    public static bool isFishingRodCollected = false;
    public static bool isFishCollected = false;
    public static bool isFpsInsideWater = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            missionsCompleted = 3;
        }
    }
}
