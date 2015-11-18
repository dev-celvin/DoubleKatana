using KGCustom.Controller;

public abstract class CharacterBehavior {

    public float xTransfer { get; set; }
    public float yTransfer { get; set; }

    public virtual void execute(KGCharacterController cc)
    {
    }

    public virtual void begin(KGCharacterController cc)
    {

    }

    public virtual void end(KGCharacterController cc) { }
}
