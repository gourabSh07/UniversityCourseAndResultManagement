using System.Collections.Generic;
using UniversityCourseAndResultManagement.DLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.BLL
{
    public class RoomManager
    {
        RoomGateway roomGateway = new RoomGateway();
        public IEnumerable<Room> GetAllRooms
        {
            get { return roomGateway.GetAllRooms; }
        }
    }
}