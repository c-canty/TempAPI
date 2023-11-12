using TempAPI.DBContext;

namespace TempAPI.Services
{
    public class MeasurementService
    {
        private readonly TempContext _context;
        private List<Measurment> _measurements;

        public MeasurementService(TempContext tempContext) 
        {             
            _context = tempContext;
            _measurements = _context.Measurements.ToList();
        }

        public List<Measurment> Get()
        { 
            return _context.Measurements.ToList();
        }

        public Measurment GetById(int id)
        {
            Measurment? measurement = _measurements.Find(m => m.Id == id);
            if (measurement == null)
            {
                throw new Exception("Measurement not found");
            }
            return measurement;          
        }

        public Measurment Create(Measurment measurement)
        {
            _measurements.Add(measurement);
            _context.SaveChanges();
            return measurement;
        }

        public void Delete(int id) 
        {
            Measurment? measurement = _measurements.Find(m => m.Id == id);
            if (measurement == null)
            {
                throw new Exception("Measurement not found");
            }
            _measurements.Remove(measurement);
            _context.SaveChanges();
        }


    }
}
