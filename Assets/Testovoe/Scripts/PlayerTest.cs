using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTest : MonoBehaviour
{
    public static event Action Added = delegate { };
    [SerializeField]
    public int numberOfCubes = 0;
    [SerializeField]
    private BoxCollider triggerCollider;
    [SerializeField] 
    private int numberOfCrystals = 0;
    private Rigidbody rb;
    [SerializeField] private GameManager gm;
    
    public void Start()
    {
        numberOfCubes = GetComponentsInChildren<Cube>().Length;
        rb = gameObject.GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }
    public void OnEnable()
    {
        Cube.Destroyed += Cube_Destroyed;
    }
    public void OnDisable()
    {
        Cube.Destroyed -= Cube_Destroyed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out FinishLine fl))
        {
            StartCoroutine(gm.Finishing(fl.GetMultiplier()));
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cube cube))
        {
            if(cube.GetHasParent() == false) {
                cube.SetHasParent(true);
                cube.transform.SetParent(transform);
                numberOfCubes++;
                Added.Invoke();
                cube.transform.position = new Vector3(transform.position.x, numberOfCubes,transform.position.z);
            }
        }
        if (other.gameObject.TryGetComponent(out Crystal crystal))
        {
            numberOfCrystals++;
        }
    }
    public int GetNumberOfCrystlas()
    {
        return numberOfCrystals;
    }
    private void Cube_Destroyed()
    {
        numberOfCubes = GetComponentsInChildren<Cube>().Length;
        if (numberOfCubes <= 0)
        {
            gm.GameOver();
        }
    }
}
