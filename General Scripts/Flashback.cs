using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Flashback : MonoBehaviour
{
    public static bool startFlashback = false;
    public PostProcessVolume ppVolume;
           ColorGrading cg;
           Bloom bloom;

    bool done = false, isGrayscale = false;
    

    void Start()
    {
        ppVolume.profile.TryGetSettings(out bloom);
        ppVolume.profile.TryGetSettings(out cg);
        bloom.softKnee.value = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            startFlashback = true;
        }

        if (startFlashback)
        {
            StartMemoryFlash();
        }
    }
    private void StartMemoryFlash()
    {
        if (!done) //fade to white
        {
            if (bloom.softKnee.value < 1)
            {
                IncreaseBloomSoftKnee();
            }
            else
            {
                done = true;
                cg.saturation.value = -100;
                isGrayscale = !isGrayscale;
                if (!isGrayscale)
                {
                    cg.saturation.value = 0;
                }
            }
        }
        else //fade back to grayscale
        {
            if (bloom.softKnee.value > 0)
            {
                DecreaseBloomSoftKnee();
            }
            if (bloom.softKnee.value <= 0.2)
            {
                startFlashback = false;
                done = false;
                
                bloom.softKnee.value = 0;
                
            }
        }
    }

    private void DecreaseBloomSoftKnee()
    {
        bloom.softKnee.value -= 1 / 40f;
    }

    private void IncreaseBloomSoftKnee()
    {
        bloom.softKnee.value += 1 / 40f;
    }
}
