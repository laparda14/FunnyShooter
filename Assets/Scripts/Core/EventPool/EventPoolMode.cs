using System;

namespace FunnyShooter.Core {
    /// <summary>
    /// 事件池模式
    /// </summary>
    [Flags]
    public enum EventPoolMode : byte {
        Default = 0x0,

        AllowNoHandler = 0x1,

        AllowMultiHandler = 0x2,

        AllDuplicateHandler = 0x4,
    }
}