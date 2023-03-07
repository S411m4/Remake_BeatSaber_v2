using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] DestroyOnTrigger wallMiss;

    [SerializeField] private int blueSaberLayer;
    [SerializeField] private int redSaberLayer;
    [SerializeField] private int blueCubeLayer;
    [SerializeField] private int redCubeLayer;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;

    [SerializeField] TextMeshProUGUI noOfCubesHit;

    [SerializeField] XRBaseController rightController;
    [SerializeField] XRBaseController leftController;
 
    private int hitNo = 0;
    private int comboNo = 0;

    public event EventHandler<onRightWrongCutEventArgs> onRightCut;
    public event EventHandler<onRightWrongCutEventArgs> onWrongCut;

    public class onRightWrongCutEventArgs : EventArgs { public GameObject cube; }


    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Lighsaber.onAnyCut += Lighsaber_onAnyCut;

        GameManager.Instance.onGameOver += GameManager_onGameOver;

        wallMiss.onCubeMiss += WallMiss_onCubeMiss1;
    }

    private void WallMiss_onCubeMiss1(object sender, EventArgs e)
    {
        comboNo = 0;
        AudioManager.Instance.MissedSound(wallMiss.transform.position);
    }

    private void GameManager_onGameOver(object sender, EventArgs e)
    {
        noOfCubesHit.text = hitNo.ToString();
    }

    private void WallMiss_onCubeMiss(object sender, EventArgs e)
    {
        comboNo = 0;
    }

    private void Lighsaber_onAnyCut(object sender, Lighsaber.onAnyCutEventArgs e)
    {
        if (e.saber.layer==blueSaberLayer) { leftController.SendHapticImpulse(0.5f, 0.3f); }
        else if (e.saber.layer==redSaberLayer) { rightController.SendHapticImpulse(0.5f,0.3f); }

        if ((e.saber.layer == blueSaberLayer && e.cube.layer == blueCubeLayer) || (e.saber.layer == redSaberLayer && e.cube.layer == redCubeLayer))
        {
            CorrectCut();
            onRightCut?.Invoke(this, new onRightWrongCutEventArgs {cube=e.cube });
            
        }
        else
        {
            WrongCut();
            onWrongCut?.Invoke(this, new onRightWrongCutEventArgs { cube = e.cube });

        }

        scoreText.text = hitNo.ToString();
        comboText.text = comboNo.ToString();
    }

    private void CorrectCut()
    {
        
        hitNo++;
        comboNo++;
    }

    private void WrongCut()
    {
        
        comboNo = 0;
    }

    
}
