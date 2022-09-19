using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LoginManager : MonoBehaviour
{
    [System.Serializable]
    public class PageLanjut
    {
        public Button btnLanjut;
        public GameObject page;
    }

    [System.Serializable]
    public class PageLogin
    {
        public GameObject page;
        public TMP_InputField inputNama;
        public TMP_InputField inputUmur;
        public TMP_InputField inputSekolah;
        public TMP_Dropdown inputJenisKelamin;
        public Button btnMasuk;
    }

    public PageLanjut lanjut;
    public PageLogin login;

    private IEnumerator Start()
    {
        Application.targetFrameRate = 120;

        yield return new WaitUntil(() => RespondenData.Instance != null);
        yield return new WaitUntil(() => RespondenData.Instance.doneLoadData);

        lanjut.btnLanjut.onClick.AddListener(() =>
        {
            //cek data
            if (string.IsNullOrEmpty(RespondenData.Instance.currentDataSelected.nama)) // kalau data baru
            {
                lanjut.page.SetActive(false);
                login.page.SetActive(true);
            }
            else
            {
                // pindah scene ke menu;
                Helper.GoToPemantauanSikatGigi();
            }
        });

        login.btnMasuk.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(login.inputNama.text))
            {
                //munculkan popup nama kosong

                return;
            }
            if (string.IsNullOrEmpty(login.inputUmur.text))
            {
                //munculkan popup umur kosong
                return;
            }

            if (string.IsNullOrEmpty(login.inputSekolah.text))
            {
                //munculkan popup sekolah kosong
            }

            // isi current data
            RespondenData.Instance.currentDataSelected.SetDataAwal(login.inputNama.text.Trim(),
                login.inputUmur.text.Trim(),
                login.inputSekolah.text.Trim(),
                (login.inputJenisKelamin.value).ToString());

            // insert the data to list
            RespondenData.Instance.InsertNewDataResponden();

            //save with add file csv
            RespondenData.Instance.CreateSaveCsvFile();

            // pindah ke scene menu
            Helper.GoToPemantauanSikatGigi();
        });
    }

}
