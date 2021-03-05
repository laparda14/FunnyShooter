namespace FunnyShooter.Core {
    /// <summary>
    /// 事件基类。
    /// </summary>
    public abstract class BaseEventArgs : CustomEventArgs {
        public abstract int Id { get; protected set; }
    }
}