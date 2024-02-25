using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    [SerializeField]
    string[] sentences;
    [SerializeField]
    string characterName;
    int index;
    bool isOndial, canDial;


    HUDManager manager => HUDManager.instance;

    public static PNJ instance;

    public QuestSO quest;

    public Sprite IconQuest1, IconQuest2;
    public SpriteRenderer questSr;

    public GameObject choice1, choice2;

    public Transform Spawnpoint;
    public GameObject Prefab;




    private void Start ()
    {
        choice1 = manager.choice1;
        choice2 = manager.choice2;
        if (quest !=null && quest.statut == QuestSO.Statut.none)
        {
            questSr.sprite = IconQuest1;

        }
        else if(quest == null)
        {
            questSr.sprite = null;
        }
    }

    private void Update()
    {



        if(questSr != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount < quest.amountToFind)
        {
            questSr.sprite = IconQuest2;
            questSr.color = Color.red;

        }
        else if (quest != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount == quest.amountToFind)
        {
            questSr.sprite = IconQuest2;
            questSr.color = Color.yellow;
        }
        else if (quest != null && quest.statut == QuestSO.Statut.complete)
        {
            questSr.sprite = null;
        }
      
    



        if (Input.GetKeyDown(KeyCode.E) && canDial)
        {
           
            if(quest != null && quest.statut == QuestSO.Statut.none)
            {
                StartDialogue(quest.sentences);
                Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
                

            }
            else if(quest != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount < quest.amountToFind)
            {
                StartDialogue(quest.InprogressSentence);
                


            }
            else if(quest != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount == quest.amountToFind)
            {
                StartDialogue(quest.completeSentence);
                quest.statut = QuestSO.Statut.complete;
                

            }
            else if(quest != null && quest.statut == QuestSO.Statut.complete)
            {
                StartDialogue(quest.afterQuestSentence);
                Destroy(Prefab.gameObject);
            }
            else if(quest == null)
            {
                StartDialogue(sentences);
            }


        }
    }    

    public void StartDialogue(string[] sentence)
    {
        manager.dialogueHolder.SetActive(true);
        PlayerController.instance.canMove = false;
        isOndial = true;
        TypingText(sentence);
        manager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        manager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { NextLine(sentence); });

    }


    void TypingText(string[] sentence)
    {
    manager.nameDisplay.text = "";
    manager.textDisplay.text = "";

    manager.nameDisplay.text = characterName;
    manager.textDisplay.text = sentence[index];

    if (manager.textDisplay.text == sentence[index])
    {
        manager.continueButton.SetActive(true);
    }

    if (isOndial && index == sentence.Length - 1)
    {
        if (quest != null && quest.statut == QuestSO.Statut.none)
        {
            choice1.SetActive(true);
            choice2.SetActive(true);

            choice1.GetComponent<Button>().onClick.AddListener(delegate { Accepte(); });
            choice2.GetComponent<Button>().onClick.AddListener(delegate { Decline(); });

        }
    }


    }

public void NextLine(string[] sentence)
{
    manager.continueButton.SetActive(false);

    if(isOndial && index < sentence.Length - 1)
    {
        index++;
        manager.textDisplay.text = "";
        TypingText(sentence);
    }
    else if(isOndial && index == sentence.Length - 1)
    {
        isOndial = false;
        index = 0;
        manager.textDisplay.text = "";
        manager.nameDisplay.text = "";
        manager.dialogueHolder.SetActive(false);

        if(quest != null && quest.statut == QuestSO.Statut.none)
        {
            choice1.SetActive(true);
            choice2.SetActive(true);

            choice1.GetComponent<Button>().onClick.AddListener(delegate { Accepte(); });
            choice2.GetComponent<Button>().onClick.AddListener(delegate { Decline(); });
        }

        PlayerController.instance.canMove = true;
    
    }
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.tag == "Player")
    {
        canDial = true;
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if(collision.tag == "Player")
    {
        canDial = false;
    }
}

public void Accepte()
{
    quest.statut = QuestSO.Statut.accepter;
    isOndial = false;
    index = 0;
    manager.textDisplay.text = "";
    manager.nameDisplay.text = "";
    manager.dialogueHolder.SetActive(false);
    choice1.SetActive(false);
    choice2.SetActive(false);
    PlayerController.instance.canMove = true;

}

public void Decline()
{
    quest.statut = QuestSO.Statut.none;
    isOndial = false;
    index = 0;
    manager.textDisplay.text = "";
    manager.nameDisplay.text = "";
    manager.dialogueHolder.SetActive(false);
    choice1.SetActive(false);
    choice2.SetActive(false);
    PlayerController.instance.canMove = true;

}


}
