using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanceInvadersUltra
{
    class PlayingState : GameObjectList
    {
        SpriteGameObject background;

        public PlayingState()
        {
            //adding sprites
            background = new SpriteGameObject("spr_background");

            //adding the background image
            Add(background);
        }
    }
}
