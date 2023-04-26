using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private BansheeGz.BGSpline.Components.BGCcTrs bgCurve;
    private void Start()
    {
        player = FindObjectOfType<Movement>();
        bgCurve = FindObjectOfType<BansheeGz.BGSpline.Components.BGCcTrs>();
    }
    public void StartPlaying()
    {
        player.enabled = true;
        bgCurve.enabled = true;
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
