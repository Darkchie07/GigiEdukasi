using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class RespondenData : MonoBehaviour
{
    #region CLASS DATA RESPONDEN
    [System.Serializable]
    public class DataResponden
    {
        public List<Responden> listResponden = new List<Responden>();
    }

    [System.Serializable]
    public class Responden
    {
        public string nama;
        public string umur;
        public string sekolah;
        public string jenisKelamin;
        public List<GambarGigi> daftarGambargigi = new List<GambarGigi>(7);
        public string status; // 0 = still in, 1 = already logout

        public Responden()
        {
            int i = 0;
            while (i < 9)
            {
                GambarGigi newGigi = new GambarGigi();
                daftarGambargigi.Add(newGigi);
                i++;
            }
            status = "0";
        }

        public void SetDataAwal(string _nama, string _umur, string _sekolah, string _jenisKelamin)
        {
            nama = _nama;
            umur = _umur;
            sekolah = _sekolah;
            jenisKelamin = _jenisKelamin;
        }

        public void SaveGambarGigi(GambarGigi _targetSave,string _strImage)
        {
            _targetSave.listImageGigi.Add(_strImage);
            Instance.SaveData();
        }
    }

    [System.Serializable]
    public class GambarGigi
    {
        public List<string> listImageGigi = new List<string>();
    }

    [System.Serializable]
    public class StringImageGigi
    {
        public string image;
    }
    #endregion

    [Header("DATA RESPONDEN")]
    public DataResponden dataResponden;

    [Header("CURRENT DATA SELECTED")]
    public Responden currentDataSelected;

    public static RespondenData Instance;

    public bool doneLoadData = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(this.gameObject);

        CheckingDataFirst();
        doneLoadData = true;
    }

    void CheckingDataFirst()
    {
        LoadFile();

        if (dataResponden.listResponden.Count == 0) // jika kosong
        {
            print("data belum ada");
            currentDataSelected = new Responden();
        }
        else
        {
            //cek data terakhirnya
            if (dataResponden.listResponden[dataResponden.listResponden.Count - 1].status == "1") // sudah logout
            {
                currentDataSelected = new Responden();
            }
            else
            {
                currentDataSelected = dataResponden.listResponden[dataResponden.listResponden.Count - 1];
            }
        }
    }


    /// <summary>
    /// fungsi untuk convert data responden ke string json
    /// </summary>
    /// <returns></returns>
    public string ConvertDataToJson()
    {
        string json = JsonUtility.ToJson(dataResponden);
        return json;
    }


    /// <summary>
    /// fungsi untuk melakukan save file
    /// </summary>
    public void SaveData()
    {
        string _path = Application.persistentDataPath + "/savefile.json";
        print(_path);
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, ConvertDataToJson());
            print("created");
        }
        else
        {
            File.WriteAllText(_path, ConvertDataToJson());
            print("updated");
        }
    }

    public void InsertNewDataResponden()
    {
        dataResponden.listResponden.Add(currentDataSelected);
        SaveData();
    }


    /// <summary>
    /// Fungsi untuk melakukan load file
    /// </summary>
    [ContextMenu("LOAD DATA")]
    public void LoadFile()
    {
        string _path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(_path))
        {
            string _data = File.ReadAllText(_path);

            dataResponden = JsonUtility.FromJson<DataResponden>(_data);
        }
        else
        {
            dataResponden = new DataResponden();
        }
    }
}
