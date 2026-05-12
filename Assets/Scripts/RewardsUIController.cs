using UnityEngine;
using System.Collections.Generic;

public class RewardsUIController : MonoBehaviour
{
    [SerializeField] private RewardsService rewardsService;
    [SerializeField] private Transform scrollContent;
    [SerializeField] private GameObject singleItemPrefab;

    private void Start()
    {
        PopulateGallery();
    }

    private void PopulateGallery()
    {
        List<RewardItem> catalogue = rewardsService.GetCatalogue();

        foreach (RewardItem rewardItem in catalogue)
        {
            GameObject instance = Instantiate(singleItemPrefab, scrollContent);
            SingleRewardItemUI itemUI = instance.GetComponent<SingleRewardItemUI>();
            
            if (itemUI != null)
                itemUI.Initialise(rewardItem);
        }
    }
}