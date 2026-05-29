namespace Payments
{
    public class PointPayment : Payment
    {
        private int usedPoint;

        public int UsedPoint
        {
            get { return usedPoint; }
        }

        public PointPayment(int amount, int usedPoint)
            : base(amount)
        {
            this.usedPoint = usedPoint;
        }

        public override bool Pay()
        {
            try
            {
                if (usedPoint < Amount)
                    throw new Exception($"포인트가 부족합니다. 필요: {Amount}점, 보유: {usedPoint}점");

                Status = "결제완료";
                Console.WriteLine($"포인트 결제 완료! 사용 포인트: {Amount}점");
                return true;
            }
            catch (Exception e)
            {
                Status = "결제실패";
                Console.WriteLine($"포인트 결제 실패: {e.Message}");
                return false;
            }
            finally
            {
                Console.WriteLine("포인트 결제 처리 완료.");
            }
        }

        public override bool Refund()
        {
            try
            {
                if (Status != "결제완료")
                    throw new Exception("결제 완료 상태에서만 환불 가능합니다.");

                Status = "환불완료";
                Console.WriteLine($"포인트 환불 완료! 반환 포인트: {Amount}점");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"환불 실패: {e.Message}");
                return false;
            }
        }

        public override void GetReceipt()
        {
            base.GetReceipt();
            Console.WriteLine($"결제수단: 포인트 | 사용 포인트: {usedPoint}점");
        }
    }
}