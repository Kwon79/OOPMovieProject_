namespace Users
{
    public class GoldMember : Member   
    {
        public GoldMember(string memberId, string name, string email)
            : base(memberId, name, email)
        {
        }

        public override double GetDiscount()
        {
            return 0.15;
        }

        public override string GetInfo()
        {
            return $"[골드회원] {Name} | ID: {MemberId} | 포 인트: {Point}점 | 할인율: 15%";
        }
    }
}