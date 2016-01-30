using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    public Transform target;

    private Camera camera;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

	// Update is called once per frame
	void Update () {
	    
        if(target && camera)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 dest = camera.transform.position + delta;
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, dest, ref velocity, dampTime);
        }
	}
}
