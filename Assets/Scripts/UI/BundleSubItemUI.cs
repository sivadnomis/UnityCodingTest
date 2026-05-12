using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BundleSubItemUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private GameObject label;
    [SerializeField] private TextMeshProUGUI quantityLabel;

    public void Initialise(SingleRewardItem item)
    {
        icon.sprite = item.icon;
        
        if (item.quantity <= 0)
        {
            label.SetActive(false);
        }
        else
        {
            quantityLabel.text = $"x{item.quantity}";
        }
    }
}