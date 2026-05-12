using UnityEngine;

public enum RewardType
{
    Lives,
    Coins,
    Cosmetic
}

[CreateAssetMenu(fileName = "NewSingleReward", menuName = "Rewards/Single Reward")]
public class SingleRewardItem : RewardItem
{
    public RewardType rewardType;
    public int quantity;
    public Sprite icon;
}