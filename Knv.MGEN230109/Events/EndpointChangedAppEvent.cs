namespace Knv.MGEN230109.Events
{
    class EndpointChangedAppEvent : IApplicationEvent
    {
        public string EpName { get; set; }
        
        public EndpointChangedAppEvent(string epName)
        {
            EpName = epName;
        }
    }
}
