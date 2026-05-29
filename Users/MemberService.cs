namespace Users
{
    public delegate double DiscountCalculator(Member member);

    public class MemberService
    {
        protected List<Member> members = new List<Member>();
        protected Dictionary<string, string> loginInfo = new Dictionary<string, string>();
        protected Member currentMember = null;

        // 회원가입
        public void Register(string name, string email, string password, string grade, out string memberId)
        {
            memberId = "M" + (members.Count + 1).ToString("D3");
            Member newMember;

            try
            {
                if (grade == "골드")
                    newMember = new GoldMember(memberId, name, email);
                else if (grade == "실버")
                    newMember = new SilverMember(memberId, name, email);
                else
                    newMember = new Member(memberId, name, email);

                members.Add(newMember);
                loginInfo.Add(memberId, password);
                Console.WriteLine($"회원가입 완료! 발급된 ID: {memberId}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"회원가입 실패: {e.Message}");
                throw;
            }
        }

        // 로그인
        public bool Login(string memberId, string password)
        {
            try
            {
                if (!loginInfo.ContainsKey(memberId))
                    throw new MemberNotFoundException(memberId);

                if (loginInfo[memberId] != password)
                    throw new Exception("비밀번호가 틀렸습니다.");

                currentMember = members.Find(m => m.MemberId == memberId);
                Console.WriteLine($"로그인 성공! {currentMember.GetInfo()}");
                return true;
            }
            catch (MemberNotFoundException e)
            {
                Console.WriteLine($"오류: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"오류: {e.Message}");
                return false;
            }
            finally
            {
                Console.WriteLine("로그인 시도 완료.");
            }
        }

        // 로그아웃
        public void Logout()
        {
            if (currentMember != null)
            {
                Console.WriteLine($"{currentMember.Name}님 로그아웃 되었습니다.");
                currentMember = null;
            }
        }
    }
} 