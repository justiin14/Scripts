[System.Serializable]
public class Data
{
    public int level, missionsCompleted;

    public bool footballTriggered, kickBallIncremented,
                freesbieThrowTriggered, isFishCollected,
                shooterTriggered, shooterCompleted;

    public Data(Tracker tracker)
    {
        level = tracker.level;
        missionsCompleted = tracker.missions;

        footballTriggered = tracker.footballTriggered;
        kickBallIncremented = tracker.kickBallIncremented;

        isFishCollected = tracker.fishCollected;
        freesbieThrowTriggered = tracker.freesbieThrowTriggered;

        shooterTriggered = tracker.shooterTriggered;
        shooterCompleted = tracker.shooterCompleted;
    }
}
