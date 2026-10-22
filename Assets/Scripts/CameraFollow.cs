
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0,5,-15);
    public float smoothSpeed = 5f;
    
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(target == null) return;
        Vector3 desiredPosition =target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            Mathf.Clamp01(smoothSpeed * Time.deltaTime)
        );
        transform.LookAt(target);
    }
}
