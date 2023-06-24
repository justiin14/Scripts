using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShooterUIManager : MonoBehaviour
{
    public GameObject canvasEquipRifle, canvasHitTargets, canvasCrosshair; //canvases
    public GameObject fpsController, cam, rifle;    //scene objects
    public Text hits;
    Vector3 boxPosition, fpsPosition;

    public static bool isMissionCompleted;

    private void Start()
    {
        boxPosition = cam.transform.position;
    }

    void Update()
    {
        fpsPosition = fpsController.transform.position;

        if(Vector3.Distance(fpsPosition, boxPosition) < 3f && !Shooter.isRifleEquipped && !Tracker.isMissionInProgress)
        {
            canvasEquipRifle.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                StartCoroutine(StartShootingSession());
            }
        }
        else
        {
            canvasEquipRifle.SetActive(false);
        }

        if (Shooter.isRifleEquipped)
        {
            if (!isMissionCompleted)
            {
                hits.text = Shooter.targetsHit.ToString();
                if (Shooter.targetsHit == 10)
                {
                    Tracker.missionsCompleted++;
                    isMissionCompleted = true;
                    Destroy(canvasHitTargets);
                    StartCoroutine(EndShootingSession());
                }
            }
            if (isMissionCompleted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(EndShootingSession());
                }
            }
            
        }
    }

    IEnumerator EndShootingSession()
    {
        yield return new WaitForSeconds(.5f);
        Shooter.isRifleEquipped = false;

        canvasCrosshair.SetActive(false);
        rifle.SetActive(false);
        cam.SetActive(false);
        fpsController.SetActive(true);
    }

    IEnumerator StartShootingSession()
    {
        Shooter.isRifleEquipped = true;
        
        cam.SetActive(true);
        rifle.SetActive(true);
        canvasCrosshair.SetActive(true);
        fpsController.SetActive(false);
        canvasEquipRifle.SetActive(false);

        if(!isMissionCompleted)
            canvasHitTargets.SetActive(true);

        yield return null;
    }
}
