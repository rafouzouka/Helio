using Helio.Actors;
using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Components;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Helio.Box.Systems
{
    public class Render : RenderEngine
    {
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Texture2D _blockTexture;

        public override void Init()
        {
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _playerTexture = contentManager.Load<Texture2D>("player");
            _enemyTexture = contentManager.Load<Texture2D>("enemy");
            _blockTexture = contentManager.Load<Texture2D>("block");
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            switch (e.type)
            {
                case EntityType.Player:
                    Sprite sprite = new Sprite(_playerTexture, e.rect);
                    AddRenderableItem(e.id, sprite);
                    break;

                case EntityType.Enemy:
                    Sprite enemySprite = new Sprite(_enemyTexture, e.rect);
                    AddRenderableItem(e.id, enemySprite);
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }

        }
    }
}
