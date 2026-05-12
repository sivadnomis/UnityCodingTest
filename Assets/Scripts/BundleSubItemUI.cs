using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BundleSubItemUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityLabel;

    public void Initialise(SingleRewardItem item)
    {
        icon.sprite = item.icon;
        quantityLabel.text = item.quantity > 0 ? $"x{item.quantity}" : "";
    }
}