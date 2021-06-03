using System.Collections.Generic;

namespace Task5
{
    public class MathParser
    {
        public static decimal ParseSimpleExp(string text)
        {
            string textWoSpaces = text.Replace(" ", "");
            List<decimal> numbers = new List<decimal>();
            List<char> signs = new List<char>();
            string forParse = "";
            bool flagExp = false;
            int expLevel = 0;

            foreach (char c in textWoSpaces)
            {
                if (flagExp)
                {
                    forParse += c;
                    expLevel = ChangeLevel(expLevel, c);
                    if (expLevel == 0)
                    {
                        numbers.Add(ParseSimpleExp(forParse.Substring(0, forParse.Length - 1)));
                        flagExp = false;
                        forParse = "";
                    }
                }
                else
                {
                    if (c == '(')
                    {
                        flagExp = true;
                        expLevel++;
                    }
                    else if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        signs.Add(c);
                        if (forParse.Length > 0)
                            numbers.Add(decimal.Parse(forParse));
                        forParse = "";
                    }
                    else
                    {
                        forParse += c;
                    }
                }
            }

            if (forParse.Length > 0)
                numbers.Add(decimal.Parse(forParse));

            Processing(numbers, signs, true);
            Processing(numbers, signs, false);
            return numbers[0];
        }

        private static int ChangeLevel(int level, char symb)
        {
            if (symb == '(')
                level++;
            if (symb == ')')
                level--;
            return level;
        }

        private static void Processing(List<decimal> numbers, List<char> signs, bool priority)
        {
            char sign1 = priority ? '*' : '+';
            char sign2 = priority ? '/' : '-';
            for (int i = 0; i < signs.Count; i++)
            {
                if (signs[i] == sign1 || signs[i] == sign2)
                {
                    if (signs[i] == sign1)
                    {
                        numbers[i] = priority ? numbers[i] * numbers[i + 1] : numbers[i] + numbers[i + 1];
                    }
                    else
                    {
                        numbers[i] = priority ? numbers[i] / numbers[i + 1] : numbers[i] - numbers[i + 1];
                    }

                    signs.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
            }
        }
    }
}
