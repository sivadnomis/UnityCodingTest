using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BundleRewardItemUI : MonoBehaviour, IRewardItemUI
{
    [SerializeField] private List<BundleSubItemUI> subItemSlots;

    private Button _button;
    private BundleRewardItem _data;
    private bool _selected = false;

    public void Initialise(RewardItem item)
    {
        _data = (BundleRewardItem)item;

        for (int i = 0; i < subItemSlots.Count; i++)
        {
            bool active = i < _data.items.Count;
            subItemSlots[i].gameObject.SetActive(active);
            if (active)
                subItemSlots[i].Initialise(_data.items[i]);
        }

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Debug.Log($"Selected bundle: {_data.name}");
    }
}