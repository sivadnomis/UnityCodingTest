using UnityEngine;
using System.Collections.Generic;

public class RewardsService : MonoBehaviour
{
    [SerializeField] 
    private List<RewardItem> catalogue = new List<RewardItem>();

    public List<RewardItem> GetCatalogue()
    {
        return catalogue;
    }
}