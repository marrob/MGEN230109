namespace Knv.MGEN230109.Events
{
    class PlayerStatusAppEvent : IApplicationEvent
    {
        public string Status { get; set; }
        
        public PlayerStatusAppEvent(string status)
        {
            Status = status;
        }
    }
}
