namespace Payments
{
    public class BankTransferPayment : Payment
    {
        private string bankName;
        private string accountNumber;

        public string BankName
        {
            get { return bankName; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public BankTransferPayment(int amount, string bankName, string accountNumber)
            : base(amount)
        {
            this.bankName = bankName;
            this.accountNumber = accountNumber;
        }

        public override bool Pay()
        {
            try
            {
                if (string.IsNullOrEmpty(accountNumber))
                    throw new Exception("계좌번호가 유효하지 않습니다.");

                Status = "결제완료";
                Console.WriteLine($"계좌이체 완료! {bankName} | 계좌: {accountNumber} | 금액: {Amount}원");
                return true;
            }
            catch (Exception e)
            {
                Status = "결제실패";
                Console.WriteLine($"계좌이체 실패: {e.Message}");
                return false;
            }
            finally
            {
                Console.WriteLine("계좌이체 처리 완료.");
            }
        }

        public override bool Refund()
        {
            try
            {
                if (Status != "결제완료")
                    throw new Exception("결제 완료 상태에서만 환불 가능합니다.");

                Status = "환불완료";
                Console.WriteLine($"계좌이체 환불 완료! 금액: {Amount}원");
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
            Console.WriteLine($"결제수단: 계좌이체 | {bankName} {accountNumber}");
        }
    }
}