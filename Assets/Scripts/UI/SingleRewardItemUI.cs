using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleRewardItemUI : MonoBehaviour, IRewardItemUI
{
    [SerializeField] private Image icon;
    [SerializeField] private GameObject label;
    [SerializeField] private TextMeshProUGUI quantityLabel;
    
    private Button _button;
    private SingleRewardItem _data;

    public void Initialise(RewardItem item)
    {
        _data = (SingleRewardItem)item;
        icon.sprite = _data.icon;

        if (_data.quantity <= 0)
        {
            label.SetActive(false);
        }
        else
        {
            quantityLabel.text = $"x{_data.quantity}";
        }
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Debug.Log($"Selected: {_data.rewardType} x{_data.quantity}");
    }
}