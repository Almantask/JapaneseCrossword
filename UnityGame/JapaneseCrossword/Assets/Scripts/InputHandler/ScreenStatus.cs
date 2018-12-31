namespace Assets.Scripts.InputHandler
{
    public class ScreenStatus
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public bool IsDown { get; private set; }

        public void Update(float x, float y, bool isDown)
        {
            X = x;
            Y = y;
            IsDown = isDown;
        }
    }
}