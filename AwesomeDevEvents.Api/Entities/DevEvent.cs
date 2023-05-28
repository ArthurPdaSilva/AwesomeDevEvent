using AwesomeDevEvents.Api.Interfaces;

namespace AwesomeDevEvents.Api.Entities
{
    public class DevEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventSpeaker> Speakers { get; set; }
        public bool IsDeleted { get; set; }

        public DevEvent() {
            Speakers = new List<DevEventSpeaker>();
            IsDeleted = false;
        }

        public void Update(UpdateDevEventProp updateDevEventProp) { 
            Title = updateDevEventProp.Title;
            Description = updateDevEventProp.Description;
            StartDate = updateDevEventProp.StartDate;
            EndDate = updateDevEventProp.EndDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
