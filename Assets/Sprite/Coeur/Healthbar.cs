using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currenHealth / 10;
    }

    private void Update()
    {
        currenthealBar.fillAmount = playerHealth.currenHealth / 10;
    }
}
