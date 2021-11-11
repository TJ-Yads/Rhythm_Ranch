using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubController : MonoBehaviour//allows each animal to wander in the hub area after being found
{
    public GameObject blackOut, Quacker, QuackerPrefab, Froger, FrogerPrefab,Dog,DogPrefab, Horse, HorsePrefab,Cat,CatPrefab,Buffo,BuffoPrefab,Shark,SharkPrefab,Monkey,MonkeyPrefab,Snake,SnakePrefab,junglePath,canyonPath,beachPath;
    public Transform QuackerSpawn, QP1, QP2, QP3, QP4, FP1, FP2, FP3, FP4, HP1, HP2, HP3, HP4,CP1,CP2,CP3,BP1,BP2,BP3,SP1,SP2,SP3,MP1,MP2,MP3,SNP1,SNP2,SNP3,DP1;
    private GameController gamecontroller;
    public int escNum;
    // Start is called before the first frame update
    void Start()
    {
        QuackerSpawn = GameObject.FindGameObjectWithTag("QP1").transform;
        QP1 = GameObject.FindGameObjectWithTag("QP2").transform;
        QP2 = GameObject.FindGameObjectWithTag("QP3").transform;
        QP3 = GameObject.FindGameObjectWithTag("QP4").transform;
        QP4 = GameObject.FindGameObjectWithTag("QP5").transform;
        FP1 = GameObject.FindGameObjectWithTag("FP1").transform;
        FP2 = GameObject.FindGameObjectWithTag("FP2").transform;
        FP3 = GameObject.FindGameObjectWithTag("FP3").transform;
        FP4 = GameObject.FindGameObjectWithTag("FP4").transform;
        HP1 = GameObject.FindGameObjectWithTag("HP1").transform;
        HP2 = GameObject.FindGameObjectWithTag("HP2").transform;
        HP3 = GameObject.FindGameObjectWithTag("HP3").transform;
        HP4 = GameObject.FindGameObjectWithTag("HP4").transform;
       // CP1 = GameObject.FindGameObjectWithTag("CP1").transform;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamecontroller = gameControllerObject.GetComponent<GameController>();
        AnimalSpawner();

    }

    public DuckAnimation DA;
    public FrogAnimation FA;
    public HorseAnimations HA;
    public CatAnimation CA;
    public BuffoAnimation BA;
    public SharkAnimation SA;
    public MonkeyAnimation MA;
    public SnakeAnimation SNA;
    public DogScript DS;
    // Update is called once per frame
    void Update()//checks if the player is pausing the game along with the ability to enter diffrent areas based on pets found 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escNum++;
        }
        if (escNum >= 2)
        {
            gamecontroller.gameAud.Pause();
            SceneManager.LoadScene(0);
        }
        if (gamecontroller.duckTamed==true && gamecontroller.frogTamed == true)
        {
            canyonPath.SetActive(true);
        }
        if (gamecontroller.SharkTamed == true && gamecontroller.BuffoTamed == true && gamecontroller.horseTamed == true)
        {
            junglePath.SetActive(true);
        }
        if (gamecontroller.SnakeTamed == true && gamecontroller.CatTamed == true && gamecontroller.MonkeyTamed == true)
        {
            beachPath.SetActive(true);
        }
    }
    public void AnimalSpawner()//for each animal found the method will spawn them in and start a coroutine to allow the animal to move
    {
        if (gamecontroller.duckTamed == true)
        {
            Quacker = Instantiate(QuackerPrefab, QuackerSpawn);
            DA = GameObject.FindGameObjectWithTag("Duck").GetComponent<DuckAnimation>();
            StartCoroutine(QuackerPath());
        }
        if (gamecontroller.frogTamed == true)
        {
            Froger = Instantiate(FrogerPrefab, FP1);
            FA = GameObject.FindGameObjectWithTag("Frog").GetComponent<FrogAnimation>();
            StartCoroutine(FrogerPath());
        }
        if (gamecontroller.horseTamed == true)
        {
            Horse = Instantiate(HorsePrefab, HP1);
            HA = GameObject.FindGameObjectWithTag("Horse").GetComponent<HorseAnimations>();
            StartCoroutine(HorsePath());
        }
        if (gamecontroller.CatTamed == true)
        {
            Cat = Instantiate(CatPrefab, CP1);
            CA = Cat.GetComponent<CatAnimation>();
            StartCoroutine(CatPath());

        }
        if (gamecontroller.BuffoTamed == true)
        {
            Buffo = Instantiate(BuffoPrefab, BP1);
            BA = Buffo.GetComponent<BuffoAnimation>();
            StartCoroutine(BuffoPath());
        }
        if (gamecontroller.SharkTamed == true)
        {
            Shark = Instantiate(SharkPrefab, SP1);
            SA = Shark.GetComponent<SharkAnimation>();
            StartCoroutine(SharkPath());
        }
        if (gamecontroller.MonkeyTamed == true)
        {
            Monkey = Instantiate(MonkeyPrefab, MP1);
            MA = Monkey.GetComponent<MonkeyAnimation>();
            StartCoroutine(MonkeyPath());
        }
        if (gamecontroller.SnakeTamed == true)
        {
            Snake = Instantiate(SnakePrefab, SNP1);
            SNA = Snake.GetComponent<SnakeAnimation>();
            StartCoroutine(SnakePath());
        }
        if (gamecontroller.DogTamed == true)
        {
            Dog = Instantiate(DogPrefab, DP1);
            DS = Dog.GetComponent<DogScript>();
            StartCoroutine(DogPath());
        }
    }
    public IEnumerator QuackerPath()//one of the coroutines to let the animal wander in the area
    {
        Debug.Log("Quack");

        iTween.MoveTo(Quacker, iTween.Hash("position", QP1, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        DA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Quacker, iTween.Hash("position", QP2, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        DA.anim.SetBool("MovingLeft", false);
        yield return new WaitForSeconds(.2f);
        DA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(2.8f);
        iTween.MoveTo(Quacker, iTween.Hash("position", QP3, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        DA.anim.SetBool("MovingForward", false);
        yield return new WaitForSeconds(.2f);
        DA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(2.8f);
        iTween.MoveTo(Quacker, iTween.Hash("position", QP4, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        DA.anim.SetBool("MovingRight", false);
        yield return new WaitForSeconds(.2f);
        DA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(2.8f);
        iTween.MoveTo(Quacker, iTween.Hash("position", QuackerSpawn, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        DA.anim.SetBool("MovingBackwards", false);
        DA.anim.SetBool("MovingLeft", true);
        //yield return new WaitForSeconds(3.0f);
        StartCoroutine(QuackerPath());
    }
    public IEnumerator FrogerPath()
    {
        Debug.Log("Ribbit");

        iTween.MoveTo(Froger, iTween.Hash("position", FP2, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        FA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Froger, iTween.Hash("position", FP3, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Froger, iTween.Hash("position", FP4, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(2.8f);
        FA.anim.SetBool("MovingForward", false);
        yield return new WaitForSeconds(.2f);
        FA.anim.SetBool("MovingBackwards", true);
        iTween.MoveTo(Froger, iTween.Hash("position", FP3, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Froger, iTween.Hash("position", FP2, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Froger, iTween.Hash("position", FP1, "Time", 3f, "easetype", iTween.EaseType.easeInOutSine));
        FA.anim.SetBool("MovingBackwards", false);
        FA.anim.SetBool("MovingForward", true);
        StartCoroutine(FrogerPath());
    }
    public IEnumerator HorsePath()
    {
        Debug.Log("Whinney");

        iTween.MoveTo(Horse, iTween.Hash("position", HP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        HA.anim.SetBool("MovingForward", false);
        HA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Horse, iTween.Hash("position", HP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Horse, iTween.Hash("position", HP4, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        HA.anim.SetBool("MovingBackwards", false);
        HA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(2.8f);
        yield return new WaitForSeconds(.2f);
        iTween.MoveTo(Horse, iTween.Hash("position", HP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        HA.anim.SetBool("MovingRight", false);
        HA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Horse, iTween.Hash("position", HP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        HA.anim.SetBool("MovingLeft", false);
        HA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Horse, iTween.Hash("position", HP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        StartCoroutine(HorsePath());
    }
    public IEnumerator CatPath()
    {
        Debug.Log("Meow");

        iTween.MoveTo(Cat, iTween.Hash("position", CP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        CA.anim.SetBool("MovingRight", false);
        CA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Cat, iTween.Hash("position", CP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        CA.anim.SetBool("MovingLeft", false);
        CA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Cat, iTween.Hash("position", CP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        CA.anim.SetBool("MovingForward", false);
        CA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Cat, iTween.Hash("position", CP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        CA.anim.SetBool("MovingBackwards", false);
        CA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(CatPath());
    }
    public IEnumerator BuffoPath()
    {
        Debug.Log("Buffo");

        iTween.MoveTo(Buffo, iTween.Hash("position", BP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        BA.anim.SetBool("MovingRight", false);
        BA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Buffo, iTween.Hash("position", BP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        BA.anim.SetBool("MovingLeft", false);
        BA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Buffo, iTween.Hash("position", BP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        BA.anim.SetBool("MovingBackwards", false);
        BA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Buffo, iTween.Hash("position", BP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        BA.anim.SetBool("MovingForward", false);
        BA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(BuffoPath());
    }
    public IEnumerator SharkPath()
    {
        Debug.Log("Chomp");

        iTween.MoveTo(Shark, iTween.Hash("position", SP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SA.anim.SetBool("MovingForward", false);
        SA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Shark, iTween.Hash("position", SP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SA.anim.SetBool("MovingBackwards", false);
        SA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Shark, iTween.Hash("position", SP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SA.anim.SetBool("MovingRight", false);
        SA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Shark, iTween.Hash("position", SP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SA.anim.SetBool("MovingLeft", false);
        SA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(SharkPath());
    }
    public IEnumerator MonkeyPath()
    {
        Debug.Log("oo aa");

        iTween.MoveTo(Monkey, iTween.Hash("position", MP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        MA.anim.SetBool("MovingForward", false);
        MA.anim.SetBool("MovingBackwards", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Monkey, iTween.Hash("position", MP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        MA.anim.SetBool("MovingBackwards", false);
        MA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Monkey, iTween.Hash("position", MP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        MA.anim.SetBool("MovingRight", false);
        MA.anim.SetBool("MovingLeft", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Monkey, iTween.Hash("position", MP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        MA.anim.SetBool("MovingLeft", false);
        MA.anim.SetBool("MovingForward", true);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(MonkeyPath());
    }
    public IEnumerator SnakePath()
    {
        Debug.Log("ssSSSss");

        iTween.MoveTo(Snake, iTween.Hash("position", SNP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SNA.anim.SetBool("MovingLeft", false);
        SNA.anim.SetBool("MovingRight", true);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Snake, iTween.Hash("position", SNP3, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Snake, iTween.Hash("position", SNP2, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        SNA.anim.SetBool("MovingLeft", true);
        SNA.anim.SetBool("MovingRight", false);
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(Snake, iTween.Hash("position", SNP1, "Time", 2f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(SnakePath());
    }
    public IEnumerator DogPath()
    {
        yield return null;
    }
}
