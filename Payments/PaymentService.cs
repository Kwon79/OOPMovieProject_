namespace Payments
{
    public class PaymentService
    {
        private List<Payment> paymentHistory = new List<Payment>();

        public bool PayByCard(int amount, string cardNumber)
        {
            try
            {
                CardPayment payment = new CardPayment(amount, cardNumber);
                bool result = payment.Pay();
                if (result) paymentHistory.Add(payment);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"결제 오류: {e.Message}");
                return false;
            }
        }

        public bool PayByBankTransfer(int amount, string bankName, string accountNumber)
        {
            try
            {
                BankTransferPayment payment = new BankTransferPayment(amount, bankName, accountNumber);
                bool result = payment.Pay();
                if (result) paymentHistory.Add(payment);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"결제 오류: {e.Message}");
                return false;
            }
        }

        public bool PayByPoint(int amount, int usedPoint)
        {
            try
            {
                PointPayment payment = new PointPayment(amount, usedPoint);
                bool result = payment.Pay();
                if (result) paymentHistory.Add(payment);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"결제 오류: {e.Message}");
                return false;
            }
        }

        public void PrintHistory()
        {
            var completed = paymentHistory.FindAll(p => p.Status == "결제완료");
            Console.WriteLine($"=== 결제 내역 ({completed.Count}건) ===");
            completed.ForEach(p => p.GetReceipt());
        }

        public int GetTotalAmount()
        {
            int total = 0;
            paymentHistory.FindAll(p => p.Status == "결제완료")
                          .ForEach(p => total += p.Amount);
            return total;
        }

        public void Refund(int index)
        {
            try
            {
                if (index < 0 || index >= paymentHistory.Count)
                    throw new Exception("유효하지 않은 결제 내역입니다.");

                paymentHistory[index].Refund();
            }
            catch (Exception e)
            {
                Console.WriteLine($"환불 오류: {e.Message}");
            }
            finally
            {
                Console.WriteLine("환불 처리 완료.");
            }
        }
    }
}