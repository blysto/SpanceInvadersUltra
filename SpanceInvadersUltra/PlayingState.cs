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
        SpaceShipGeneral player;

        public PlayingState()
        {
            //adding sprites
            background = new SpriteGameObject("spr_background");
            player = new SpaceShipGeneral();

            //adding the background image
            Add(background);

            //adding the player ship
            Add(player);
        }
    }
}
