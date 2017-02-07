using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using reservation.MSMQ;

namespace WSQueue.Controllers
{
    public class QueueController : ApiController
    {
        [HttpPut]
        public void Put(int id, [FromBody] ReservationInfos message)
        {
            QueueMSMQ msmq = new QueueMSMQ();
            msmq.EcrireQueue(message);
        }
    }
}
