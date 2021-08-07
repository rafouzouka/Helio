using Helio.Actors;
using Helio.Box.Events;
using Helio.Components;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Helio.Box.Systems
{
    public class RenderSystem : GameSystem, IRenderable
    {
        private Texture2D _playerTexture;

        public override void Init()
        {
            EventManager.Instance.AddListener(CreateNewActorWithSprite, typeof(CreatePlayerActor));
            EventManager.Instance.AddListener(MoveSpritePosition, typeof(PlayerMoved));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _playerTexture = contentManager.Load<Texture2D>("player");
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<ActorId, Actor> actor in _actors)
            {
                SpriteComponent sp = actor.Value.GetComponent<SpriteComponent>();
                sp.Draw(gameTime, renderer);
            }
        }

        public void CreateNewActorWithSprite(Event evnt)
        {
            CreatePlayerActor e = (CreatePlayerActor)evnt;
            Actor a = new Actor(e.actorId);
            a.AddComponent(new TransformComponent());
            a.AddComponent(new SpriteComponent(_playerTexture));
            _actors.Add(e.actorId, a);
        }

        public void MoveSpritePosition(Event evnt)
        {
            PlayerMoved e = (PlayerMoved)evnt;
            TransformComponent sc = _actors[e.playerId].GetComponent<TransformComponent>();
            sc.position = e.newPosition;
        }
    }
}
