namespace SrpLab;

public sealed class GiftWrapPolicy
{
    private const decimal GiftWrapFee = 4.99m;

    public decimal GetFee(bool isGiftWrap)
    {
        return isGiftWrap ? GiftWrapFee : 0m;
    }
}