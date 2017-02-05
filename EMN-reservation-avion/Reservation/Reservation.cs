using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using reservation.DBHotel;
using reservation.DBVol;


namespace reservation.Reservations
{
    public class Reservation
    {
        public void Reserver(ReservationRess reserv)
        {
            Commandes_Hotel hotel = new Commandes_Hotel();
            hotel.reservation_hotel(reserv.client, reserv.hotel);
            Commandes_Vol vol = new Commandes_Vol();
            vol.reservation_vol(reserv.client, reserv.vol);
        }
    }

    public class ReservationRess
    {
        public string client;
        public int vol;
        public int hotel;

        public ReservationRess() { }
        public ReservationRess(string clt, int vl, int htl)
        {
            client = clt;
            vol = vl;
            hotel = htl;
        }
    }
}
