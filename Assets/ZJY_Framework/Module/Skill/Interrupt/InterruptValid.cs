using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 可行性检查被打断了(即检查技能能否释放)
    /// </summary>
    public class InterruptValid : IInterrupt
    {
        public virtual void Handle(PlayerBase entity)
        {
            //todo
            Debug.Log("技能无法释放!");
        }
    }
}
