using System;

namespace FunnyShooter.Core {
    /// <summary>
    /// 参数抽象类
    /// </summary>
    public abstract class CustomEventArgs : EventArgs, IReference {
        public abstract void Clear();
    }
}