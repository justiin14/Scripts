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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            KickBall.goals = 3;
            KickBall.crossbars = 3;
            missionsCompleted++;
            Debug.Log(missionsCompleted);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isFishingRodCollected = true;
        }
    }
}
