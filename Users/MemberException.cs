namespace Users
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string memberId)
            : base($"회원을 찾을 수 없습니다. ID: {memberId}")
        {
        }
    }
     
    public class InsufficientPointException : Exception
    {
        public int RequiredPoint { get; }
        public int CurrentPoint { get; }

        public InsufficientPointException(int required, int current)
            : base($"포인트가 부족합니다. 필요: {required}점, 현재: {current}점")
        {
            RequiredPoint = required;
            CurrentPoint = current;
        }
    }
}