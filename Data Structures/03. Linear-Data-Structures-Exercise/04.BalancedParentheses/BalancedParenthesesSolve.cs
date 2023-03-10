namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var openBrackets = new Stack<char>();
            bool isBalanced = false;

            foreach (char bracket in parentheses)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    openBrackets.Push(bracket);
                }

                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    if (openBrackets.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char lastOpen = openBrackets.Pop();

                    if (lastOpen == '{' && bracket == '}')
                    {
                        isBalanced = true;
                    }

                    else if (lastOpen == '[' && bracket == ']')
                    {
                        isBalanced = true;
                    }

                    else if (lastOpen == '(' && bracket == ')')
                    {
                        isBalanced = true;
                    }

                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
    }

