using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Script : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> _Jawaban;
    private List<GameObject> _JawabanAcak = new List<GameObject>();
    public Transform parent;
    public GameObject lettreOne, lettreTwo, lettreThree, lettreFour, lettreFive, lettreSix, lettreSeven, lettreEight, lettreNine, lettreTen, lettreEleven, lettreTwelve, BoxOne, BoxTwo, BoxThree, BoxFour, BoxFive;

    Vector3 lettreOneIni, lettreTwoIni, lettreThreeIni, lettreFourIni, lettreFiveIni, lettreSixIni, lettreSevenIni, lettreEightIni, lettreNineIni, lettreTenIni, lettreElevenIni, lettreTwelveIni;

    string str = "";
    public string word;

    public GameObject questionToHide, questionToShow;

    bool oneCorrect, twoCorrect, threeCorrect, fourCorrect, fiveCorrect = false;

    Vector3 iniScaleLettreOne, iniScaleLettreTwo, iniScaleLettreThree, iniScaleLettreFour, iniScaleLettreFive, iniScaleLettreSix, iniScaleLettreSeven, iniScaleLettreEight, iniScaleLettreNine, iniScaleLettreTen, iniScaleLettreEleven, iniScaleLettreTwelve;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    public AudioClip reload;
    public AudioClip buttonDrop;
    public VideoPlayer video;
    public VideoClip VideoClip;

    PauseGameScript _pauseScript;

    // Start is called before the first frame update
    void Start()
    {
        _pauseScript = FindObjectOfType<PauseGameScript>();

        RandomJawaban();
        lettreOneIni = lettreOne.transform.position;
        lettreTwoIni = lettreTwo.transform.position;
        lettreThreeIni = lettreThree.transform.position;
        lettreFourIni = lettreFour.transform.position;
        lettreFiveIni = lettreFive.transform.position;
        lettreSixIni = lettreSix.transform.position;
        lettreSevenIni = lettreSeven.transform.position;
        lettreEightIni = lettreEight.transform.position;
        lettreNineIni = lettreNine.transform.position;
        lettreTenIni = lettreTen.transform.position;
        lettreElevenIni = lettreEleven.transform.position;
        lettreTwelveIni = lettreTwelve.transform.position;

        iniScaleLettreOne = lettreOne.transform.localScale;
        iniScaleLettreTwo = lettreTwo.transform.localScale;
        iniScaleLettreThree = lettreThree.transform.localScale;
        iniScaleLettreFour = lettreFour.transform.localScale;
        iniScaleLettreFive = lettreFive.transform.localScale;
        iniScaleLettreSix = lettreSix.transform.localScale;
        iniScaleLettreSeven = lettreSeven.transform.localScale;
        iniScaleLettreEight = lettreEight.transform.localScale;
        iniScaleLettreNine = lettreNine.transform.localScale;
        iniScaleLettreTen = lettreTen.transform.localScale;
        iniScaleLettreEleven = lettreEleven.transform.localScale;
        iniScaleLettreTwelve = lettreTwelve.transform.localScale;
        PlayVideo(VideoClip);
    }

    public void DragLettreOne()
    {
        if (_pauseScript.pause)
            return;
        lettreOne.transform.position = Input.mousePosition;
        lettreOne.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreTwo()
    {
        if (_pauseScript.pause)
            return;
        lettreTwo.transform.position = Input.mousePosition;
        lettreTwo.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreThree()
    {
        if (_pauseScript.pause)
            return;
        lettreThree.transform.position = Input.mousePosition;
        lettreThree.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreFour()
    {
        if (_pauseScript.pause)
            return;
        lettreFour.transform.position = Input.mousePosition;
        lettreFour.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreFive()
    {
        if (_pauseScript.pause)
            return;
        lettreFive.transform.position = Input.mousePosition;
        lettreFive.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreSix()
    {
        if (_pauseScript.pause)
            return;
        lettreSix.transform.position = Input.mousePosition;
        lettreSix.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreSeven()
    {
        if (_pauseScript.pause)
            return;
        lettreSeven.transform.position = Input.mousePosition;
        lettreSeven.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreEight()
    {
        if (_pauseScript.pause)
            return;
        lettreEight.transform.position = Input.mousePosition;
        lettreEight.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreNine()
    {
        if (_pauseScript.pause)
            return;
        lettreNine.transform.position = Input.mousePosition;
        lettreNine.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreTen()
    {
        if (_pauseScript.pause)
            return;
        lettreTen.transform.position = Input.mousePosition;
        lettreTen.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreEleven()
    {
        if (_pauseScript.pause)
            return;
        lettreEleven.transform.position = Input.mousePosition;
        lettreEleven.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DragLettreTwelve()
    {
        if (_pauseScript.pause)
            return;
        lettreTwelve.transform.position = Input.mousePosition;
        lettreTwelve.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DropLettreOne()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreOne.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreOne.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreOne.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreOne.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreOne.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreOne.transform.localScale = BoxOne.transform.localScale;
            lettreOne.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreOne.transform.localScale = BoxTwo.transform.localScale;
            lettreOne.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreOne.transform.localScale = BoxThree.transform.localScale;
            lettreOne.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreOne.transform.localScale = BoxFour.transform.localScale;
            lettreOne.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreOne.transform.localScale = BoxFive.transform.localScale;
            lettreOne.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreOne.transform.position = lettreOneIni;
            lettreOne.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreTwo()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreTwo.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreTwo.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreTwo.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreTwo.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreTwo.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreTwo.transform.localScale = BoxOne.transform.localScale;
            lettreTwo.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreTwo.transform.localScale = BoxTwo.transform.localScale;
            lettreTwo.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreTwo.transform.localScale = BoxThree.transform.localScale;
            lettreTwo.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreTwo.transform.localScale = BoxFour.transform.localScale;
            lettreTwo.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreTwo.transform.localScale = BoxFive.transform.localScale;
            lettreTwo.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreTwo.transform.position = lettreTwoIni;
            lettreTwo.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreThree()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreThree.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreThree.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreThree.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreThree.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreThree.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreThree.transform.localScale = BoxOne.transform.localScale;
            lettreThree.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreThree.transform.localScale = BoxTwo.transform.localScale;
            lettreThree.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreThree.transform.localScale = BoxThree.transform.localScale;
            lettreThree.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreThree.transform.localScale = BoxFour.transform.localScale;
            lettreThree.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreThree.transform.localScale = BoxFive.transform.localScale;
            lettreThree.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreThree.transform.position = lettreThreeIni;
            lettreThree.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreFour()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreFour.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreFour.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreFour.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreFour.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreFour.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreFour.transform.localScale = BoxOne.transform.localScale;
            lettreFour.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreFour.transform.localScale = BoxTwo.transform.localScale;
            lettreFour.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreFour.transform.localScale = BoxThree.transform.localScale;
            lettreFour.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreFour.transform.localScale = BoxFour.transform.localScale;
            lettreFour.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreFour.transform.localScale = BoxFive.transform.localScale;
            lettreFour.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreFour.transform.position = lettreFourIni;
            lettreFour.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreFive()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreFive.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreFive.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreFive.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreFive.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreFive.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreFive.transform.localScale = BoxOne.transform.localScale;
            lettreFive.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreFive.transform.localScale = BoxTwo.transform.localScale;
            lettreFive.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreFive.transform.localScale = BoxThree.transform.localScale;
            lettreFive.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreFive.transform.localScale = BoxFour.transform.localScale;
            lettreFive.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreFive.transform.localScale = BoxFive.transform.localScale;
            lettreFive.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreFive.transform.position = lettreFiveIni;
            lettreFive.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreSix()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreSix.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreSix.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreSix.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreSix.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreSix.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreSix.transform.localScale = BoxOne.transform.localScale;
            lettreSix.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreSix.transform.localScale = BoxTwo.transform.localScale;
            lettreSix.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreSix.transform.localScale = BoxThree.transform.localScale;
            lettreSix.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreSix.transform.localScale = BoxFour.transform.localScale;
            lettreSix.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreSix.transform.localScale = BoxFive.transform.localScale;
            lettreSix.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreSix.transform.position = lettreSixIni;
            lettreSix.GetComponent<Canvas>().sortingOrder = 1;
        }
    }


    public void DropLettreSeven()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreSeven.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreSeven.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreSeven.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreSeven.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreSeven.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreSeven.transform.localScale = BoxOne.transform.localScale;
            lettreSeven.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreSeven.transform.localScale = BoxTwo.transform.localScale;
            lettreSeven.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreSeven.transform.localScale = BoxThree.transform.localScale;
            lettreSeven.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreSeven.transform.localScale = BoxFour.transform.localScale;
            lettreSeven.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreSeven.transform.localScale = BoxFive.transform.localScale;
            lettreSeven.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreSeven.transform.position = lettreSevenIni;
            lettreSeven.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreEight()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreEight.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreEight.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreEight.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreEight.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreEight.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreEight.transform.localScale = BoxOne.transform.localScale;
            lettreEight.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreEight.transform.localScale = BoxTwo.transform.localScale;
            lettreEight.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreEight.transform.localScale = BoxThree.transform.localScale;
            lettreEight.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreEight.transform.localScale = BoxFour.transform.localScale;
            lettreEight.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreEight.transform.localScale = BoxFive.transform.localScale;
            lettreEight.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreEight.transform.position = lettreEightIni;
            lettreEight.GetComponent<Canvas>().sortingOrder = 1;
        }  
    }

    public void DropLettreNine()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreNine.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreNine.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreNine.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreNine.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreNine.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreNine.transform.localScale = BoxOne.transform.localScale;
            lettreNine.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreNine.name;
            lettreNine.GetComponent<EventTrigger>().enabled = false;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreNine.transform.localScale = BoxTwo.transform.localScale;
            lettreNine.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreNine.name;
            lettreNine.GetComponent<EventTrigger>().enabled = false;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreNine.transform.localScale = BoxThree.transform.localScale;
            lettreNine.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreNine.name;
            lettreNine.GetComponent<EventTrigger>().enabled = false;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreNine.transform.localScale = BoxFour.transform.localScale;
            lettreNine.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreNine.name;
            lettreNine.GetComponent<EventTrigger>().enabled = false;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreNine.transform.localScale = BoxFive.transform.localScale;
            lettreNine.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreNine.name;
            lettreNine.GetComponent<EventTrigger>().enabled = false;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreNine.transform.position = lettreNineIni;
            lettreNine.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreTen()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreTen.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreTen.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreTen.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreTen.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreTen.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreTen.transform.localScale = BoxOne.transform.localScale;
            lettreTen.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreTen.name;
            lettreTen.GetComponent<EventTrigger>().enabled = false;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreTen.transform.localScale = BoxTwo.transform.localScale;
            lettreTen.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreTen.name;
            lettreTen.GetComponent<EventTrigger>().enabled = false;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreTen.transform.localScale = BoxThree.transform.localScale;
            lettreTen.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreTen.name;
            lettreTen.GetComponent<EventTrigger>().enabled = false;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreTen.transform.localScale = BoxFour.transform.localScale;
            lettreTen.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreTen.name;
            lettreTen.GetComponent<EventTrigger>().enabled = false;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreTen.transform.localScale = BoxFive.transform.localScale;
            lettreTen.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreTen.name;
            lettreTen.GetComponent<EventTrigger>().enabled = false;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreTen.transform.position = lettreTenIni;
            lettreTen.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreEleven()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreEleven.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreEleven.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreEleven.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreEleven.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreEleven.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreEleven.transform.localScale = BoxOne.transform.localScale;
            lettreEleven.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreEleven.name;
            lettreEleven.GetComponent<EventTrigger>().enabled = false;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreEleven.transform.localScale = BoxTwo.transform.localScale;
            lettreEleven.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreEleven.name;
            lettreEleven.GetComponent<EventTrigger>().enabled = false;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreEleven.transform.localScale = BoxThree.transform.localScale;
            lettreEleven.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreEleven.name;
            lettreEleven.GetComponent<EventTrigger>().enabled = false;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreEleven.transform.localScale = BoxFour.transform.localScale;
            lettreEleven.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreEleven.name;
            lettreEleven.GetComponent<EventTrigger>().enabled = false;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreEleven.transform.localScale = BoxFive.transform.localScale;
            lettreEleven.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreEleven.name;
            lettreEleven.GetComponent<EventTrigger>().enabled = false;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreEleven.transform.position = lettreElevenIni;
            lettreEleven.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public void DropLettreTwelve()
    {
        if (_pauseScript.pause)
            return;
        float Distance = Vector3.Distance(lettreTwelve.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreTwelve.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreTwelve.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreTwelve.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreTwelve.transform.position, BoxFive.transform.position);

        if (Distance < 100 && oneCorrect == false)
        {
            lettreTwelve.transform.localScale = BoxOne.transform.localScale;
            lettreTwelve.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreTwelve.name;
            lettreTwelve.GetComponent<EventTrigger>().enabled = false;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance2 < 100 && twoCorrect == false)
        {
            lettreTwelve.transform.localScale = BoxTwo.transform.localScale;
            lettreTwelve.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreTwelve.name;
            lettreTwelve.GetComponent<EventTrigger>().enabled = false;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance3 < 100 && threeCorrect == false)
        {
            lettreTwelve.transform.localScale = BoxThree.transform.localScale;
            lettreTwelve.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreTwelve.name;
            lettreTwelve.GetComponent<EventTrigger>().enabled = false;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance4 < 100 && fourCorrect == false)
        {
            lettreTwelve.transform.localScale = BoxFour.transform.localScale;
            lettreTwelve.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreTwelve.name;
            lettreTwelve.GetComponent<EventTrigger>().enabled = false;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance5 < 100 && fiveCorrect == false)
        {
            lettreTwelve.transform.localScale = BoxFive.transform.localScale;
            lettreTwelve.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreTwelve.name;
            lettreTwelve.GetComponent<EventTrigger>().enabled = false;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreTwelve.transform.position = lettreTwelveIni;
            lettreTwelve.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    public GameObject feed_benar, feed_salah;
    public void Check()
    {
        if (_pauseScript.pause)
            return;
        str = BoxOne.name + BoxTwo.name + BoxThree.name + BoxFour.name + BoxFive.name;

        if (word == str)
        {
            feed_benar.SetActive(false);
            feed_benar.SetActive(true);
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
            StartCoroutine(LoadNextPanel());
        }
        else
        {
            source.clip = incorrect;
            source.Play();
            feed_salah.SetActive(false);
            feed_salah.SetActive(true);
            StartCoroutine(ReloadPanel());
        }
    }
    
    public void CheckLast()
    {
        if (_pauseScript.pause)
            return;
        str = BoxOne.name + BoxTwo.name + BoxThree.name + BoxFour.name + BoxFive.name;

        if (word == str)
        {
            feed_benar.SetActive(false);
            feed_benar.SetActive(true);
            source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();
            StartCoroutine(NextScene());
        }
        else
        {
            source.clip = incorrect;
            source.Play();
            feed_salah.SetActive(false);
            feed_salah.SetActive(true);
            StartCoroutine(ReloadPanel());
        }
    }

    public void Reload()
    {
        if (_pauseScript.pause)
            return;
        str = "";

        oneCorrect = false;
        twoCorrect = false;
        threeCorrect = false;
        fourCorrect = false;
        fiveCorrect = false;

        BoxOne.name = "1";
        BoxTwo.name = "2";
        BoxThree.name = "3";
        BoxFour.name = "4";
        BoxFive.name = "5";

        for (int i = 0; i < _JawabanAcak.Count; i++)
        {
            _JawabanAcak[i].transform.position = spawnPoints[i].transform.position;
        }

        source.clip = reload;
        source.Play();

        GameObject[] Drags = GameObject.FindGameObjectsWithTag("Drag");
        foreach (GameObject Drag in Drags)
        { 
            Drag.GetComponent<EventTrigger>().enabled = true;
            Drag.GetComponent<Canvas>().sortingOrder = 1;
        }
    }

    IEnumerator LoadNextPanel()
    {
        yield return new WaitForSeconds(3f);
        questionToHide.SetActive(false);
        questionToShow.SetActive(true);
    }

    IEnumerator ReloadPanel()
    {
        yield return new WaitForSeconds(2f);
        Reload();
    }
    
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/ToothBrushGame/Level 1");
    }

    public void RandomJawaban()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int randSpawn = Random.Range(0, _Jawaban.Count);
            _Jawaban[randSpawn].transform.position = spawnPoints[i].transform.position;
            _JawabanAcak.Add(_Jawaban[randSpawn]);
            _Jawaban.RemoveAt(randSpawn);
        }
    }

    public void PlayVideo(VideoClip videoClip)
    {
        video.clip = videoClip;
    }
}
