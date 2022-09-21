using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script : MonoBehaviour
{
    public GameObject lettreOne, lettreTwo, lettreThree, lettreFour, lettreFive, lettreSix, lettreSeven, lettreEight, BoxOne, BoxTwo, BoxThree, BoxFour, BoxFive;

    Vector3 lettreOneIni, lettreTwoIni, lettreThreeIni, lettreFourIni, lettreFiveIni, lettreSixIni, lettreSevenIni, lettreEightIni;

    string str = "";
    public string word;

    public GameObject questionToHide, questionToShow;

    bool oneCorrect, twoCorrect, threeCorrect, fourCorrect, fiveCorrect = false;

    Vector3 iniScaleLettreOne, iniScaleLettreTwo, iniScaleLettreThree, iniScaleLettreFour, iniScaleLettreFive, iniScaleLettreSix, iniScaleLettreSeven, iniScaleLettreEight;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    public AudioClip reload;
    public AudioClip buttonDrop;

    // Start is called before the first frame update
    void Start()
    {
        lettreOneIni = lettreOne.transform.position;
        lettreTwoIni = lettreTwo.transform.position;
        lettreThreeIni = lettreThree.transform.position;
        lettreFourIni = lettreFour.transform.position;
        lettreFiveIni = lettreFive.transform.position;
        lettreSixIni = lettreSix.transform.position;
        lettreSevenIni = lettreSeven.transform.position;
        lettreEightIni = lettreEight.transform.position;

        iniScaleLettreOne = lettreOne.transform.localScale;
        iniScaleLettreTwo = lettreTwo.transform.localScale;
        iniScaleLettreThree = lettreThree.transform.localScale;
        iniScaleLettreFour = lettreFour.transform.localScale;
        iniScaleLettreFive = lettreFive.transform.localScale;
        iniScaleLettreSix = lettreSix.transform.localScale;
        iniScaleLettreSeven = lettreSeven.transform.localScale;
        iniScaleLettreEight = lettreEight.transform.localScale;
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

    public void DropLettreOne()
    {
        float Distance = Vector3.Distance(lettreOne.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreOne.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreOne.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreOne.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreOne.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreOne.transform.localScale = BoxOne.transform.localScale;
            lettreOne.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play(); 
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreOne.transform.localScale = BoxTwo.transform.localScale;
            lettreOne.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreOne.transform.localScale = BoxThree.transform.localScale;
            lettreOne.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreOne.transform.localScale = BoxFour.transform.localScale;
            lettreOne.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreOne.transform.localScale = BoxFive.transform.localScale;
            lettreOne.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreOne.name;
            lettreOne.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreOne.transform.position = lettreOneIni;
        }
    }

    public void DropLettreTwo()
    {
        float Distance = Vector3.Distance(lettreTwo.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreTwo.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreTwo.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreTwo.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreTwo.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreTwo.transform.localScale = BoxOne.transform.localScale;
            lettreTwo.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreTwo.transform.localScale = BoxTwo.transform.localScale;
            lettreTwo.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreTwo.transform.localScale = BoxThree.transform.localScale;
            lettreTwo.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreTwo.transform.localScale = BoxFour.transform.localScale;
            lettreTwo.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreTwo.transform.localScale = BoxFive.transform.localScale;
            lettreTwo.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreTwo.name;
            lettreTwo.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreTwo.transform.position = lettreTwoIni;
        }
    }

    public void DropLettreThree()
    {
        float Distance = Vector3.Distance(lettreThree.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreThree.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreThree.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreThree.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreThree.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreThree.transform.localScale = BoxOne.transform.localScale;
            lettreThree.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreThree.transform.localScale = BoxTwo.transform.localScale;
            lettreThree.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreThree.transform.localScale = BoxThree.transform.localScale;
            lettreThree.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreThree.transform.localScale = BoxFour.transform.localScale;
            lettreThree.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreThree.transform.localScale = BoxFive.transform.localScale;
            lettreThree.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreThree.name;
            lettreThree.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreThree.transform.position = lettreThreeIni;
        }
    }

    public void DropLettreFour()
    {
        float Distance = Vector3.Distance(lettreFour.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreFour.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreFour.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreFour.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreFour.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreFour.transform.localScale = BoxOne.transform.localScale;
            lettreFour.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreFour.transform.localScale = BoxTwo.transform.localScale;
            lettreFour.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreFour.transform.localScale = BoxThree.transform.localScale;
            lettreFour.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreFour.transform.localScale = BoxFour.transform.localScale;
            lettreFour.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreFour.transform.localScale = BoxFive.transform.localScale;
            lettreFour.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreFour.name;
            lettreFour.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreFour.transform.position = lettreFourIni;
        }
    }

    public void DropLettreFive()
    {
        float Distance = Vector3.Distance(lettreFive.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreFive.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreFive.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreFive.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreFive.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreFive.transform.localScale = BoxOne.transform.localScale;
            lettreFive.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreFive.transform.localScale = BoxTwo.transform.localScale;
            lettreFive.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreFive.transform.localScale = BoxThree.transform.localScale;
            lettreFive.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreFive.transform.localScale = BoxFour.transform.localScale;
            lettreFive.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreFive.transform.localScale = BoxFive.transform.localScale;
            lettreFive.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreFive.name;
            lettreFive.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreFive.transform.position = lettreFiveIni;
        }
    }

    public void DropLettreSix()
    {
        float Distance = Vector3.Distance(lettreSix.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreSix.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreSix.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreSix.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreSix.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreSix.transform.localScale = BoxOne.transform.localScale;
            lettreSix.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreSix.transform.localScale = BoxTwo.transform.localScale;
            lettreSix.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreSix.transform.localScale = BoxThree.transform.localScale;
            lettreSix.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreSix.transform.localScale = BoxFour.transform.localScale;
            lettreSix.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreSix.transform.localScale = BoxFive.transform.localScale;
            lettreSix.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreSix.name;
            lettreSix.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreSix.transform.position = lettreSixIni;
        }
    }

    public void DropLettreSeven()
    {
        float Distance = Vector3.Distance(lettreSeven.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreSeven.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreSeven.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreSeven.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreSeven.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreSeven.transform.localScale = BoxOne.transform.localScale;
            lettreSeven.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreSeven.transform.localScale = BoxTwo.transform.localScale;
            lettreSeven.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreSeven.transform.localScale = BoxThree.transform.localScale;
            lettreSeven.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreSeven.transform.localScale = BoxFour.transform.localScale;
            lettreSeven.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreSeven.transform.localScale = BoxFive.transform.localScale;
            lettreSeven.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreSeven.name;
            lettreSeven.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreSeven.transform.position = lettreSevenIni;
        }
    }

    public void DropLettreEight()
    {
        float Distance = Vector3.Distance(lettreEight.transform.position, BoxOne.transform.position);
        float Distance2 = Vector3.Distance(lettreEight.transform.position, BoxTwo.transform.position);
        float Distance3 = Vector3.Distance(lettreEight.transform.position, BoxThree.transform.position);
        float Distance4 = Vector3.Distance(lettreEight.transform.position, BoxFour.transform.position);
        float Distance5 = Vector3.Distance(lettreEight.transform.position, BoxFive.transform.position);

        if (Distance < 50 && oneCorrect == false)
        {
            lettreEight.transform.localScale = BoxOne.transform.localScale;
            lettreEight.transform.position = BoxOne.transform.position;
            oneCorrect = true;
            BoxOne.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && twoCorrect == false)
        {
            lettreEight.transform.localScale = BoxTwo.transform.localScale;
            lettreEight.transform.position = BoxTwo.transform.position;
            twoCorrect = true;
            BoxTwo.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && threeCorrect == false)
        {
            lettreEight.transform.localScale = BoxThree.transform.localScale;
            lettreEight.transform.position = BoxThree.transform.position;
            threeCorrect = true;
            BoxThree.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fourCorrect == false)
        {
            lettreEight.transform.localScale = BoxFour.transform.localScale;
            lettreEight.transform.position = BoxFour.transform.position;
            fourCorrect = true;
            BoxFour.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else if (Distance < 50 && fiveCorrect == false)
        {
            lettreEight.transform.localScale = BoxFive.transform.localScale;
            lettreEight.transform.position = BoxFive.transform.position;
            fiveCorrect = true;
            BoxFive.name = lettreEight.name;
            lettreEight.GetComponent<EventTrigger>().enabled = false;
            source.clip = buttonDrop;
            source.Play();
        }

        else
        {
            lettreEight.transform.position = lettreEightIni;
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
            DragScore.scoreValue += 10;
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

        lettreOne.transform.position = lettreOneIni;
        lettreTwo.transform.position = lettreTwoIni;
        lettreThree.transform.position = lettreThreeIni;
        lettreFour.transform.position = lettreFourIni;
        lettreFive.transform.position = lettreFiveIni;
        lettreSix.transform.position = lettreSixIni;
        lettreSeven.transform.position = lettreSevenIni;
        lettreEight.transform.position = lettreEightIni;

        lettreOne.transform.localScale = iniScaleLettreOne;
        lettreTwo.transform.localScale = iniScaleLettreTwo;
        lettreThree.transform.localScale = iniScaleLettreThree;
        lettreFour.transform.localScale = iniScaleLettreFour;
        lettreFive.transform.localScale = iniScaleLettreFive;
        lettreSix.transform.localScale = iniScaleLettreSix;
        lettreSeven.transform.localScale = iniScaleLettreSeven;
        lettreEight.transform.localScale = iniScaleLettreEight;

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
}
