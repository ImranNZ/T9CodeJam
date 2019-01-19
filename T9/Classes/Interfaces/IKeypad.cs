namespace T9.Classes
{
    public interface IKeypad
    {
        int GetPositionOf(char letter);
        int GetDigitOf(char letter);
    }
}