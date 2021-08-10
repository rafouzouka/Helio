using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Actors
{
    public static class ActorFactory
    {
        private static ulong _lastActorId = 0;
 
        public static PActor CreateEmptyActor()
        {
            PActorId actorId;
            actorId.id = _lastActorId;
            _lastActorId++;
            return new PActor(actorId);
        }
    }
}
