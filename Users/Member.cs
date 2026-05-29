namespace Users
{
    public class Member : Person   
    {
        private string memberId;
        private int point;

        public string MemberId
        {
            get { return memberId; }
        }

        public int Point
        {
            get { return point; }
        }

        public Member(string memberId, string name, string email)
            : base(name, email)
        {
            this.memberId = memberId;
            this.point = 0;
        } 

        public override string GetInfo()
        {
            return $"[회원] {Name} | ID: {MemberId} | 포인트: {Point}점";
        }

        public void AddPoint(int amount, out int newTotal)
        {
            point += amount;
            newTotal = point;
        }

        public virtual double GetDiscount()
        {
            return 0.0;   
        }
    }
}