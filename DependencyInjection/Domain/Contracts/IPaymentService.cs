namespace DependencyInjection.Domain.Contracts
{
    public interface IPaymentService
    {
        void MakePayment(decimal amount);
    }
}