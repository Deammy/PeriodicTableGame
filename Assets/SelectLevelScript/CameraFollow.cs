using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Camera;
    public float SmoothSpeed;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 RightPosition = Player.position + Camera;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position,RightPosition,SmoothSpeed);
        transform.position = SmoothPosition;
    }
}
