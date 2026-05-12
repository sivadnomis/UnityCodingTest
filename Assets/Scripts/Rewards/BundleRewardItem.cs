using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBundleReward", menuName = "Rewards/Bundle Reward")]
public class BundleRewardItem : RewardItem
{
    public List<SingleRewardItem> items = new List<SingleRewardItem>();
}