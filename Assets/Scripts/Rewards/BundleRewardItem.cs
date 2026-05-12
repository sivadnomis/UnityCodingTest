using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBundleReward", menuName = "Rewards/Bundle Reward")]
public class BundleRewardItem : RewardItem
{
    [Range(1, 4)]
    public List<SingleRewardItem> items = new List<SingleRewardItem>();
}