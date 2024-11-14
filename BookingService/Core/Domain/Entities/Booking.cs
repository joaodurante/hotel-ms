using Domain.Enums;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Booking
    {
        public Booking() {
            this.Status = EStatus.Created;
        }

        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        private EStatus Status { get; set; }
        public EStatus CurrentStatus { get {  return Status; } }

        public void ChangeState(Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (EStatus.Created, Action.Pay) => EStatus.Paid,
                (EStatus.Created, Action.Cancel) => EStatus.Canceled,
                (EStatus.Paid, Action.Finish) => EStatus.Finished,
                (EStatus.Paid, Action.Refound) => EStatus.Refounded,
                (EStatus.Canceled, Action.Reopen) => EStatus.Created,
                _ => Status
            };
        }

    }
}
