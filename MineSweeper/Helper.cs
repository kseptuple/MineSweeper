using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class Helper
    {
        public static void CallFor9Cells(Action<int,int> action, int x, int y)
        {
            action(x - 1, y - 1);
            action(x - 1, y);
            action(x - 1, y + 1);
            action(x, y - 1);
            action(x, y);
            action(x, y + 1);
            action(x + 1, y - 1);
            action(x + 1, y);
            action(x + 1, y + 1);
        }
    }
}
