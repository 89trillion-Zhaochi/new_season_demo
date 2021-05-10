using SuperScrollView;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    /// <summary>
    /// 加载可复用的scrollView，销毁panel
    /// </summary>
    public class RewardPanel:MonoBehaviour
    {
        public LoopListView2 mLoopListView;
        [FormerlySerializedAs("_itemTotalCount")] [SerializeField] private int itemTotalCount;
        
        private bool _isClicked;
        
        /// <summary>
        /// 启动panel时加载可复用的scrollView
        /// </summary>
        private void Start()
        {
            mLoopListView.InitListView(itemTotalCount,OnGetItemByIndex);  
        }

        // ReSharper disable Unity.PerformanceAnalysis
        
        /// <summary>
        /// Super ScrollView的回调函数
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
        {
            if (index < 0 || index >= itemTotalCount)
            {
                return null;
            }
            LoopListViewItem2 item = listView.NewListViewItem("RewardItem");
            RewardItem listItem = item.GetComponent<RewardItem>();
            if (item.IsInitHandlerCalled == false)
            {
                item.IsInitHandlerCalled = true;
            }
            listItem.SetValue(index);
            // listItem
            return item;
        }
        
        /// <summary>
        /// 销毁RewardPanel
        /// </summary>
        public void CloseBtnOnClicked()
        {
            Destroy(this.gameObject);
        }
    }
}