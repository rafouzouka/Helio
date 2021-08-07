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
    public class Render : GameSystem, IRenderable
    {
        private Texture2D _playerTexture;
        private Texture2D _blockTexture;

        public override void Init()
        {
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(EntityMoved, typeof(EntityMoved));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _playerTexture = contentManager.Load<Texture2D>("player");
            _blockTexture = contentManager.Load<Texture2D>("block");
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<ActorId, Actor> actor in _actors)
            {
                SpriteComponent sprite = actor.Value.GetComponent<SpriteComponent>();
                sprite.Draw(gameTime, renderer);
            }
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            switch (e.type)
            {
                case EntityType.Player:
                    Actor player = new Actor(e.id);
                    TransformComponent tra = new TransformComponent();
                    tra.position = e.pos;
                    player.AddComponent(new SpriteComponent(_playerTexture));
                    player.AddComponent(tra);
                    player.Start();
                    _actors.Add(player.GetId(), player);
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }
        }

        public void EntityMoved(Event ev)
        {
            EntityMoved e = (EntityMoved)ev;
            TransformComponent t = _actors[e.id].GetComponent<TransformComponent>();
            t.position = e.pos;
        }
    }
}
