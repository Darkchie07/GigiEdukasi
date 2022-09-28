using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class PageDebris : MonoBehaviour
{
    [System.Serializable]
    public class DataGigi
    {
        public string namaGigi;
        public bool status;
        public string stringFoto;
        public string pathFoto;

        //UI
        public TextMeshProUGUI txtButtonFoto;
        public Button btnUploadFoto;
        public Button btnAda;
        public Sprite sprData;

        public void Setup()
        {
            foreach (var a in btnAda.GetComponentsInChildren<Transform>())
            {
                if (a == btnAda.transform)
                    continue;
                else
                    a.gameObject.SetActive(false);
            }
            ChangeStatusButtonGambar();

            btnAda.onClick.AddListener(() =>
            {
                if (RespondenData.Instance.currentDataSelected.statusDebris == "1")
                    return;
                foreach (var a in btnAda.GetComponentsInChildren<Transform>())
                {
                    if (a == btnAda.transform)
                        continue;
                    else
                        a.gameObject.SetActive(false);
                }

                status = !status;

                ChangeStatusButtonGambar();
            });

            btnUploadFoto.onClick.AddListener(() =>
            {
                if (!string.IsNullOrEmpty(stringFoto))
                {
                    Instance.PanelImage.SetActive(true);
                    Instance.PanelImage.transform.GetChild(0).GetComponent<Image>().sprite = sprData;
                    PemeliharaanSikatGigiManager.Instance.OrientationToAuto();
                }
                else
                    OpenGallery();
            });
        }

        public void OpenGallery()
        {
            NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
            {
                Debug.Log("Image path: " + path);
                if (path != null)
                {
                    // Create Texture from selected image
                    Texture2D texture = NativeGallery.LoadImageAtPath(path, -1);
                    if (texture == null)
                    {
                        print("Couldn't load texture from " + path);
                        return;
                    }

                    ImagePicked(texture, path);
                }
            });
        }

        public void ImagePicked(Texture2D _tex, string _path = "")
        {
            print($"Creating image from {_path}");
            pathFoto = _path;
            stringFoto = Helper.TextureToBase64(_tex);
            CreateSprite(_tex);
        }

        private void CreateSprite(Texture2D _tex)
        {
            //create sprite
            txtButtonFoto.text = "Lihat Foto";
            Sprite spriteFoto = Helper.TextureToSprite(_tex);
            sprData = spriteFoto;
        }

        public void ChangeStatusButtonGambar()
        {
            if (status)
            {
                btnAda.transform.Find("Ada").gameObject.SetActive(true);
            }
            else
            {
                btnAda.transform.Find("TidakAda").gameObject.SetActive(true);
            }
        }
    }

    public List<DataGigi> listDataGigiDebris = new List<DataGigi>();
    public Button btnSimpan;
    public GameObject PanelImage;
    public static PageDebris Instance;
    private void Awake()
    {
        Instance = this;

        LoadData();
        foreach (var a in listDataGigiDebris)
            a.Setup();

    }

    public void LoadData()
    {
        if (!RespondenData.Instance)
            return;

        if (RespondenData.Instance.currentDataSelected.statusDebris == "1")
        {
            //tampilkan data
            for (int i = 0; i < RespondenData.Instance.dataDebris.debris.listDebris.Count; i++)
            {
                listDataGigiDebris[i].namaGigi = RespondenData.Instance.dataDebris.debris.listDebris[i].namaGigi;
                listDataGigiDebris[i].status = RespondenData.Instance.dataDebris.debris.listDebris[i].status;
                listDataGigiDebris[i].stringFoto = RespondenData.Instance.dataDebris.debris.listDebris[i].stringFoto;
                listDataGigiDebris[i].pathFoto = RespondenData.Instance.dataDebris.debris.listDebris[i].pathFoto;

                //create sprite
                Texture2D tex = Helper.Base64ToTexture(listDataGigiDebris[i].stringFoto);
                listDataGigiDebris[i].ImagePicked(tex);
            }
            btnSimpan.gameObject.SetActive(false);
        }

    }

    public void SaveData()
    {
        //cek dulu datanya
        foreach (var dataGigi in listDataGigiDebris)
        {
            if (string.IsNullOrEmpty(dataGigi.stringFoto))
            {
                PemeliharaanSikatGigiManager.Instance.SetTextMessage("Data foto belum lengkap, mohon lengkapi terlebih dahulu");
                return;
            }
        }

        RespondenData.Instance.dataDebris = new RespondenData.DebrisFile();
        RespondenData.Instance.dataDebris.debris.listDebris = new List<RespondenData.DebrisData>();

        foreach (var a in listDataGigiDebris) //create data debris
        {
            RespondenData.DebrisData d = new RespondenData.DebrisData();
            d.namaGigi = a.namaGigi;
            d.status = a.status;
            d.stringFoto = a.stringFoto;
            d.pathFoto = a.pathFoto;
            RespondenData.Instance.dataDebris.debris.listDebris.Add(d);
        }
        UploadDataToDrive();
    }

    public void UploadDataToDrive()
    {
        //API FORM
        string _grahamKananAtas = (listDataGigiDebris[0].status) ? "Ada" : "Tidak ada";
        string _depanAtas = (listDataGigiDebris[1].status) ? "Ada" : "Tidak ada";
        string _grahamKiriAtas = (listDataGigiDebris[2].status) ? "Ada" : "Tidak ada";
        string _grahamKiriBawah = (listDataGigiDebris[3].status) ? "Ada" : "Tidak ada";
        string _depanBawah = (listDataGigiDebris[4].status) ? "Ada" : "Tidak ada";
        string _grahamKananBawah = (listDataGigiDebris[5].status) ? "Ada" : "Tidak ada";

        PemeliharaanSikatGigiManager.Instance.ShowLoading();

        StartCoroutine(Helper.CoroutineUploadFormGigiResponden(
            _grahamKananAtas, _depanAtas, _grahamKiriAtas, _grahamKiriBawah, _depanBawah, _grahamKananBawah
            , SuccessUploadForm, ErrorUploadForm
           ));
    }

    void SuccessUploadForm()
    {
        //upload gambar        
        StartCoroutine(UploadDataImagesDebris(
            _onDoneAction, 0
            ));
    }

    #region SEND IMAGE TO DRIVE
    public IEnumerator UploadDataImagesDebris(Action _onDoneAction, int indx)
    {
        var drive = new GoogleDrive();
        drive.ClientID = Helper.Client_id;
        drive.ClientSecret = Helper.Client_secret;
        drive.AccessToken = Helper.CachedAccessToken;
        drive.RefreshToken = Helper.CachedRefreshToken;
        drive.UserAccount = Helper.UserAccount;

        Dictionary<string, object>[] a = new Dictionary<string, object>[]
     {
             new Dictionary<string, object>()
             {
                 {"id", Helper.ParentFolderImageFormGigiResponden }
             }
     };
        var file = new GoogleDrive.File(new Dictionary<string, object>
         {
           {"id",Helper.ParentFolderImageFormGigiResponden },
             { "mimeType","application/vnd.google-apps.folder"},
             {"parents", a }
         });

        var content = File.ReadAllBytes(RespondenData.Instance.dataDebris.debris.listDebris[indx].pathFoto);
        if (content == null)
        {
            PemeliharaanSikatGigiManager.Instance.CloseLoading();
            yield break;
        }

        string _fileName = $"{Helper.NamaDanSekolah()}-{RespondenData.Instance.dataDebris.debris.listDebris[indx].namaGigi}";

        yield return StartCoroutine(drive.UploadFile(_fileName, "image/png", file, content));

        indx++;
        if (indx > 5)
            _onDoneAction.Invoke();
        else
            StartCoroutine(UploadDataImagesDebris(_onDoneAction, indx));
    }
    #endregion

    private void _onDoneAction()
    {
        PemeliharaanSikatGigiManager.Instance.CloseLoading();
        string json = JsonUtility.ToJson(RespondenData.Instance.dataDebris);
        PemeliharaanSikatGigiManager.Instance.SetTextMessage("Berhasil mengupload data dan foto");
        RespondenData.Instance.SaveDebris(json);
        btnSimpan.gameObject.SetActive(false);
    }

    void ErrorUploadForm(UnityWebRequest www)
    {
        PemeliharaanSikatGigiManager.Instance.CloseLoading();
        print("Gagal upload form");
        PemeliharaanSikatGigiManager.Instance.SetTextMessage("Gagal upload form");
        print(www.error);
    }
}
