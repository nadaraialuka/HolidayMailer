namespace HolidayMailer.Models
{
    public class EventModel
    {
        public int Id { get; set; }   
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string TargetEmail { get; set; }
        public string TargetName { get; set; }        
    }
}
