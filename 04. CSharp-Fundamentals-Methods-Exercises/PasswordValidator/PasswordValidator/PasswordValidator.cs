using System;

namespace PasswordValidator
{
    class PasswordValidator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PaswordValidator(password);
        }

        static bool IsNeededPaswwordLenght(string password) 
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            return false;
        }
        static bool IsTwoDigitPasswordCheck(string password)
        {
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                for (int num = 0; num < 10; num++)
                {
                    if (password[i].ToString() == num.ToString())
                    {
                        counter++;
                    }

                    if (counter == 2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool IsOnlyDigitAndLetters(string password)
        {
            string testPass = password.ToLower();

            for (int i = 0; i < password.Length; i++)
            {
                if (testPass[i] >= 'a' && testPass[i] <= 'z' || testPass[i] >= '0' && testPass[i] <= '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        static void PaswordValidator(string password) 
        {
            string message = string.Empty;

            if (!IsNeededPaswwordLenght(password))
            {
                message += "Password must be between 6 and 10 characters\n";
            }

            if (!IsOnlyDigitAndLetters(password))
            {
                message += "Password must consist only of letters and digits\n";
            }

            if (!IsTwoDigitPasswordCheck(password))
            {
                message += "Password must have at least 2 digits\n";
            }

            if (message == string.Empty)
            {
                message = "Password is valid\n";
            }

            Console.Write(message);
        }

    }
}
