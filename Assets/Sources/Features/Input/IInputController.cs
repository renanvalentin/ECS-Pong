public interface IInputController {
    bool IsHoldingLeft ();
    bool IsStartedHoldingLeft ();
    float HoldingTimeLeft ();
    bool IsReleasedLeft ();

    bool IsHoldingRight ();
    bool IsStartedHoldingRight ();
    float HoldingTimeRight ();
    bool IsReleasedRight ();

    void Update (float delta);
}