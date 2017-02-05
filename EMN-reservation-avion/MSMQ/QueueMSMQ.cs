using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.EnterpriseServices;
using System.Messaging;

namespace reservation.MSMQ
{
    public class QueueMSMQ
    {
        // Depile la queue et retourne un objet de type ReservationInfos
        public ReservationInfos LireQueue()
        {
            MessageQueue mq = new MessageQueue(@".\private$\TEST");
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(ReservationInfos) });
            ReservationInfos message = new ReservationInfos();
            message = (ReservationInfos) mq.Peek().Body;
            mq.Receive();
            mq.Close();
            return message;
        }

        // Envoi un message sur la queue contenant un objet de type ReservationInfos
        public void EcrireQueue(ReservationInfos infos)
        {
            MessageQueue queue = null;
            if(MessageQueue.Exists(@".\private$\TEST"))
            {
                queue = new MessageQueue(@".\private$\TEST");
            } else
            {
                MessageQueue.Create(@".\private$\TEST");
                queue = new MessageQueue(@".\private$\TEST");
            }
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ReservationInfos) });
            queue.Send(infos);
            queue.Close();
        }
    }

    // Objet modelisant une reservation d'un vol et d'un hotel d'un client
    public class ReservationInfos
    {
        public ReservationInfos() {}

        public ReservationInfos(string clt, string vl, string htl)
        {
            client = clt;
            vol = vl;
            hotel = htl;
        }

        public string client;
        public string vol;
        public string hotel;
    }
}
