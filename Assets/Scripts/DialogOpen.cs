using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private string[] messages;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "crackpipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        messages = new string[] { "Oh no, my film blew away! Can you find it?", "Oh no, my balloons flew away! Can you catch them?", "Can you please find my life preserver? I cannot afford to drown next time I visit the sea!", "Can you please find my bull's eye? I wish to practice some archery.", "I lost my crackpipe! Please find it quickly, I NEED to smoke crack! asrwriedowferjeojieiofjeoirf", "Oh no, I've lost the key to my house, can you help?", "Oh no, my fish tank rolled away! Can you find it?", "My birdhouse blew away! The birds need to eat, so can you please find it?", "I lost my airhorn! Can you please locate it?", "My magic hat was blown away, can you please find it?" };
        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    public void searchDialog()
    {
        dialog = messages[clue] ?? ("Hi! Can you help me find my " + collectibles[clue] + "?");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my " + collectibles[clue] + "! Hooray!";
            end = true;
        }
        else
        {
            dialog = "No, that's not my " + collectibles[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
