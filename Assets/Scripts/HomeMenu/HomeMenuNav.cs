using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuNav : MonoBehaviour
{
    public void KontrolSikatGigi() => Helper.GoToPemantauanSikatGigi();

    public void Games()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Drag&Drop 1");
    }
}
