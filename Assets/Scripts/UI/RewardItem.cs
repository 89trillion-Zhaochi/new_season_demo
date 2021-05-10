using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 处理单条item的UI更新，处理点击事件
    /// </summary>
    public class RewardItem: MonoBehaviour
    {
        [SerializeField] private List<int> rewardCoins;
        [SerializeField] private List<int> trophyNums;
        [SerializeField] private Text coinText;
        [SerializeField] private Text trophyText;
        [SerializeField] private Image rankImage;
        [SerializeField] private List<Sprite> rankImageSprite;
        [SerializeField] private Button coinBtn;
        
        private int _coinValue;
        
        
        /// <summary>
        /// 根据传入的count值去重置item的值，包括等级，数值，奖励，能否领取的状态
        /// </summary>
        /// <param name="count"></param>
        public void SetValue(int count)
        {
            coinText.text = rewardCoins[count].ToString();
            trophyText.text = trophyNums[count].ToString();
            _coinValue = rewardCoins[count];
            if (trophyNums[count] <= UserInfo.Instance.Trophy)
            {
                rankImage.sprite = rankImageSprite[0];
                coinBtn.enabled = true;
            }
            else
            {
                rankImage.sprite = rankImageSprite[1];
                coinBtn.enabled = false;
            }
        }
        
        /// <summary>
        /// 点击领取金币按钮后，修改可点击状态，修改sprite
        /// </summary>

        public void CoinBtnOnClicked()
        {
            UserInfo.Instance.Coin += _coinValue;
            rankImage.sprite = rankImageSprite[1];
            coinBtn.enabled = false;
            
        }

    }
}