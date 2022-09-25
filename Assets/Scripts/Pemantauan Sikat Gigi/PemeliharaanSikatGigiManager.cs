using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PemeliharaanSikatGigiManager : MonoBehaviour
{
    public static PemeliharaanSikatGigiManager Instance;

    [SerializeField] private GameObject pagePemantauan;
    [SerializeField] private GameObject PageKontrolSikatGigi;
    [SerializeField] private GameObject PageKontrolDebrisIndeks;
    [SerializeField] private GameObject PageKeluar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PageKontrolSikatGigi.activeSelf)
            {
                if (PageKontrolSikatGigi.GetComponent<PageFotoScript>().ImageShow.transform.parent.gameObject.activeSelf)
                {
                    PageKontrolSikatGigi.GetComponent<PageFotoScript>().ImageShow.transform.parent.gameObject.SetActive(false);
                    OrientationToPortrait();
                    return;
                }

                PageKontrolSikatGigi.SetActive(false);
                pagePemantauan.SetActive(true);
                return;
            }

            if (pagePemantauan.activeSelf)
            {
                //change scene
                return;
            }

            if (PageKeluar.activeSelf)
            {
                ExitApp();
                return;
            }
        }
    }

    public void OrientationToAuto() => StartCoroutine(ChangeOrienTation(false));


    public void OrientationToPortrait() => StartCoroutine(ChangeOrienTation(true));


    IEnumerator ChangeOrienTation(bool portrait)
    {
        yield return null;
        if (portrait)
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
    #region EXIT FUNC
    public void LogOut()
    {
        Helper.LogOut();
        PageKontrolSikatGigi.SetActive(false);
        PageKontrolDebrisIndeks.SetActive(false);
        PageKeluar.SetActive(true);

    }

    public void ExitApp()
    {
        Application.Quit();
    }
    #endregion
}
