using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject followPoint;
    public GameObject camera;

    void Update()
    {
        Vector3 position = new Vector3(followPoint.transform.position.x, transform.position.y, followPoint.transform.position.z);

        //camera.transform.Rotate(Vector3.left, 20 * Time.deltaTime, Space.Self);
        
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime);

        Vector3 lookAtMe = new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z);
        transform.LookAt(lookAtMe);
    }
}
