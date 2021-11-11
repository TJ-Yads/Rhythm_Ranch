using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour//controller used to prevent animals from respawning if you enter the area after already claiming the pet
{
    public bool[] pets;
    public GameObject blackOut,Quacker,QuackerPrefab,Froger,FrogerPrefab,Horse,HorsePrefab;
    public bool duckTamed=false,DuckSpawned=false,frogTamed=false,FrogSpawned, outHub=false,returning=false,horseTamed=false,horseSpawned, BuffoTamed, SharkTamed, MonkeyTamed, SnakeTamed, CatTamed, DogTamed;
    public Animator aniblack,aniQuack;
    public AndrewController pc;
    public bool[] activeAbility;
    public Transform QuackerSpawn,QP1,QP2,QP3,QP4,FP1,FP2,FP3,FP4,HP1,HP2,HP3,HP4;
    public int sceneNumber, DoorNumber;
    public int score,petsNum;
    public AudioSource gameAud;
    public AudioClip pondTheme,hubTheme,canyonTheme,jungleTheme,beachTheme;

    //holds all the animation scripts from other animals
    public DuckAnimation DA;
    public FrogAnimation FA;
    public HorseAnimations HA;
    // Start is called before the first frame update
    void Start()
    {
        DoorNumber = 1;
        sceneNumber = 0;
        //gameAud.clip = pondTheme;
    }

    // Update is called once per frame
    void Update()//sets the animals to inactive if you enter a scene where you already found the pet for that area
    {
        if (sceneNumber == 1)
        {
            if (GameObject.FindGameObjectWithTag("Duck")!= null && duckTamed == true)
            {
                GameObject.FindGameObjectWithTag("Duck").SetActive(false);
            }
            if (GameObject.FindGameObjectWithTag("Frog") != null && frogTamed == true)
            {
                GameObject.FindGameObjectWithTag("Frog").SetActive(false);
            }
        }
        if (sceneNumber == 2)
        {
            if (GameObject.FindGameObjectWithTag("Cat") != null && CatTamed == true)
            {
                GameObject.FindGameObjectWithTag("Cat").SetActive(false);
            }
            if (GameObject.FindGameObjectWithTag("Snake") != null && SnakeTamed == true)
            {
                GameObject.FindGameObjectWithTag("Snake").SetActive(false);
            }
            if (GameObject.FindGameObjectWithTag("Monkey") != null && MonkeyTamed == true)
            {
                GameObject.FindGameObjectWithTag("Monkey").SetActive(false);
            }
        }
        if (sceneNumber == 3)
        {
            if (GameObject.FindGameObjectWithTag("Horse") != null && horseTamed == true)
            {
                GameObject.FindGameObjectWithTag("Horse").SetActive(false);
            }
            if (GameObject.FindGameObjectWithTag("Buffo") != null && BuffoTamed == true)
            {
                GameObject.FindGameObjectWithTag("Buffo").SetActive(false);
            }
            if (GameObject.FindGameObjectWithTag("Shark") != null && SharkTamed == true)
            {
                GameObject.FindGameObjectWithTag("Shark").SetActive(false);
            }
        }

    }
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    void Awake()//makes sure there is only 1 controller when in new scenes
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
        //gameAud.Loop = true;
        gameAud.Play();
    }

    public IEnumerator BlackOut()//fade to black on transitons
    {
        blackOut = GameObject.FindGameObjectWithTag("BlackOut");
        aniblack = blackOut.GetComponent<Animator>();
        aniblack.SetTrigger("PlayBlackout");
        yield return new WaitForSeconds(1.0f);
    }
}
