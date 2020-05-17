using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 offset;
    public float viewingspeed = 10;
    public float followspeed = 10;

    public void looktotarget()
    {
        Vector3 _lookdirection = ObjectToFollow.position - transform.position;
        Quaternion _rotat = Quaternion.LookRotation(_lookdirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotat, viewingspeed * Time.deltaTime);
    }
    public void movetowardtarget()
    {
        Vector3 _targetPos = ObjectToFollow.position +
                             ObjectToFollow.forward * offset.z +
                             ObjectToFollow.right * offset.x +
                             ObjectToFollow.up * offset.y;

        transform.position = Vector3.Lerp(transform.position, _targetPos, followspeed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        looktotarget();
        movetowardtarget();
    }
}
