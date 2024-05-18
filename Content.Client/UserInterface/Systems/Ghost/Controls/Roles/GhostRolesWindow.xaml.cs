using Content.Shared.Ghost.Roles;
using Content.Shared.CCVar;
using Robust.Client.AutoGenerated;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Configuration;
using Robust.Shared.Utility;

namespace Content.Client.UserInterface.Systems.Ghost.Controls.Roles
{
    [GenerateTypedNameReferences]
    public sealed partial class GhostRolesWindow : DefaultWindow
    {
        public event Action<GhostRoleInfo>? OnRoleRequestButtonClicked;
        public event Action<GhostRoleInfo>? OnRoleFollow;

        public void ClearEntries()
        {
            NoRolesMessage.Visible = true;
            EntryContainer.DisposeAllChildren();
        }

        public void AddEntry(string name, string description, bool hasAccess, FormattedMessage? reason, IEnumerable<GhostRoleInfo> roles, SpriteSystem spriteSystem)
        {
            NoRolesMessage.Visible = false;

            var entry = new GhostRolesEntry(name, description, hasAccess, reason, roles, spriteSystem);
            entry.OnRoleSelected += OnRoleRequestButtonClicked;
            entry.OnRoleFollow += OnRoleFollow;
            EntryContainer.AddChild(entry);
        }

        public void AddDenied(int denied)
        {
            if (denied == 0)
                return;

            NoRolesMessage.Visible = false;

            var message = Loc.GetString("ghost-role-whitelist-text", ("num", denied));

            var textLabel = new RichTextLabel();
            textLabel.SetMessage(message);
            EntryContainer.AddChild(textLabel);

            var whitelistButton = new Button();
            whitelistButton.Text = Loc.GetString("ui-escape-discord");

            var uri = IoCManager.Resolve<IUriOpener>();
            var cfg = IoCManager.Resolve<IConfigurationManager>();

            whitelistButton.OnPressed += _ =>
            {
                uri.OpenUri(cfg.GetCVar(CCVars.InfoLinksDiscord));
            };

            EntryContainer.AddChild(whitelistButton);
        }
    }
}
