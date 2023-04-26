using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerTest pt;
    [SerializeField] private Movement movement;
    [SerializeField] private BansheeGz.BGSpline.Components.BGCcTrs bgCurve;
    [SerializeField] private GameObject ending;
    [SerializeField] private Text numbOfCrystals;
    [SerializeField] private GameObject gameOver;


    void Start()
    {
        pt = FindObjectOfType<PlayerTest>();
        movement = FindObjectOfType<Movement>();
        bgCurve = FindObjectOfType<BansheeGz.BGSpline.Components.BGCcTrs>();
        movement.enabled = false;
        bgCurve.enabled = false;
    }
    public IEnumerator Finishing(float multiplier)
    {
        yield return new WaitForSeconds(0.3f);
        movement.enabled = false;
        bgCurve.enabled = false;
        ending.SetActive(true);
        numbOfCrystals.text = "You've collected " + pt.GetNumberOfCrystlas() * multiplier + " crystals";
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        movement.enabled = false;
        bgCurve.enabled = false;
    }
}
