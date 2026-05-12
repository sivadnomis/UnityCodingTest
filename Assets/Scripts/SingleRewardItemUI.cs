using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleRewardItemUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityLabel;
    
    private Button _button;
    private SingleRewardItem _data;

    public void Initialise(RewardItem item)
    {
        _data = (SingleRewardItem)item;
        icon.sprite = _data.icon;
        quantityLabel.text = _data.quantity > 0 ? $"x{_data.quantity}" : "";
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Debug.Log($"Selected: {_data.rewardType} x{_data.quantity}");
    }
}