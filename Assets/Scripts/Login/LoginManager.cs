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
    bool canClick = true;

    [SerializeField] private GameObject PageLoading;
    [SerializeField] private GameObject txtPrefab;
    [SerializeField] private Transform contentParentTxt;
    [SerializeField] private Canvas canvas;

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
                Helper.GoToHomeMenu();
            }
        });

        login.btnMasuk.onClick.AddListener(() =>
        {
            if (!canClick)
                return;
            if (string.IsNullOrEmpty(login.inputNama.text))
            {
                //munculkan popup nama kosong
                SetTextMessage("Data Nama tidak boleh kosong");
                return;
            }
            if (string.IsNullOrEmpty(login.inputUmur.text))
            {
                //munculkan popup umur kosong
                SetTextMessage("Data Umur tidak boleh kosong");
                return;
            }

            if (string.IsNullOrEmpty(login.inputSekolah.text))
            {
                //munculkan popup sekolah kosong
                SetTextMessage("Data Sekolah tidak boleh kosong");
                return;
            }

            // isi current data
            RespondenData.Instance.currentDataSelected.SetDataAwal(login.inputNama.text.Trim(),
                login.inputUmur.text.Trim(),
                login.inputSekolah.text.Trim(),
                (login.inputJenisKelamin.value).ToString());

            // insert the data to list
            RespondenData.Instance.InsertNewDataResponden();

            //save with add file csv
            //RespondenData.Instance.CreateSaveCsvFile();

            // uploadfile form
            ShowLoading();
            StartCoroutine(Helper.CoroutineUploadFormRespondenData(
                RespondenData.Instance.currentDataSelected.nama,
                RespondenData.Instance.currentDataSelected.umur,
                RespondenData.Instance.currentDataSelected.sekolah,
                (RespondenData.Instance.currentDataSelected.jenisKelamin == "0") ? "Laki-laki" : "Perempuan"
                ,
                SuccessUploadFormRespondenData,
                ErrorUploadFileResponden
                ));
        });
    }

    void SuccessUploadFormRespondenData()
    {
        CloseLoading();
        canClick = true;
        Helper.GoToHomeMenu();
    }

    void ErrorUploadFileResponden()
    {
        CloseLoading();
        SetTextMessage("Gagal Melakukan Login");
        canClick = true;
    }
    public void ShowLoading()
    {
        PageLoading.SetActive(true);
    }
    public void CloseLoading()
    {
        PageLoading.SetActive(false);
    }
    public void SetTextMessage(string _txt = "")
    {
        GameObject msg = Instantiate(txtPrefab, contentParentTxt);
        msg.GetComponent<PemantauanMessage>().SetText(_txt, canvas);
        msg.SetActive(true);
    }
}
