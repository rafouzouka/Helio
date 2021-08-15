using Helio.Audio;
using Helio.Box.Views.Events;
using Helio.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Helio.Box.Systems
{
    class Musics : MixerSystem
    {
        private Song _chant;

        public override void Init()
        {
            //EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _chant = contentManager.Load<Song>("sounds/jump");
        }

        public void RequestPlayerMove(Event ev)
        {
            RequestPlayerMove e = (RequestPlayerMove)ev;

            if (e.movementType == PlayerMovementType.Jump)
            {
                Debug.WriteLine("JUMP PRESSED");
                PlayMusic(_chant);
            }
        }
    }
}
