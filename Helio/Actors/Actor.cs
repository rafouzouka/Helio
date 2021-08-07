using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Helio.Actors
{
    public struct ActorId
    {
        public ulong id;
    
        public ActorId(ulong id)
        {
            this.id = id;
        }
    }

    public class Actor
    {
        private ActorId _id;
        private Dictionary<Type, Component> _components;

        public Actor(ActorId id)
        {
            _id = id;
            _components = new Dictionary<Type, Component>();
        }

        public ActorId GetId()
        {
            return _id;
        }

        public void AddComponent(Component component)
        {
            component.SetOwner(this);
            _components.Add(component.GetType(), component);
        }

        public T GetComponent<T>() where T : Component
        {
            Component component;
            if (_components.TryGetValue(typeof(T), out component) == true)
            {
                if (component != null)
                {
                    return component as T;
                }
            }
            throw new Exception("The Component id wasn't finded in the map");
        }

        public void Destroy()
        {
            // must destroy the actor and the components
        }

        public void Start()
        {
            foreach (KeyValuePair<Type, Component> entry in _components)
            {
                entry.Value.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<Type, Component> entry in _components)
            {
                entry.Value.Update(gameTime);
            }
        }

        public override string ToString()
        {
            return $"id: {_id}, components count: {_components.Count}";
        }
    }
}
