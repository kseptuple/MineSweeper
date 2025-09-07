using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MineSweeper.Core
{
    public class MineFields
    {
        //Stopwatch sw = new Stopwatch();
        private MineCell[,] field;
        private int width;
        public int Width { get => width; set => width = value < 1 ? 1 : value; }

        private int height;
        public int Height { get => height; set => height = value < 1 ? 1 : value; }

        private bool allowMark;
        public bool AllowMark { get => allowMark; set => allowMark = value; }

        private bool allowFlag;
        public bool AllowFlag { get => allowFlag; set => allowFlag = value; }

        //private Queue<(int, int)> cellsToOpen = new Queue<(int, int)>();

        public int FieldSize
        {
            get
            {
                return width * height;
            }
        }

        private int mineNumbers;

        public int MineNumbers
        {
            get
            {
                return mineNumbers;
            }
            set
            {
                if (value > FieldSize) value = FieldSize;
                mineNumbers = value;
            }
        }

        public bool IsLost { get; set; }

        public bool IsWin { get; set; }

        public FirstClickType FirstClickProtection { get; set; }

        public int FlagsRemain { get; set; }
        public bool IsFirstClick { get; set; }
        public bool IsRestartedGame { get; set; }

        //内部地雷列表
        private int[] mineList = null;

        //当前正在设置地雷列表中哪个位置的地雷
        private int currentMinePos = 0;

        //多少个没有雷的格子
        public int cellLeft = 0;

        Random rng = null;

        public MineFields(int width, int height, int mineNumbers)
        {
            Width = width;
            Height = height;
            MineNumbers = mineNumbers;
            field = new MineCell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = new MineCell();
                }
            }

            currentMinePos = FieldSize - 1;
            mineList = new int[currentMinePos + 1];
            for (int i = 0; i < mineList.Length; i++)
            {
                mineList[i] = i;
            }

            rng = new Random();
            int temp = 0;
            for (int i = 0; i < mineNumbers; i++)
            {
                if (currentMinePos == 0)
                {
                    getMineCell(mineList[currentMinePos]).HasMine = true;
                    break;
                }
                //get a random position with no mine, and set a mine
                int mineCellId = rng.Next(currentMinePos);
                temp = mineList[currentMinePos];
                mineList[currentMinePos] = mineList[mineCellId];
                mineList[mineCellId] = temp;
                getMineCell(mineList[currentMinePos]).HasMine = true;
                currentMinePos--;
            }
            //now last few numbers in mineList[] has mine, others are not
            for (int i = 0; i < FieldSize; i++)
            {
                setMineCount(i);
            }
            IsFirstClick = true;
            IsLost = false;
            IsWin = false;
            IsRestartedGame = false;
            FlagsRemain = mineNumbers;
            cellLeft = FieldSize - mineNumbers;
        }

        //calculate how many mines a around the cell
        private void setMineCount(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return;
            short mineCount = 0;
            if (xPos > 0)
            {
                if (field[xPos - 1, yPos].HasMine) mineCount++;
                if (yPos > 0)
                {
                    if (field[xPos - 1, yPos - 1].HasMine) mineCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos - 1, yPos + 1].HasMine) mineCount++;
                }
            }
            if (xPos < width - 1)
            {
                if (field[xPos + 1, yPos].HasMine) mineCount++;
                if (yPos > 0)
                {
                    if (field[xPos + 1, yPos - 1].HasMine) mineCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos + 1, yPos + 1].HasMine) mineCount++;
                }
            }
            if (yPos > 0)
            {
                if (field[xPos, yPos - 1].HasMine) mineCount++;
            }
            if (yPos < height - 1)
            {
                if (field[xPos, yPos + 1].HasMine) mineCount++;
            }
            field[xPos, yPos].MineNum = mineCount;
        }

        private void setMineCount(int position)
        {
            int xPos = position / height;
            int yPos = position % height;
            setMineCount(xPos, yPos);
        }

        private void set9CellsMineCount(int xPos, int yPos)
        {
            Helper.CallFor9Cells(setMineCount, xPos, yPos);
        }

        private void set9CellsMineCount(int position)
        {
            int xPos = position / height;
            int yPos = position % height;
            set9CellsMineCount(xPos, yPos);
        }

        public MineCell getMineCell(int xPos, int yPos)
        {
            return field[xPos, yPos];
        }

        private MineCell getMineCell(int position)
        {
            int xPos = position / height;
            int yPos = position % height;
            return field[xPos, yPos];
        }

        public void openMine(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return;
            MineCell cell = field[xPos, yPos];
            if (cell.State != CellState.Unopened && cell.State != CellState.Marked) return;
            if (IsFirstClick)
            {
                if (!IsRestartedGame)
                {
                    switch (FirstClickProtection)
                    {
                        case FirstClickType.NoProtection:
                            break;
                        case FirstClickType.Protection:
                            if (field[xPos, yPos].HasMine)
                            {
                                if (currentMinePos == 0 && getMineCell(mineList[currentMinePos]).HasMine) break;
                                //find another safe cell to swap
                                int mineCellId = rng.Next(currentMinePos);
                                int temp = mineList[currentMinePos];
                                mineList[currentMinePos] = mineList[mineCellId];
                                mineList[mineCellId] = temp;

                                getMineCell(mineList[currentMinePos]).HasMine = true;
                                field[xPos, yPos].HasMine = false;
                                //recalculate
                                set9CellsMineCount(mineList[currentMinePos]);
                                set9CellsMineCount(xPos, yPos);
                            }
                            break;
                        case FirstClickType.Open:
                            if (field[xPos, yPos].HasMine || field[xPos, yPos].MineNum > 0)
                            {
                                freeMineForOpen(xPos, yPos);
                            }
                            break;
                        default:
                            break;
                    }
                }
                IsFirstClick = false;
            }
            //lose
            if (cell.HasMine && !IsLost)
            {
                foreach (var mineCell in field)
                {
                    if (mineCell.HasMine && mineCell.State != CellState.Flagged ||
                        !mineCell.HasMine && mineCell.State == CellState.Flagged)
                    {
                        mineCell.State = CellState.OpenedByExplosion;
                    }
                }
                IsLost = true;
            }
            else
            {
                if (cell.MineNum == 0)
                {
                    //addCellToQueue(xPos, yPos);
                    //batchOpenMine();
                    openMineRecursion(xPos, yPos);
                }
            }
            if (cell.State != CellState.Opened)
            {
                cell.State = CellState.Opened;
                cellLeft--;
            }
            //win
            if (cellLeft == 0 && !IsLost)
            {
                foreach (var mineCell in field)
                {
                    if (mineCell.HasMine &&
                        (mineCell.State == CellState.Unopened || mineCell.State == CellState.Marked))
                    {
                        mineCell.State = CellState.Flagged;
                    }
                }
                FlagsRemain = 0;
                IsWin = true;
            }
        }

        //开局打开一片的模式
        private void freeMineForOpen(int xPos, int yPos)
        {
            freeMine(xPos, yPos, xPos, yPos);
            if (xPos > 0)
            {
                freeMine(xPos - 1, yPos, xPos, yPos);
                if (yPos > 0)
                {
                    freeMine(xPos - 1, yPos - 1, xPos, yPos);
                }
                if (yPos < height - 1)
                {
                    freeMine(xPos - 1, yPos + 1, xPos, yPos);
                }
            }
            if (xPos < width - 1)
            {
                freeMine(xPos + 1, yPos, xPos, yPos);
                if (yPos > 0)
                {
                    freeMine(xPos + 1, yPos - 1, xPos, yPos);
                }
                if (yPos < height - 1)
                {
                    freeMine(xPos + 1, yPos + 1, xPos, yPos);
                }
            }
            if (yPos > 0)
            {
                freeMine(xPos, yPos - 1, xPos, yPos);
            }
            if (yPos < height - 1)
            {
                freeMine(xPos, yPos + 1, xPos, yPos);
            }
        }

        //xCenter 和 yCenter 是玩家点击的位置
        private void freeMine(int xPos, int yPos, int xCenter, int yCenter)
        {
            if (!field[xPos, yPos].HasMine) return;
            if (currentMinePos < 0) return;
            //找一个没有雷的位置替换掉
            int mineCellId = rng.Next(currentMinePos);
            int temp = mineList[currentMinePos];
            mineList[currentMinePos] = mineList[mineCellId];
            mineList[mineCellId] = temp;

            int xTarget = mineList[currentMinePos] / height;
            int yTarget = mineList[currentMinePos] % height;
            //找到的位置恰好位于点击位置的周围8格，需要重新找
            while (xTarget >= xCenter - 1 && xTarget <= xCenter + 1 && yTarget >= yCenter - 1 && yTarget <= yCenter + 1 && currentMinePos > 0)
            {
                currentMinePos--;

                mineCellId = rng.Next(currentMinePos);
                temp = mineList[currentMinePos];
                mineList[currentMinePos] = mineList[mineCellId];
                mineList[mineCellId] = temp;

                xTarget = mineList[currentMinePos] / height;
                yTarget = mineList[currentMinePos] % height;
            }

            field[xTarget, yTarget].HasMine = true;
            field[xPos, yPos].HasMine = false;
            set9CellsMineCount(xTarget, yTarget);
            set9CellsMineCount(xPos, yPos);
            currentMinePos--;
        }

        private void openMineRecursion(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return;
            MineCell cell = field[xPos, yPos];
            if (cell.State == CellState.Opened || cell.State == CellState.Flagged) return;
            cell.State = CellState.Opened;
            cellLeft--;
            if (cell.MineNum == 0)
            {
                Helper.CallFor9Cells(openMineRecursion, xPos, yPos);
            }
        }


        //private void batchOpenMine()
        //{
        //    while (cellsToOpen.Count > 0)
        //    {
        //        var pos = cellsToOpen.Dequeue();
        //        var xPos = pos.Item1;
        //        var yPos = pos.Item2;
        //        if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) continue;
        //        MineCell cell = field[xPos, yPos];
        //        if (cell.State == CellState.Opened || cell.State == CellState.Flagged) continue;
        //        cell.State = CellState.Opened;
        //        cellLeft--;
        //        if (cell.MineNum == 0)
        //        {
        //            Helper.CallFor9Cells(addCellToQueue, xPos, yPos);
        //        }
        //    }
        //}

        //private void addCellToQueue(int xPos, int yPos)
        //{
        //    cellsToOpen.Enqueue((xPos, yPos));
        //}


        public void setFlag(int xPos, int yPos)
        {
            if (!allowFlag) return;
            MineCell cell = field[xPos, yPos];
            if (cell.State == CellState.Unopened)
            {
                cell.State = CellState.Flagged;
                FlagsRemain--;
            }
            else if (cell.State == CellState.Flagged)
            {
                if (AllowMark)
                    cell.State = CellState.Marked;
                else
                    cell.State = CellState.Unopened;
                FlagsRemain++;
            }
            else if (cell.State == CellState.Marked)
            {
                cell.State = CellState.Unopened;
            }
        }

        //used for auto open
        public short getSurroundingFlagCount(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return 0;
            short flagCount = 0;
            if (xPos > 0)
            {
                if (field[xPos - 1, yPos].State == CellState.Flagged) flagCount++;
                if (yPos > 0)
                {
                    if (field[xPos - 1, yPos - 1].State == CellState.Flagged) flagCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos - 1, yPos + 1].State == CellState.Flagged) flagCount++;
                }
            }
            if (xPos < width - 1)
            {
                if (field[xPos + 1, yPos].State == CellState.Flagged) flagCount++;
                if (yPos > 0)
                {
                    if (field[xPos + 1, yPos - 1].State == CellState.Flagged) flagCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos + 1, yPos + 1].State == CellState.Flagged) flagCount++;
                }
            }
            if (yPos > 0)
            {
                if (field[xPos, yPos - 1].State == CellState.Flagged) flagCount++;
            }
            if (yPos < height - 1)
            {
                if (field[xPos, yPos + 1].State == CellState.Flagged) flagCount++;
            }

            return flagCount;

        }

        public void RestartGame()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j].State = CellState.Unopened;
                }
            }
            IsFirstClick = true;
            IsLost = false;
            IsWin = false;
            IsRestartedGame = true;
            FlagsRemain = mineNumbers;
            cellLeft = FieldSize - mineNumbers;
        }

        public class MineCell
        {
            private bool hasMine;

            private short mineNum;

            private CellState state;

            public bool HasMine { get => hasMine; set => hasMine = value; }

            public short MineNum { get => mineNum; set => mineNum = value; }

            public CellState State { get => state; set => state = value; }

            public MineCell()
            {
                state = CellState.Unopened;
                hasMine = false;
            }

        }

        public enum CellState : byte
        {
            Unopened = 0,
            Opened = 1,
            Flagged = 2,
            Marked = 3,
            OpenedByExplosion = 4
        }

        public enum FirstClickType : byte
        {
            NoProtection = 0,
            Protection = 1,
            Open = 2
        }
    }

}
