using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] private CameraFollowing cameraFollowing;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Поменял");
        if (other.TryGetComponent(out Cube cube))
        {
            cameraFollowing = FindObjectOfType<CameraFollowing>();
            cameraFollowing.enabled = false;
        }
    }
}
