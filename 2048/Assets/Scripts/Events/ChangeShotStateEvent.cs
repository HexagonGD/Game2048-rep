namespace Game2048
{
    public readonly struct ChangeShotStateEvent
    {
        public readonly bool isEnable;

        public ChangeShotStateEvent(bool isEnable)
        {
            this.isEnable = isEnable;
        }
    }
}