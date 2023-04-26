using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAxe : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Поменял");
        if(other.TryGetComponent(out Cube cube))
        {
            movement = FindObjectOfType<Movement>();
            movement.changeAxes = !movement.changeAxes;
        }
    }
}
