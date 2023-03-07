using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AllSoundEffectsSO allSoundEffectsSO;


    public static AudioManager Instance {get;private set;}

    private void Start()
    {
        Instance = this;

        ScoreManager.Instance.onRightCut += ScoreManager_onRightCut;
        ScoreManager.Instance.onWrongCut += ScoreManager_onWrongCut;
    }

    private void ScoreManager_onWrongCut(object sender, ScoreManager.onRightWrongCutEventArgs e)
    {
        PlaySound(allSoundEffectsSO.wrongCut, e.cube.transform.position);

    }

    private void ScoreManager_onRightCut(object sender, ScoreManager.onRightWrongCutEventArgs e)
    {
        PlaySound(allSoundEffectsSO.rightCut, e.cube.transform.position);
    }

    public void MissedSound(Vector3 position)
    {
        PlaySound(allSoundEffectsSO.wrongCut, position, 1f);   
    }
    private void PlaySound(AudioClip clip,Vector3 position ,float volume=1f)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    private void PlaySound(AudioClip[] clips, Vector3 position, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(clips[Random.Range(0,clips.Length)],position,volume);
    }

}
