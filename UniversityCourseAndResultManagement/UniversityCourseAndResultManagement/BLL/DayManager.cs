using System.Collections.Generic;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class DayManager
    {
        DayGateway dayGateway = new DayGateway();
        public IEnumerable<Day> GetAllDays
        {
            get { return dayGateway.GetAllDays; }
        }
    }
}