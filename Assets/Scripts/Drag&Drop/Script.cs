using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    bool oneCorrect, twoCorrect, threeCorrect, fourCorrect, fiveCorrect, ran = false;

    Vector3 iniScaleLettreOne, iniScaleLettreTwo, iniScaleLettreThree, iniScaleLettreFour, iniScaleLettreFive, iniScaleLettreSix, iniScaleLettreSeven, iniScaleLettreEight, iniScaleLettreNine, iniScaleLettreTen, iniScaleLettreEleven, iniScaleLettreTwelve;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    public AudioClip reload;
    public AudioClip buttonDrop;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void DragLettreOne()
    {
        lettreOne.transform.position = Input.mousePosition;
    }

    public void DragLettreTwo()
    {
        lettreTwo.transform.position = Input.mousePosition;
    }

    public void DragLettreThree()
    {
        lettreThree.transform.position = Input.mousePosition;
    }

    public void DragLettreFour()
    {
        lettreFour.transform.position = Input.mousePosition;
    }

    public void DragLettreFive()
    {
        lettreFive.transform.position = Input.mousePosition;
    }

    public void DragLettreSix()
    {
        lettreSix.transform.position = Input.mousePosition;
    }

    public void DragLettreSeven()
    {
        lettreSeven.transform.position = Input.mousePosition;
    }

    public void DragLettreEight()
    {
        lettreEight.transform.position = Input.mousePosition;
    }

    public void DragLettreNine()
    {
        lettreNine.transform.position = Input.mousePosition;
    }

    public void DragLettreTen()
    {
        lettreTen.transform.position = Input.mousePosition;
    }

    public void DragLettreEleven()
    {
        lettreEleven.transform.position = Input.mousePosition;
    }

    public void DragLettreTwelve()
    {
        lettreTwelve.transform.position = Input.mousePosition;
    }

    public void DropLettreOne()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreOne.transform.position = lettreOneIni;
        }
        else
        {
            lettreOne.transform.position = lettreTwoIni;
        }
    }

    public void DropLettreTwo()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreTwo.transform.position = lettreTwoIni;
        }
        else
        {
            lettreTwo.transform.position = lettreFourIni;
        }
    }

    public void DropLettreThree()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreThree.transform.position = lettreThreeIni;
        }
        else
        {
            lettreThree.transform.position = lettreOneIni;
        }
    }

    public void DropLettreFour()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreFour.transform.position = lettreFourIni;
        }
        else
        {
            lettreFour.transform.position = lettreThreeIni;
        }
    }

    public void DropLettreFive()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreFive.transform.position = lettreFiveIni;
        }
        else
        {
            lettreFive.transform.position = lettreSixIni;
        }
    }

    public void DropLettreSix()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreSix.transform.position = lettreSixIni;
        }
        else
        {
            lettreSix.transform.position = lettreSevenIni;
        }
    }


    public void DropLettreSeven()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreSeven.transform.position = lettreSevenIni;
        }
        else
        {
            lettreSeven.transform.position = lettreEightIni;
        }
    }

    public void DropLettreEight()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreEight.transform.position = lettreEightIni;
        }
        else
        {
            lettreEight.transform.position = lettreFiveIni;
        }  
    }

    public void DropLettreNine()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreNine.transform.position = lettreNineIni;
        }
        else
        {
            lettreNine.transform.position = lettreTwelveIni;
        }
    }

    public void DropLettreTen()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreTen.transform.position = lettreTenIni;
        }
        else
        {
            lettreTen.transform.position = lettreElevenIni;
        }
    }

    public void DropLettreEleven()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreEleven.transform.position = lettreElevenIni;
        }
        else
        {
            lettreEleven.transform.position = lettreTenIni;
        }
    }

    public void DropLettreTwelve()
    {
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
            source.clip = buttonDrop;
            source.Play();
        }

        else if (ran == false)
        {
            lettreTwelve.transform.position = lettreTwelveIni;
        }
        else
        {
            lettreTwelve.transform.position = lettreNineIni;
        }
    }

    public GameObject feed_benar, feed_salah;
    public void Check()
    {
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

    public void Reload()
    {
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
        // if (ran == false)
        // {
        //     lettreOne.transform.position = lettreTwoIni;
        //     lettreTwo.transform.position = lettreFourIni;
        //     lettreThree.transform.position = lettreOneIni;
        //     lettreFour.transform.position = lettreThreeIni;
        //     lettreFive.transform.position = lettreSixIni;
        //     lettreSix.transform.position = lettreSevenIni;
        //     lettreSeven.transform.position = lettreEightIni;
        //     lettreEight.transform.position = lettreFiveIni;
        //     lettreNine.transform.position = lettreTwelveIni;
        //     lettreTen.transform.position = lettreElevenIni;
        //     lettreEleven.transform.position = lettreTenIni;
        //     lettreTwelve.transform.position = lettreNineIni;
        //
        //     lettreOne.transform.localScale = iniScaleLettreOne;
        //     lettreTwo.transform.localScale = iniScaleLettreTwo;
        //     lettreThree.transform.localScale = iniScaleLettreThree;
        //     lettreFour.transform.localScale = iniScaleLettreFour;
        //     lettreFive.transform.localScale = iniScaleLettreFive;
        //     lettreSix.transform.localScale = iniScaleLettreSix;
        //     lettreSeven.transform.localScale = iniScaleLettreSeven;
        //     lettreEight.transform.localScale = iniScaleLettreEight;
        //     lettreNine.transform.localScale = iniScaleLettreNine;
        //     lettreTen.transform.localScale = iniScaleLettreTen;
        //     lettreEleven.transform.localScale = iniScaleLettreEleven;
        //     lettreTwelve.transform.localScale = iniScaleLettreTwelve;
        //     ran = true;
        // }
        // else
        // {
        //     lettreOne.transform.position = lettreOneIni;
        //     lettreTwo.transform.position = lettreTwoIni;
        //     lettreThree.transform.position = lettreThreeIni;
        //     lettreFour.transform.position = lettreFourIni;
        //     lettreFive.transform.position = lettreFiveIni;
        //     lettreSix.transform.position = lettreSixIni;
        //     lettreSeven.transform.position = lettreSevenIni;
        //     lettreEight.transform.position = lettreEightIni;
        //     lettreNine.transform.position = lettreNineIni;
        //     lettreTen.transform.position = lettreTenIni;
        //     lettreEleven.transform.position = lettreElevenIni;
        //     lettreTwelve.transform.position = lettreTwelveIni;
        //
        //     lettreOne.transform.localScale = iniScaleLettreOne;
        //     lettreTwo.transform.localScale = iniScaleLettreTwo;
        //     lettreThree.transform.localScale = iniScaleLettreThree;
        //     lettreFour.transform.localScale = iniScaleLettreFour;
        //     lettreFive.transform.localScale = iniScaleLettreFive;
        //     lettreSix.transform.localScale = iniScaleLettreSix;
        //     lettreSeven.transform.localScale = iniScaleLettreSeven;
        //     lettreEight.transform.localScale = iniScaleLettreEight;
        //     lettreNine.transform.localScale = iniScaleLettreNine;
        //     lettreTen.transform.localScale = iniScaleLettreTen;
        //     lettreEleven.transform.localScale = iniScaleLettreEleven;
        //     lettreTwelve.transform.localScale = iniScaleLettreTwelve;
        //     ran = false;
        // }

        GameObject[] Drags = GameObject.FindGameObjectsWithTag("Drag");
        foreach (GameObject Drag in Drags)
            Drag.GetComponent<EventTrigger>().enabled = true;
        source.clip = reload;
        source.Play();
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
}
