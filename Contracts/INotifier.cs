using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2;

public interface INotifier
{
    void AlertDueSoon(CheckoutRecord record);
    void AlertOverdue(CheckoutRecord record);
}