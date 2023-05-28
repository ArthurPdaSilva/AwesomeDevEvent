using AwesomeDevEvents.Api.Entities;

namespace AwesomeDevEvents.Api.Persistence
{
    public class DevEventsDbContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public DevEventsDbContext() { 
            DevEvents = new List<DevEvent>();
        }
    }
}
