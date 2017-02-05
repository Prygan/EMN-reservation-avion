using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using reservation.MSMQ;
using reservation.Reservations;
using reservation.ReservationsMSMQ;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            ReservationInfos message = new ReservationInfos(txtClient.Text, txtVol.Text, txtHotel.Text);
            QueueMSMQ msmq = new QueueMSMQ();
            msmq.EcrireQueue(message);
        }

        private void btnDepiler_Click(object sender, EventArgs e)
        {
            ReservationMSMQ res = new ReservationMSMQ();
            ReservationRess ress = res.FetchReservation();
            txtContenu.Text = ress.client + ":" + ress.vol + ":" + ress.hotel;
            Reservation reservation = new Reservation();
            reservation.Reserver(ress);
        }
    }
}
