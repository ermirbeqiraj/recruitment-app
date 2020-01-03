using System;

namespace Web.Models
{
    public class CandidateListModel
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }

    public class CandidateRegisterModel
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }

    public class CandidateModifyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string CurrentPosition { get; set; }
        public string Note { get; set; }
    }

    public class CandidateRemoveModel
    {

    }
}
