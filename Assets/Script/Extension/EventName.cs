namespace Hawki.EventObserver
{
    public partial class EventName
    {
        public const string REPLAY = "REPLAY";
        public const string LOSE_GAME = "LOSE_GAME";
        public const string ADD_POINT = "ADD_POINT";
        public const string CHANGE_BG = "CHANGE_BG";
    }
    public class ReplayEvent : EventBase
    {

    }
    public class LoseGameEvent : EventBase
    {

    }
    public class AddPointEvent : EventBase
    {
        public int point;
    }

}