﻿namespace Knv.MGEN230109.Events
{
    class ConnectionChangedAppEvent : IApplicationEvent
    {
        public bool IsOpen { get; set; }
        
        public ConnectionChangedAppEvent(bool isOpen)
        {
            IsOpen = isOpen;
        }
    }
}
