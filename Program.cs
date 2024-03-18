using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine().ToUpper();
            List<char> textProc = new List<char> { };
            List<int> textNum = new List<int> { };
            char[] alphbet = new char[26] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            List<char> key = new List<char> { };
            List<int> keyNum = new List<int> { };
            List<int> ciphertextNum = new List<int> { };
            List<char> ciphertextLiter = new List<char> { };

            Dictionary<char, int> cipher = new Dictionary<char, int>
            {
                {'A',0}, {'B',1}, {'C',2}, {'D',3}, {'E',4}, {'F',5}, {'G',6}, {'H',7}, {'I',8}, {'J',9}, {'K',10}, {'L',11}, {'M',12}, {'N',13}, {'O',14}, {'P',15}, {'Q',16}, {'R',17}, {'S',18}, {'T',19}, {'U',20}, {'V',21}, {'W',22}, {'X',23}, {'Y',24}, {'Z',25}
            };
            Dictionary<int, char> deCipher = new Dictionary<int, char>
            {
                {0,'A'}, {1,'B'}, {2,'C'}, {3,'D'}, {4,'E'}, {5,'F'}, {6,'G'}, {7,'H'}, {8,'I'}, {9,'J'}, {10,'K'}, {11,'L'}, {12,'M'}, {13,'N'}, {14,'O'}, {15,'P'}, {16,'Q'}, {17,'R'}, {18,'S'}, {19,'T'}, {20,'U'}, {21,'V'}, {22,'W'}, {23,'X'}, {24,'Y'}, {25,'Z'}
            };

            for (int i = 0; i < text.Length; i++) //перебор текста и запись в словарь
            {
                if (text[i] != ' ' && text[i] != '\'' && text[i] != ',' && text[i] != '.' && text[i] != '!' && text[i] != '-' && text[i] != ':' && text[i] != ';' && text[i] != '?')
                {
                    textProc.Add(text[i]);
                }
            }
            foreach (char l in textProc) //перебор текста в цифры
            {
                foreach (char i in cipher.Keys)
                {
                    if (l == i)
                    {
                        textNum.Add(cipher[i]);
                    }
                }
            }
            
            for (int i = 0;i < textProc.Count; i++) //создание ключа
            {
                Random rd = new Random();
                int randomIndex = rd.Next(0, 26);
                char randomLiter = alphbet[randomIndex];
                key.Add(randomLiter);
            }
            foreach (char l in key) //перебор ключа в цифры
            {
                foreach (char i in cipher.Keys)
                {
                    if (l == i)
                    {
                        keyNum.Add(cipher[i]);
                    }
                }
            }
            
            for (int ex = 0; ex < textNum.Count; ex++) //шифрование и запись текста в числах
            {
                int cipherEx = keyNum[ex] + textNum[ex];
                if (cipherEx > 25)
                {
                    ciphertextNum.Add((keyNum[ex] + textNum[ex]) - 26);
                }
                else
                {
                    ciphertextNum.Add(keyNum[ex] + textNum[ex]);
                }
            }
            foreach (int ex in ciphertextNum) //перебор и запись шифротекста в буквах
            {
                foreach (int el in deCipher.Keys)
                {
                    if (ex == el)
                    {
                        ciphertextLiter.Add(deCipher[el]);
                    }
                }
            }

            string textRes = String.Concat(ciphertextLiter);
            string keyRes = String.Concat(key);

            Console.WriteLine($"\nВаш текст: {textRes}\n\nВаш ключ: {keyRes}");
            Console.Write("\nНажмите Enter для выхода...");
            Console.Read();
        }
    }
}
