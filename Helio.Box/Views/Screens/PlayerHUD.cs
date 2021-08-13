using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Core;
using Helio.Events;
using Helio.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Box.Views.Screens
{
    public class PlayerHUD : UICanvas
    {
        private Entity _player;

        public override void Init()
        {
            EventManager.Instance.AddListener(RegisterPlayerEntity, typeof(EntityCreated));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            SpriteFont aria = contentManager.Load<SpriteFont>("fonts/Aria");
            //AddUIElement(new Text(aria, "Salut les gens", Color.Red));
        }

        public void RegisterPlayerEntity(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            if (e.type == EntityType.Player)
            {
                _player = e.id;
            }
        }
    }
}
