using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjectFollow;
    public GameObject ObjectPlayer;

    public GameObject Old_Follow;

    public GameObject ProjectileEnemyTarget;
    public bool isReseting = false;

    public IEnumerator CameraReset()
    {

        yield return new WaitForSecondsRealtime(2.5f);

        ObjectFollow = Old_Follow;
        isReseting = false;

    }

    private void Start()
    {
        Old_Follow = ObjectFollow;
    }

    private void Update()
    {
        if (ObjectFollow == null)
        {
            ObjectFollow = Old_Follow;
        }

        if ( (ObjectFollow != Old_Follow) && (isReseting == false) )
        {
            StartCoroutine(CameraReset());
            isReseting = true;
        }

        FixedCameraFollowSmooth(this.GetComponent<Camera>(), ObjectFollow.transform, ObjectPlayer.transform);
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {

        float zoomFactor = 1.5f;
            float followTimeDelta = 0.1f;

            // Midpoint we're after
            Vector3 midpoint = (t1.position + t2.position) / 2f;

            // Distance between objects
            float distance = (t1.position - t2.position).magnitude;

            // Move camera a certain distance
            Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

            // Adjust ortho size if we're using one of those
            if (cam.orthographic)
            {
                // The camera's forward vector is irrelevant, only this size will matter
                //cam.orthographicSize = distance;
            }
            // You specified to use MoveTowards instead of Slerp
            cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

            // Snap when close enough to prevent annoying slerp behavior
            if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            {
                cam.transform.position = cameraDestination;
            }

        

    }

}
