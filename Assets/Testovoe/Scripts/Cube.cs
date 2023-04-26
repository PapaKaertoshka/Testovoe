using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public static event Action Destroyed = delegate { };
    [SerializeField]
    private bool hasParent = false;
    private Rigidbody rb;
    /* [SerializeField]
     private PlayerTest player;*/
    [SerializeField]
    private bool meetObstacle = false;

    private void Start()
    {
        /*player = FindObjectOfType<PlayerTest>();*/
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ObstacleTest ot) || other.gameObject.TryGetComponent(out FinishLine fl)) meetObstacle = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*StartCoroutine(SetKinematic());*/
        if (collision.gameObject.TryGetComponent(out ObstacleTest ot) && meetObstacle || collision.gameObject.TryGetComponent(out FinishLine fl) && meetObstacle)
        {
            StartCoroutine(Destroing());
        }
    }

    private void Update()
    {
        if (transform.position.y < -1f) StartCoroutine(Destroing());
    }

    public bool GetHasParent()
    {
        return hasParent;
    }
    
    public void SetHasParent(bool hasParent)
    {
        this.hasParent = hasParent;
    }
    
    IEnumerator SetKinematic()
    {
        this.rb.isKinematic = true;
        yield return new WaitForSeconds(0.03f);
        this.rb.isKinematic = false;
        yield return new WaitForSeconds(0.01f);
    }
   
    IEnumerator Destroing()
    {
        Debug.Log("Препятствие");
        PlayerTest pt = FindObjectOfType<PlayerTest>();
        transform.SetParent(null);
        Destroyed.Invoke();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
