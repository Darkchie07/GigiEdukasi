using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuNav : MonoBehaviour
{

    private void Awake()
    {
        if (Audio.Instance.audioSource.clip != Audio.Instance.clipHome)
            Audio.Instance.PlayHomeBgm();

        if (!Audio.Instance.audioSource.isPlaying)
            Audio.Instance.PlayMusic();
    }

    public void KontrolSikatGigi() => Helper.GoToPemantauanSikatGigi();

    public void Games()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Drag&Drop 1");
    }
}
