public static string RomanNum(int number)
{
    if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value between 1 and 3999");
    if (number < 1) return string.Empty;            
    if (number >= 1000) return "M" + RomanNum(number - 1000);
    if (number >= 900) return "CM" + RomanNum(number - 900); 
    if (number >= 500) return "D" + RomanNum(number - 500);
    if (number >= 400) return "CD" + RomanNum(number - 400);
    if (number >= 100) return "C" + RomanNum(number - 100);            
    if (number >= 90) return "XC" + RomanNum(number - 90);
    if (number >= 50) return "L" + RomanNum(number - 50);
    if (number >= 40) return "XL" + RomanNum(number - 40);
    if (number >= 10) return "X" + RomanNum(number - 10);
    if (number >= 9) return "IX" + RomanNum(number - 9);
    if (number >= 5) return "V" + RomanNum(number - 5);
    if (number >= 4) return "IV" + RomanNum(number - 4);
    if (number >= 1) return "I" + RomanNum(number - 1);
    throw new ArgumentOutOfRangeException("bad entry you added something that wasnt good.");
}
