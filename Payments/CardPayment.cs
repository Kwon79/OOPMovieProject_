namespace Payments
{
    public class CardPayment : Payment 
    {
        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
        }

        public CardPayment(int amount, string cardNumber)
            : base(amount)
        {
            this.cardNumber = cardNumber;
        }

        public override bool Pay()
        {
            try
            {
                if (string.IsNullOrEmpty(cardNumber))
                    throw new Exception("카드 번호가 유효하지 않습니다.");

                Status = "결제완료";
                Console.WriteLine($"카드 결제 완료! 카드번호: {cardNumber} | 금액: {Amount}원");
                return true;
            }
            catch (Exception e)
            {
                Status = "결제실패";
                Console.WriteLine($"카드 결제 실패: {e.Message}");
                return false;
            }
            finally
            {
                Console.WriteLine("카드 결제 처리 완료.");
            }
        }

        public override bool Refund()
        {
            try
            {
                if (Status != "결제완료")
                    throw new Exception("결제 완료 상태에서만 환불 가능합니다.");

                Status = "환불완료";
                Console.WriteLine($"카드 환불 완료! 금액: {Amount}원");
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
            Console.WriteLine($"결제수단: 카드 ({cardNumber})");
        }
    }
}