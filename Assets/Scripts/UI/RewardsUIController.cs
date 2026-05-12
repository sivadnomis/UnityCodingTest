using UnityEngine;
using System.Collections.Generic;

public class RewardsUIController : MonoBehaviour
{
    [SerializeField] private RewardsService rewardsService;
    [SerializeField] private Transform scrollContent;
    [SerializeField] private GameObject singleItemPrefab;
    [SerializeField] private GameObject bundleItemPrefab;

    private void Start()
    {
        PopulateGallery();
    }

    private void PopulateGallery()
    {
        List<RewardItem> catalogue = rewardsService.GetCatalogue();

        foreach (RewardItem rewardItem in catalogue)
        {
            GameObject prefab = rewardItem is BundleRewardItem ? bundleItemPrefab : singleItemPrefab;
            GameObject instance = Instantiate(prefab, scrollContent);
            IRewardItemUI itemUI = instance.GetComponent<IRewardItemUI>();
            
            if (itemUI != null)
                itemUI.Initialise(rewardItem);
        }
    }
}