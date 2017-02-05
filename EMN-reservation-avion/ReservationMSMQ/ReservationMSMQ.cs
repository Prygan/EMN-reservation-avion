using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using reservation.MSMQ;
using reservation.Reservations;

namespace reservation.ReservationsMSMQ
{
    public class ReservationMSMQ
    {
        public ReservationRess FetchReservation()
        {
            QueueMSMQ queue = new QueueMSMQ();
            ReservationInfos reservationsinfos = queue.LireQueue();
            return new ReservationRess(reservationsinfos.client, Convert.ToInt16(reservationsinfos.vol), Convert.ToInt16(reservationsinfos.hotel));
        }
    }
}
