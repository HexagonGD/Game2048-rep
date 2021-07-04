namespace Game2048
{
    public interface IShotterState
    {
        void Shot();
        void OnUpdate();
        void Begin();
        void End();
    }
}