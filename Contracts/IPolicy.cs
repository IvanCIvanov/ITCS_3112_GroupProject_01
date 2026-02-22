using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2;

public interface IPolicy
{
    bool CanCheckout(Item item);
}