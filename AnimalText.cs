using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalText : MonoBehaviour//text and images that will show when the player goes near a sign in the hub
{
    private GameController gamecontroller;
    public bool Duck, Frog, Buffo, Horse, Cat, Shark, Snake, Monkey, Dog;
    public Text Bio, Name;
    public GameObject NameText, BioText, book;
    public GameObject[] AnimalVis, Blackout;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamecontroller = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D other)//when the player is near a sign the text and an image will appear, text shown depends on the sign bool and if the pet was brought to the hub or not
    {
        if (other.tag == "Player")
        {
            book.SetActive(true);
            if (Duck == true)
            {
                if (gamecontroller.duckTamed == true)
                {
                    Name.text = "Shraby";
                    Bio.text = "Shraby can be found splashing and tapping its feet around in ponds and puddles. Its favorite food is brightly colored flowers.";
                    AnimalVis[0].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[0].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Frog == true)
            {
                if (gamecontroller.frogTamed == true)
                {
                    Name.text = "Ribblo";
                    Bio.text = "Ribblo is proud of its large belly. If it breathes in enough air, it can sing for hours in a deep voice.";
                    AnimalVis[1].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[1].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Cat == true)
            {
                if (gamecontroller.CatTamed == true)
                {
                    Name.text = "Scrattle";
                    Bio.text = "Scrattle can be found in trees scratching the bark. It loves to squeal and shriek in the nighttime.";
                    AnimalVis[2].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[2].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Horse == true)
            {
                if (gamecontroller.horseTamed == true)
                {
                    Name.text = "Doney";
                    Bio.text = "Doney prefers to stay alone and acts cold towards others. It only sings when alone, so few people have heard it.";
                    AnimalVis[3].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[3].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Buffo == true)
            {
                if (gamecontroller.BuffoTamed == true)
                {
                    Name.text = "Buffo";
                    Bio.text = "Buffo looks mean and aggressive but is actually a slow moving herbivore. It whistles through its large nostrils";
                    AnimalVis[4].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[4].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Monkey == true)
            {
                if (gamecontroller.MonkeyTamed == true)
                {
                    Name.text = "Berkey";
                    Bio.text = "Berkey cracks open its favorite fruit and nuts with its sharp claws. It hums while it eats all day.";
                    AnimalVis[5].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[5].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Snake == true)
            {
                if (gamecontroller.SnakeTamed == true)
                {
                    Name.text = "Snoko";
                    Bio.text = "Snoko burrows in tunnels under the jungle floor. It attracts prey with the lovely sound of its rattle.";
                    AnimalVis[6].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[6].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Shark == true)
            {
                if (gamecontroller.SharkTamed == true)
                {
                    Name.text = "Rubark";
                    Bio.text = "Rubark is a nervous land shark with no teeth. It can dive into dirt and mud as if it were water, and make the earth rumble from below.";
                    AnimalVis[7].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[7].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
            if (Dog == true)
            {
                if (gamecontroller.DogTamed == true)
                {
                    Name.text = "Boby";
                    Bio.text = "Boby is the biggest beast in the land. It causes huge waves as it splashes around the shore. Its bark can be heard from miles away.";
                    AnimalVis[8].SetActive(true);
                }
                else
                {
                    Bio.text = "???";
                    Name.text = "???";
                    Blackout[8].SetActive(true);
                }
                NameText.SetActive(true);
                BioText.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)//when the player moves away from the sign the text and image is hidden
    {
        book.SetActive(false);
        NameText.SetActive(false);
        BioText.SetActive(false);
        AnimalVis[0].SetActive(false);
        AnimalVis[1].SetActive(false);
        AnimalVis[2].SetActive(false);
        AnimalVis[3].SetActive(false);
        AnimalVis[4].SetActive(false);
        AnimalVis[5].SetActive(false);
        AnimalVis[6].SetActive(false);
        AnimalVis[7].SetActive(false);
        AnimalVis[8].SetActive(false);
        Blackout[0].SetActive(false);
        Blackout[1].SetActive(false);
        Blackout[2].SetActive(false);
        Blackout[3].SetActive(false);
        Blackout[4].SetActive(false);
        Blackout[5].SetActive(false);
        Blackout[6].SetActive(false);
        Blackout[7].SetActive(false);
        Blackout[8].SetActive(false);
    }
}
