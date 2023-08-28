namespace Content.Server.Flash.Components
{
    [RegisterComponent, Access(typeof(FlashSystem))]
    public sealed partial class FlashImmunityComponent : Component
    {
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("enabled")]
        public bool Enabled { get; set; } = true;
        
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("protectFromBangs")]
        public bool ProtectFromBangs { get; set; } = false;
    }
}
