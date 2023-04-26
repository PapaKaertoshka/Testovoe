using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crystal : MonoBehaviour
{
    [SerializeField] GameObject confetti;
    [SerializeField] BoxCollider collider;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cube cube))
        {
            collider.enabled = false;
            StartCoroutine(Collecting());
        }
    }
    private void Update()
    {
        transform.Rotate(0,0,2f);
    }
    IEnumerator Collecting()
    {
        CollectingCrystal();
        yield return new WaitForSeconds(0.5f);
        confetti.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        
    }
    void CollectingCrystal()
    {
        transform.DOMove(new Vector3(transform.position.x,2f,transform.position.z),0.8f);
        transform.DORotate(new Vector3(-90f, 200f,0), 0.8f, RotateMode.Fast);
    }
}
