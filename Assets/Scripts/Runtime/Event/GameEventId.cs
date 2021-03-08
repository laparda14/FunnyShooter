namespace FunnyShooter.Runtime {
    /// <summary>
    /// 事件 Id
    /// </summary>
    public enum GameEventId {
        None = 0,
        OnApplicationInit,
        OnApplicationPause,
        OnApplicationFocus,
        OnApplicationQuit,
        OnGamePause,
        OnGameSpeedChange,
        OnStartLocalPlayer,
        OnMoveXInputChange,
        OnVelocityXChange,
        OnVelocityYChange,
        OnGroundChange,
        OnJumpInputChange,
        OnFireInputChange,
        OnDirctionChange,
        OnMousePositionChange,
        OnWeaponDirctionChange,
        OnRecycleAllObjects,
        OnCameraShake,
        OnFireShake,
        OnExplosionShake,
        OnPlayerHit,
    }
}
