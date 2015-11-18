using Global;
using KGCustom.Model.Character;

public class Player : Character {

    public float rage { get; set; }
    public float rageMax { get; set; }

    

    public float moveDragRate {
        get; set;
    }

    static Player m_Player = null;

    private Player(){
        xDirection = GlobalValue.XDIRECTION_RIGHT;
        yDirection = GlobalValue.YDIRECTION_UP;
        hp = 100;
        hpMax = 100;
        mp = 100;
        mpMax = 100;
    }

    public static Player instance {
        get {
            if (m_Player == null)
            {
                m_Player = new Player();
            }
            return m_Player;
        }
    }
}
