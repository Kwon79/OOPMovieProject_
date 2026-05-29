namespace Payments
{
    public abstract class Payment
    {
        private int amount;
        private DateTime paidAt;
        private string status;

        public int Amount
        {
            get { return amount; }
            protected set { amount = value; }
        }

        public DateTime PaidAt
        {
            get { return paidAt; }
            protected set { paidAt = value; }
        }

        public string Status
        {
            get { return status; }
            protected set { status = value; }
        }

        public Payment(int amount)
        {
            this.amount = amount;
            this.status = "대기";
            this.paidAt = DateTime.Now;
        }

        public abstract bool Pay();
        public abstract bool Refund();

        public virtual void GetReceipt()
        {
            Console.WriteLine($"결제금액: {Amount}원 | 상태: {Status} | 시간: {PaidAt}");
        }
    }
}