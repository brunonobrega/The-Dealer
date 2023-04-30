using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    // This camera position should be the same as the car's position
    
    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3 (0, 0, -10);
    }
}
