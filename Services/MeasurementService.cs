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
            List<Measurment> measurementsCopy = new List<Measurment>();
            measurementsCopy = _measurements = _context.Measurements.ToList(); 

            return measurementsCopy;
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
            _context.Measurements.Add(measurement);  // Add to the database
            _context.SaveChanges();  // Save changes to the database
            _measurements = _context.Measurements.ToList();  // Update the in-memory list
            return measurement;
        }

        public void Delete(int id) 
        {
            Measurment? measurement = _measurements.Find(m => m.Id == id);
            if (measurement == null)
            {
                throw new Exception("Measurement not found");
            }
            _context.Measurements.Remove(measurement);
            _measurements.Remove(measurement);
            _context.SaveChanges();
        }


    }
}
