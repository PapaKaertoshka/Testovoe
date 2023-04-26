using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset;
    [SerializeField] PlayerTest playerTest;
    public Vector3 cubesOffset;
    private Vector3 currentOffset;
    private void Start()
    {
        currentOffset = offset;        
    }
    private void OnEnable()
    {
        PlayerTest.Added += Cube_Added;
        Cube.Destroyed += Cube_Destroyed;
    }
    private void OnDisable()
    {
        PlayerTest.Added -= Cube_Added;
        Cube.Destroyed -= Cube_Destroyed;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.localPosition + currentOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPosition, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }
    public void Cube_Added()
    {
        currentOffset = offset + cubesOffset * playerTest.numberOfCubes;
    }
    public void Cube_Destroyed()
    {
        currentOffset = offset + cubesOffset * playerTest.numberOfCubes;
    }
}


