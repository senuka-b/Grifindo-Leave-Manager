using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Leave_Manager.model {
    internal class Roaster {
        private User user;
        private DateTime startTime;
        private DateTime endTime;

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public User User { get => user; set => user = value; }

        public Roaster(User user, DateTime startTime, DateTime endTime) {
            this.user = user;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}
