namespace Content.Server.Starshine.PlasmaCutter;

[RegisterComponent]
public sealed partial class BatteryRechargeComponent : Component
{

    /// <summary>
    /// NOT (material.Amount * Multiplier)
    /// This is (material.materialComposition * Multiplier)
    /// 1 plasma sheet = 100 material units
    /// 1 plasma ore = 500 material units
    /// </summary>
    ///
    [DataField]
    public float Multiplier = 1.0f;


    /// <summary>
    /// Max material storage limit
    /// 7500 = 15 plasma ore
    /// </summary>
    [DataField]
    public int StorageMaxCapacity = 7500;
}

