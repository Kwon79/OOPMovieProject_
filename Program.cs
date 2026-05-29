using Users;
using Payments;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== 회원 테스트 =====");

        // 회원 서비스 생성
        MemberQueryService memberService = new MemberQueryService();

        // 회원가입 테스트
        memberService.Register("홍길동", "hong@gmail.com", "1234", "골드", out string id1);
        memberService.Register("김영희", "kim@gmail.com", "5678", "실버", out string id2);
        memberService.Register("이철수", "lee@gmail.com", "9999", "일반", out string id3);

        Console.WriteLine();

        // 로그인 테스트
        memberService.Login(id1, "1234");

        Console.WriteLine();

        // 전체 회원 출력
        Console.WriteLine("===== 전체 회원 목록 =====");
        memberService.PrintAllMembers();

        Console.WriteLine();

        // 포인트 테스트
        Console.WriteLine("===== 포인트 테스트 =====");
        memberService.UsePoint(999999);  // 실패 케이스

        Console.WriteLine();

        // 로그아웃
        memberService.Logout();

        Console.WriteLine();
        Console.WriteLine("===== 결제 테스트 =====");

        // 결제 서비스 생성
        PaymentService paymentService = new PaymentService();

        // 카드 결제
        paymentService.PayByCard(15000, "1234-5678-9012-3456");

        // 계좌이체
        paymentService.PayByBankTransfer(20000, "국민은행", "123-456-789");

        // 포인트 결제
        paymentService.PayByPoint(5000, 10000);

        Console.WriteLine();

        // 결제 내역 출력
        Console.WriteLine("===== 결제 내역 =====");
        paymentService.PrintHistory();

        Console.WriteLine();

        // 총 결제 금액
        Console.WriteLine($"총 결제 금액: {paymentService.GetTotalAmount()}원");
    }
}