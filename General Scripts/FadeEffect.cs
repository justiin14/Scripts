using UnityEngine;
public class FadeEffect : MonoBehaviour
{
    public static Animator animator;

    public static void FadeToNextLevel()
    {
        animator.SetTrigger("Fade out");
    }
}
