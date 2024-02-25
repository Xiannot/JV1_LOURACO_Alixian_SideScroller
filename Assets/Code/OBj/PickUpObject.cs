using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(var item in QuestManager.instance.allQuest)
        {
            if(item.statut == QuestSO.Statut.accepter && item.objectTofind == gameObject.name)
            {
                item.actualAmount++;
            }

            Destroy(gameObject);
        }
    }
            
    
}
    
