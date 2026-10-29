
using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public AudioClip successSound;
    public float soundDuration = 0.9f;

    private bool passed = false;

    void OnTriggerEnter(Collider other)
    {
        AircraftController aircraft =
            other.GetComponentInParent<AircraftController>();

        if (aircraft != null && !passed && !aircraft.isCrashed)
        {
            passed = true;

            Debug.Log("成功通過障礙物！");

            if (successSound != null)
            {
                StartCoroutine(PlayShortSound());
            }
        }
    }

    IEnumerator PlayShortSound()
    {
        GameObject soundObject = new GameObject("SuccessSound");

        AudioSource source = soundObject.AddComponent<AudioSource>();

        source.clip = successSound;
        source.playOnAwake = false;
        source.spatialBlend = 0f;

        source.Play();

        yield return new WaitForSeconds(
            Mathf.Min(soundDuration, successSound.length)
        );

        source.Stop();
        Destroy(soundObject);
    }
}
