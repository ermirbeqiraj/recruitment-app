using System.ComponentModel;

namespace Domain.Constants
{
    public enum AppointmentType
    {
        Phone = 10,

        [Description("Video Call")]
        VideoCall = 20,
        PhysicalMeeting = 30
    }
}