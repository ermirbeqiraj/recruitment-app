using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ClientListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int OpenVacancies { get; set; }
    }

    public class ClientCreateModel
    {

    }

    public class ClientUpdateModel
    {

    }
}
