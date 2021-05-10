using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 主要是处理全局的user数据更新，以及主页上的按钮点击事件
    /// </summary>
    public class Manage : MonoBehaviour
    {

        [SerializeField] private Text trophyText;
        [SerializeField] private Text coinText;
        [SerializeField] private Image rankImage;
        [SerializeField] private GameObject rewardPrefab;
        [SerializeField] private Transform rewardParent;
        
        [SerializeField] private List<Sprite> rankSprites;

        private int _lastCoin;
        

        /// <summary>
        /// 修改数据，增加奖杯数
        /// </summary>
        private void Start()
        {
            UserInfo.Instance.Coin = 0;
            UserInfo.Instance.Trophy = 3500;
            ChangeTrophyText();
            ChangeCoinText();
            ChangeRankImage();
            _lastCoin = UserInfo.Instance.Coin;
        }

        /// <summary>
        /// 增加奖杯数
        /// </summary>
        private void TrophyAdd()
        {
            if (UserInfo.Instance.Trophy <= 5900)
            {
                UserInfo.Instance.Trophy += 100;
            }
            
        }

        /// <summary>
        /// 刷新新赛季时对奖杯的数据进行操作
        /// </summary>
        private static void NewSeason()
        {
            if (UserInfo.Instance.Trophy>4000)
            {
                UserInfo.Instance.Trophy = (UserInfo.Instance.Trophy - 4000) / 2 + 4000;
            }
        }

        /// <summary>
        /// 领取金币奖励时对金币的数据进行修改
        /// </summary>
        /// <param name="value"></param>

        public void CoinAdd(int value)
        {
            UserInfo.Instance.Coin += value;
        }
    
    
        /// <summary>
        /// 修改奖杯数的UI显示效果
        /// </summary>
        private void ChangeTrophyText()
        {
            trophyText.text = UserInfo.Instance.Trophy.ToString();
        }

        /// <summary>
        /// 修改金币数的UI显示效果
        /// </summary>
        private void ChangeCoinText()
        {
            coinText.text = UserInfo.Instance.Coin.ToString();
        }

        
        /// <summary>
        /// 修改rank的图片显示
        /// </summary>
        private void ChangeRankImage()
        {
            int i = UserInfo.Instance.Trophy / 1000 + 1;
            rankImage.sprite = rankSprites[i];
        }

        /// <summary>
        /// 点击增加奖杯按钮
        /// </summary>
        public void AddBtnOnClicked()
        {
            TrophyAdd();
            ChangeTrophyText();
            ChangeRankImage();
        }
    
        /// <summary>
        /// 点击新赛季的按钮
        /// </summary>
        public void NewSeasonBtnOnClicked()
        {
            NewSeason();
            ChangeTrophyText();
            ChangeRankImage();
        }

        /// <summary>
        /// 修改金币数，由于金币数修改的数量每次都不一定，将增加金币数字的功能移到下一层的item中
        /// </summary>
        public void ChangeButtonOnClick()
        {
            //CoinAdd();
            ChangeCoinText();
        }

        /// <summary>
        /// Reward按钮点击后，弹出reward面板，reward面板包括各种奖励item,根据奖杯情况显示可以获取的奖励
        /// </summary>
        public void RewardBtnOnClicked()
        {
            Instantiate(rewardPrefab,rewardParent);

        }
        /// <summary>
        /// 检测coin值的更新
        /// </summary>
        private void Update()
        {
            if (UserInfo.Instance != null && UserInfo.Instance.Coin != _lastCoin)
            {
                _lastCoin = UserInfo.Instance.Coin;
                ChangeCoinText();
            }
        }
    }
    
}
