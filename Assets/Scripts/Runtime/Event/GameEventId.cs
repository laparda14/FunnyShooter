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
        OnPlayerDirctionChange,
        OnMousePositionChange,
        OnWeaponDirctionChange,
        OnRecycleAllObjects,
        OnCameraShake,
        OnFireShake,
        OnExplosionShake,
        OnPlayerHit,
        OnHealthBarCreate,
        OnHealthChange,
        OnPlayerDeath,
        OnUnetShop,
        OnServerDisconnect
    }
}
