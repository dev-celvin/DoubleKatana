using Global;

namespace KGCustom.Model.Character.Enemy
{
    public class PikeMan : Character
    {
        public PikeMan()
        {
            xDirection = GlobalValue.XDIRECTION_RIGHT;
            yDirection = GlobalValue.YDIRECTION_UP;
            hp = 100;
            hpMax = 100;
            mp = 100;
            mpMax = 100;
        }

    }

}

