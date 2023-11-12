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

        public IEnumerable<List<Measurment>> Get()
        { 
            List<Measurment> measurementsCopy = new List<Measurment>();
            measurementsCopy = _measurements;

            //if (id != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Id == id).ToList();
            //}

            //if (minTemp != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Temperature >= minTemp).ToList();
            //}
            //if (maxTemp != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Temperature <= maxTemp).ToList();
            //}

            //if (minHumidity != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Humidity >= minHumidity).ToList();
            //}
            //if (maxHumidity != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Humidity <= maxHumidity).ToList();
            //}

            //if (minPressure != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Pressure >= minPressure).ToList();
            //}
            //if (maxPressure != null)
            //{
            //    measurementsCopy = measurementsCopy.Where(m => m.Pressure <= maxPressure).ToList();
            //}
            
            //if (orderBy != null)
            //{
            //    if (orderBy == "temperature")
            //    {
            //        measurementsCopy = measurementsCopy.OrderBy(m => m.Temperature).ToList();
            //    }
            //    else if (orderBy == "humidity")
            //    {
            //        measurementsCopy = measurementsCopy.OrderBy(m => m.Humidity).ToList();
            //    }
            //    else if (orderBy == "pressure")
            //    {
            //        measurementsCopy = measurementsCopy.OrderBy(m => m.Pressure).ToList();
            //    }
            //    else if (orderBy == "time")
            //    {
            //        measurementsCopy = measurementsCopy.OrderBy(m => m.Time).ToList();
            //    }
            //}
           
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
