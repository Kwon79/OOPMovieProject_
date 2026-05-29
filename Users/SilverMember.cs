namespace Users
{
    public class SilverMember : Member   
    {
        public SilverMember(string memberId, string name, string email)
            : base(memberId, name, email)   
        {
        }

        public override double GetDiscount()
        {
            return 0.05;
        }

        public override string GetInfo()
        {
            return $"[실버회원] {Name} | ID: {MemberId} | 포인트: {Point}점 | 할인율: 5%";
        }
    }
}