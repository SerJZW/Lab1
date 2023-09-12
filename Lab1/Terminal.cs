using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Terminal
    {
        private List<string> lines;
        private int cursorUD;
        private int cursorLR;
        public Terminal()
        {
            lines = new List<string> { "" };
            cursorUD = 0;
            cursorLR = 0;
        }
        public void Logic(string input)
        {
            foreach (char ch in input)
            {
                switch (ch)
                {
                    case 'L':
                        MoveLeftCursor();
                        break;
                    case 'R':
                        MoveRightCursor();
                        break;
                    case 'U':
                        MoveUpCursor();
                        break;
                    case 'D':
                        MoveDownCursor();
                        break;
                    case 'B':
                        MoveStartCursor();
                        break;
                    case 'E':
                        MoveEndCursor();
                        break;
                    case 'N':
                        InsertNewline();
                        break;
                    default:
                        InsertCharacter(ch);
                        break;
                }
            }
        }
        public void MoveLeftCursor()
        {
            if (cursorLR > 0)
            {
                cursorLR--;
            }
        }
         public void MoveRightCursor()
        {
            string line = lines[cursorUD];
            if (cursorLR < line.Length)
            {
                cursorLR++;
            }
        }
        public void MoveUpCursor()
        {
            if (cursorUD > 0)
            {
                cursorUD--;
            }
        }
        public void MoveDownCursor()
        {
            if (cursorUD < lines.Count - 1)
            {
                cursorUD++;
            }
        }
        public void MoveStartCursor()
        {
            cursorLR = 0;
        }
        public void MoveEndCursor()
        {
            string line = lines[cursorUD];
            cursorLR = line.Length;
        }
        public void InsertNewline()
        {
            string line = lines[cursorUD];
            string newLine = line.Substring(cursorLR);
            lines[cursorUD] = line.Substring(0, cursorLR);
            lines.Insert(cursorUD + 1, newLine);
            cursorUD++;
            cursorLR = 0;
        }
        void InsertCharacter(char ch)
        {
            string line = lines[cursorUD];
            line = line.Insert(cursorLR, ch.ToString());
            cursorLR++;
            lines[cursorUD] = line;
        }
        public string GetTerminalState()
        {
            return string.Join("\n", lines);
        }
    }
}
