using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{

    public List<QuestSO> allQuest;

    public GameObject panelQuest, descriptionPanel, parent, quest;

    public static QuestManager instance;

    bool firstQuest = true;

    private void Awake()
    {
        if(instance != null && instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    
    }


    void Start()
    {
        for (int i = 0; i<allQuest.Count; i++)
        {
            allQuest[i].id = i;
        }
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            panelQuest.SetActive(true);

            if(parent.transform.childCount > 0)
            {
                foreach (Transform child in parent.transform)
                {
                    Destroy(child.gameObject);
            
                }
            }
            for (int i = 0; i < allQuest.Count; i++)
            {
                if(i <= allQuest.Count -1)
                {
                    if(allQuest[i].statut == QuestSO.Statut.accepter)
                    {
                        GameObject slot = Instantiate(quest, parent.transform.position, transform.rotation);
                        slot.transform.SetParent(parent.transform);

                        TextMeshProUGUI title = slot.transform.Find("TitleQuest").GetComponent<TextMeshProUGUI>();
                        title.text = allQuest[i].title;

                        TextMeshProUGUI statut = slot.transform.Find("Statut").GetComponent<TextMeshProUGUI>();
                        title.text = "" + allQuest[i].statut;

                        slot.GetComponent<QuestID>().questId = allQuest[i].id;

                        if(firstQuest)
                        {
                            
                            TextMeshProUGUI titleDes = descriptionPanel.transform.Find("TitleQuest").GetComponent<TextMeshProUGUI>();
                            titleDes.text = allQuest[i].title;

                            TextMeshProUGUI description = descriptionPanel.transform.Find("DescriptionQuest").GetComponent<TextMeshProUGUI>();
                            description.text = allQuest[i].description;

                            TextMeshProUGUI objectif = descriptionPanel.transform.Find("Ojectif").GetComponent<TextMeshProUGUI>();
                            objectif.text = "objectif :" + allQuest[i].actualAmount + "/" + allQuest[i].amountToFind;

                            TextMeshProUGUI recompense = descriptionPanel.transform.Find("récompense").GetComponent<TextMeshProUGUI>();
                            recompense.text = " Recompense :" +allQuest[i].goldToGive;

                            firstQuest=false;
                        }
                    }
                }
            }
        }
    }



    public void ChargeQuest(int i)
    {
        TextMeshProUGUI titleDes = descriptionPanel.transform.Find("TitleQuest").GetComponent<TextMeshProUGUI>();
        titleDes.text = allQuest[i].title;

        TextMeshProUGUI description = descriptionPanel.transform.Find("DescriptionQuest").GetComponent<TextMeshProUGUI>();
        description.text = allQuest[i].description;

        TextMeshProUGUI objectif = descriptionPanel.transform.Find("Ojectif").GetComponent<TextMeshProUGUI>();
        objectif.text = "objectif :" + allQuest[i].actualAmount + "/" + allQuest[i].amountToFind;

        TextMeshProUGUI recompense = descriptionPanel.transform.Find("récompense").GetComponent<TextMeshProUGUI>();
        recompense.text = " Recompense :" +allQuest[i].goldToGive;
    
    }
}

