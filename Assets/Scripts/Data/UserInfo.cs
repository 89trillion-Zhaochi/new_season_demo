using Base;

namespace Data
{
    /// <summary>
    /// 用户数据类
    /// </summary>
    public class UserData
    {
        private int _rank; //等级

        public int Coin { get; set; }

        public int Trophy { get; set; }
    }
    
    
    /// <summary>
    ///用户数据单例
    /// </summary>
    public abstract class UserInfo:Singleton<UserData>
    {
    
    }
}