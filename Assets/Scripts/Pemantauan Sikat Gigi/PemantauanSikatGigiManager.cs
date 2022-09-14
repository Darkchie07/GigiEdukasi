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
        OnEnablePemantauan();

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
                    pageFoto.GetComponent<PageFotoScript>().OrientationToPortrait();
                    return;
                }

                pageFoto.SetActive(false);
                pagePemantauan.SetActive(true);
                OnEnablePemantauan();
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

    void OnEnablePemantauan()
    {
        int i = 0;
        foreach (var a in RespondenData.Instance.currentDataSelected.daftarGambargigi)
        {
            if (a.listImageGigi.Count == 0)
            {
                listHariPemantauan[i].btnHari.image.color = colorNotActive;
            }
            else
            {
                listHariPemantauan[i].btnHari.image.color = colorActive;
            }
            i++;
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
