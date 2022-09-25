using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PemantauanSikatGigiManager : MonoBehaviour
{
    [System.Serializable]
    public class HariPemantauan
    {
        public int indx;
        public string harike;
        public Button btnHari;
    }
    public List<HariPemantauan> listHariPemantauan;

    public static PemantauanSikatGigiManager Instance;
    public int selectedIndexHari;
    public Color colorActive; // warna button ketika sudah punya gambar
    public Color colorNotActive; // warna button ketika belum punya gambar
    public GameObject pageFoto;
    public GameObject pagePemantauan;
    public GameObject pageKeluar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {

        //set the button
        foreach (var a in listHariPemantauan)
        {
            a.btnHari.onClick.AddListener(() =>
            {
                selectedIndexHari = a.indx;
                pageFoto.SetActive(true);
                pagePemantauan.SetActive(false);
            });
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pageFoto.activeSelf)
            {
                if (pageFoto.GetComponent<PageFotoScript>().ImageShow.transform.parent.gameObject.activeSelf)
                {
                    pageFoto.GetComponent<PageFotoScript>().ImageShow.transform.parent.gameObject.SetActive(false);
                    return;
                }

                pageFoto.SetActive(false);
                pagePemantauan.SetActive(true);
                return;
            }

            if (pagePemantauan.activeSelf)
            {
                //change scene
                return;
            }

            if (pageKeluar.activeSelf)
            {
                ExitApp();
                return;
            }
        }
    }



    public void LogOut()
    {
        Helper.LogOut();
        pageFoto.SetActive(false);
        pagePemantauan.SetActive(false);
        pageKeluar.SetActive(true);

    }

    public void ExitApp()
    {
        Application.Quit();
    }



}
