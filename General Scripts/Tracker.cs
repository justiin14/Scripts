using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracker : MonoBehaviour
{
    //missions
    public static int missionsCompleted = 0;

    public static bool isMissionInProgress = false;
    public static bool isFishingRodCollected = false;
    public static bool isFishCollected = false;
    public static bool isFpsInsideWater = false;

    // for save system

    public int level, missions;
    public bool footballTriggered;
    public bool kickBallIncremented;

    public bool freesbieThrowTriggered;
    public bool fishCollected;

    public bool shooterTriggered;
    public bool shooterCompleted;


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

    public void Save()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        missions = missionsCompleted;

        footballTriggered = TriggerFootballMemory.triggered;
        kickBallIncremented = KickBall.incremented;

        freesbieThrowTriggered = FreesbieThrow.triggered;
        fishCollected = isFishCollected;

        shooterTriggered = ShooterFlashback.triggered;
        shooterCompleted = ShooterUIManager.isMissionCompleted;

        SaveSystem.SaveData(this);
    }

    public void Load()
    {
        Data data = SaveSystem.LoadSave();

        level = data.level;
        missionsCompleted = data.missionsCompleted;
        SceneManager.LoadScene(level);

        //for football mission
        TriggerFootballMemory.triggered = data.footballTriggered;
        KickBall.incremented = data.kickBallIncremented;

        //for shooting mission
        ShooterFlashback.triggered = data.shooterTriggered;
        ShooterUIManager.isMissionCompleted = data.shooterCompleted;

        //for fishing mission
        FreesbieThrow.triggered = data.freesbieThrowTriggered;
        isFishCollected = data.isFishCollected;
    }
}
