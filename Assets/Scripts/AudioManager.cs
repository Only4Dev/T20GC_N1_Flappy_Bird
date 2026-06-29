using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip flapClip;
    [SerializeField] AudioClip scoreClip;

    [SerializeField] AudioSource audioSource;

    public void PlayFlap()
    {
        audioSource.PlayOneShot(flapClip);
    }

    public void PlayScore()
    {
        audioSource.PlayOneShot(scoreClip);
    }

}
