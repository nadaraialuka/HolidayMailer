using HolidayMailer.DataBase;
using HolidayMailer.Models;

namespace HolidayMailer.Repository
{
    public class EventRepository
    {
        private readonly HolidayDBContext _context;

        public EventRepository()
        {
            _context = new HolidayDBContext();
        }

        public List<EventModel> GetEventsByUserId(int id)
        {
            return _context.Events.Where(ev => ev.UserId == id).ToList().Where(ev => Equals(DateTime.Now.ToString("MM:dd"), ev.Date.ToString("MM:dd"))).ToList();
        }

        public bool AddEvent(EventModel ev)
        {
            try
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
            }catch
            {
                return false;
            }
            return true;
        }
    }
}
