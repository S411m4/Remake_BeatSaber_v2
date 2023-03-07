using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCanvasUI : MonoBehaviour
{

    [SerializeField] Button ContinueBtn;       
    [SerializeField] Button RestartBtn;

    private void Start()
    {
        ContinueBtn.onClick.AddListener(()=> { Time.timeScale = 1f; gameObject.SetActive(false); });
        RestartBtn.onClick.AddListener(()=> { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }
}
