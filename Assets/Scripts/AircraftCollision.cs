using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    public AudioSource engineAudio;
    public AudioClip crashSound;
    private AudioSource audiosource;
    private AircraftController aircraftController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        aircraftController = GetComponent<AircraftController>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.StartsWith("Building"))
        {
            
            if(aircraftController != null && !aircraftController.isCrashed){
                aircraftController.isCrashed = true;
                 
                 Debug.Log("飛機撞到建築!");
                if(engineAudio != null)
                {
                    Debug.Log("準備停止引琴聲");
                    engineAudio.Stop();
                }
                if (audiosource != null && crashSound != null)
                {
                    audiosource.PlayOneShot(crashSound);
                }
            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (engineAudio != null &&
        !engineAudio.isPlaying &&
        aircraftController != null &&
        !aircraftController.isCrashed)
    {
        Debug.LogWarning("引擎聲意外停止！");
    }
    }
}
