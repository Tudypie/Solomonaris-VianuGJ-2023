using UnityEngine;
using UnityEngine.Events;

public class CheckObjectInView : MonoBehaviour
{
    public Transform targetObject;
    public Camera mainCamera;

    public UnityEvent findObjectEvent;

    public AudioClip foundObjectSound;

    private bool invoked = false;

    private void Update()
    {
        if (targetObject != null && mainCamera != null)
        {
            Vector3 targetPosition = mainCamera.WorldToViewportPoint(targetObject.position);
            
            bool isObjectInView = targetPosition.x >= 0 && targetPosition.x <= 1 && targetPosition.y >= 0 && targetPosition.y <= 1;

            if (isObjectInView && !invoked)
            {   
                invoked = true;
                AudioPlayer.Instance.PlayAudio(foundObjectSound);
                Invoke("ObjectFound", 2f);
            }
        }
    }

    private void ObjectFound() => findObjectEvent?.Invoke();
}
