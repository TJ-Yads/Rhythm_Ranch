using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviormentBlockers : MonoBehaviour//blockers in game the prevent the area from being entered until the player unlocks it with certains pets
{
    private AndrewController playercontroller;
    private GameController gamecontroller;
    public bool WaterBlock, TreeBlock, StoneBlock;
    public Text BlockedText;
    public GameObject BlockedTextVis;
    public GameObject Transition;
    public Transform Transform;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playercontroller = playerControllerObject.GetComponent<AndrewController>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamecontroller = gameControllerObject.GetComponent<GameController>();
    }
    private void OnTriggerStay2D(Collider2D other)//for each blocker if the player can enter then the text lets them know otherwise the player is told where to go to find the pet required for entry
    {
        BlockedTextVis.SetActive(true);
        if (WaterBlock == true)
        {
            if (gamecontroller.activeAbility[0] == true)
            {
                BlockedText.text = "I can traverse this Waterfall now. (Hold E to enter the Forest)";
                if (Input.GetButton("Interact"))
                {
                    BlockedTextVis.SetActive(false);
                    Instantiate(Transition, Transform);
                }
            }
            else
                BlockedText.text = "This Waterfall seems to steep. Perhaps one of those Pond creatures could help.";
        }
        if (TreeBlock == true)
        {
            if (gamecontroller.activeAbility[1] == true)
            {
                BlockedText.text = "This tree can now be cut down. (Hold E to remove it.)";
                if (Input.GetButton("Interact"))
                {
                    BlockedTextVis.SetActive(false);
                    Destroy(gameObject);
                }
            }
            else
                BlockedText.text = "This tree is blocking the path, perhaps one of those Jungle creatures could help.";
        }
        if (StoneBlock == true)
        {
            if (gamecontroller.activeAbility[2] == true)
            {
                BlockedText.text = "This Boulder can now be destroyed. (Hold E to remove it.)";
                if (Input.GetButton("Interact"))
                {
                    BlockedTextVis.SetActive(false);
                    Destroy(gameObject);
                }
            }
            else
                BlockedText.text = "This Boulder is to large, perhaps one of those Canyon creatures could help";
        }
    }
    private void OnTriggerExit2D(Collider2D other)//if the player walks away then the text is hidden
    {
        BlockedTextVis.SetActive(false);
    }
}
