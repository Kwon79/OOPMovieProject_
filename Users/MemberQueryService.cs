namespace Users
{
    public class MemberQueryService : MemberService
    {
        // 이름으로 회원 찾기
        public Member FindByName(string name)
        {
            return members.Find(m => m.Name == name);
        }

        // 전체 회원 목록 출력
        public void PrintAllMembers()
        {
            members.Sort((a, b) => a.Name.CompareTo(b.Name));
            foreach (var member in members)
                Console.WriteLine(member.GetInfo());
        }

        // 포인트 사용
        public void UsePoint(int amount)
        {
            try
            {
                if (currentMember == null)
                    throw new Exception("로그인이 필요합니다.");

                if (currentMember.Point < amount)
                    throw new InsufficientPointException(amount, currentMember.Point);

                Console.WriteLine($"{amount}점 사용 완료!");
            }
            catch (InsufficientPointException e)
            {
                Console.WriteLine($"오류: {e.Message}");
            }
            finally
            {
                Console.WriteLine("포인트 사용 처리 완료.");
            }
        }

        // 델리게이트로 할인율 계산
        public double CalcDiscount(Member member, DiscountCalculator calculator)
        {
            return calculator(member);
        }
    }
}