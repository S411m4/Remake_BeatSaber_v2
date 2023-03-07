using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackTextUI : MonoBehaviour
{
    private Animator animator;

    [SerializeField] GameObject missText;
    [SerializeField] GameObject wrongColorText;
    [SerializeField] DestroyOnTrigger wallMiss;

    private void Start()
    {
        animator = GetComponent<Animator>();

        wallMiss.onCubeMiss += WallMiss_onCubeMiss;
        ScoreManager.Instance.onWrongCut += ScoreManager_onWrongCut;
        ScoreManager.Instance.onRightCut += ScoreManager_onRightCut;
    }

    private void ScoreManager_onRightCut(object sender, ScoreManager.onRightWrongCutEventArgs e)
    {
        wrongColorText.SetActive(false);
        missText.SetActive(false);
    }

    private void ScoreManager_onWrongCut(object sender, ScoreManager.onRightWrongCutEventArgs e)
    {
        wrongColorText.SetActive(true) ;
        missText.SetActive(false) ;

    
    }

    private void WallMiss_onCubeMiss(object sender, System.EventArgs e)
    {
        
        wrongColorText.SetActive(false);
        missText.SetActive(true);


    }

}
