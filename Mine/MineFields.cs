using System;

namespace Mine
{
    public class MineFields
    {

        private MineGrid[,] field;
        private int width;
        public int Width { get => width; set => width = value < 1 ? 1 : value; }

        private int height;
        public int Height { get => height; set => height = value < 1 ? 1 : value; }

        private bool allowMark;
        public bool AllowMark { get => allowMark; set => allowMark = value; }

        private bool allowFlag;
        public bool AllowFlag { get => allowFlag; set => allowFlag = value; }

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

        //inner presentation of minefield positions
        private int[] mineList = null;

        //current position used for setting mines
        private int max = 0;

        //grid number with no mines
        public int gridLeft = 0;

        Random rng = null;

        public MineFields(int width, int height, int mineNumbers)
        {
            Width = width;
            Height = height;
            MineNumbers = mineNumbers;
            field = new MineGrid[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = new MineGrid();
                }
            }

            max = FieldSize - 1;
            mineList = new int[max + 1];
            for (int i = 0; i < mineList.Length; i++)
            {
                mineList[i] = i;
            }

            rng = new Random();
            int temp = 0;
            for (int i = 0; i < mineNumbers; i++)
            {
                if (max == 0)
                {
                    getMineGrid(mineList[max]).HasMine = true;
                    break;
                }
                //get a random position with no mine, and set a mine
                int mineGridId = rng.Next(max);
                temp = mineList[max];
                mineList[max] = mineList[mineGridId];
                mineList[mineGridId] = temp;
                getMineGrid(mineList[max]).HasMine = true;
                max--;
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
            gridLeft = FieldSize - mineNumbers;
        }

        //calculate how many mines a around the grid
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

        private void set9GridsMineCount(int xPos, int yPos)
        {
            setMineCount(xPos - 1, yPos - 1);
            setMineCount(xPos - 1, yPos);
            setMineCount(xPos - 1, yPos + 1);
            setMineCount(xPos, yPos - 1);
            setMineCount(xPos, yPos);
            setMineCount(xPos, yPos + 1);
            setMineCount(xPos + 1, yPos - 1);
            setMineCount(xPos + 1, yPos);
            setMineCount(xPos + 1, yPos + 1);
        }

        private void set9GridsMineCount(int position)
        {
            int xPos = position / height;
            int yPos = position % height;
            set9GridsMineCount(xPos, yPos);
        }

        public MineGrid getMineGrid(int xPos, int yPos)
        {
            return field[xPos, yPos];
        }

        private MineGrid getMineGrid(int position)
        {
            int xPos = position / height;
            int yPos = position % height;
            return field[xPos, yPos];
        }

        public void openMine(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return;
            MineGrid grid = field[xPos, yPos];
            if (grid.State != MineFields.GridState.Unopened && grid.State != MineFields.GridState.Marked) return;
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
                                if (max == 0 && getMineGrid(mineList[max]).HasMine) break;
                                //find another safe grid to swap
                                int mineGridId = rng.Next(max);
                                int temp = mineList[max];
                                mineList[max] = mineList[mineGridId];
                                mineList[mineGridId] = temp;
                                
                                getMineGrid(mineList[max]).HasMine = true;
                                field[xPos, yPos].HasMine = false;
                                //recalculate
                                set9GridsMineCount(mineList[max]);
                                set9GridsMineCount(xPos, yPos);
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
            if (grid.HasMine && !IsLost)
            {
                foreach (var mineGrid in field)
                {
                    if ((mineGrid.HasMine && mineGrid.State != GridState.Flagged) ||
                        (!mineGrid.HasMine && mineGrid.State == GridState.Flagged))
                    {
                        mineGrid.State = GridState.OpenedByExplosion;
                    }
                }
                IsLost = true;
            }
            else
            {
                if (grid.MineNum == 0) openMineRecursion(xPos, yPos);
            }
            if (grid.State != GridState.Opened)
            {
                grid.State = GridState.Opened;
                gridLeft--;
            }
            //win
            if (gridLeft == 0 && !IsLost)
            {
                foreach (var mineGrid in field)
                {
                    if (mineGrid.HasMine &&
                        (mineGrid.State == GridState.Unopened || mineGrid.State == GridState.Marked))
                    {
                        mineGrid.State = GridState.Flagged;
                    }
                }
                FlagsRemain = 0;
                IsWin = true;
            }
        }

        private void freeMineForOpen(int xPos, int yPos)
        {
            if (field[xPos, yPos].HasMine) freeMine(xPos, yPos, xPos, yPos);
            if (xPos > 0)
            {
                if (field[xPos - 1, yPos].HasMine) freeMine(xPos - 1, yPos, xPos, yPos);
                if (yPos > 0)
                {
                    if (field[xPos - 1, yPos - 1].HasMine) freeMine(xPos - 1, yPos - 1, xPos, yPos);
                }
                if (yPos < height - 1)
                {
                    if (field[xPos - 1, yPos + 1].HasMine) freeMine(xPos - 1, yPos + 1, xPos, yPos);
                }
            }
            if (xPos < width - 1)
            {
                if (field[xPos + 1, yPos].HasMine) freeMine(xPos + 1, yPos, xPos, yPos);
                if (yPos > 0)
                {
                    if (field[xPos + 1, yPos - 1].HasMine) freeMine(xPos + 1, yPos - 1, xPos, yPos);
                }
                if (yPos < height - 1)
                {
                    if (field[xPos + 1, yPos + 1].HasMine) freeMine(xPos + 1, yPos + 1, xPos, yPos);
                }
            }
            if (yPos > 0)
            {
                if (field[xPos, yPos - 1].HasMine) freeMine(xPos, yPos - 1, xPos, yPos);
            }
            if (yPos < height - 1)
            {
                if (field[xPos, yPos + 1].HasMine) freeMine(xPos, yPos + 1, xPos, yPos);
            }
        }

        //xCenter and yCenter is where player clicked
        private void freeMine(int xPos, int yPos, int xCenter, int yCenter)
        {
            if (max < 0) return;
            //find another safe grid to swap
            int mineGridId = rng.Next(max);
            int temp = mineList[max];
            mineList[max] = mineList[mineGridId];
            mineList[mineGridId] = temp;

            int xTarget = mineList[max] / height;
            int yTarget = mineList[max] % height;
            //the safe gird happens to be in the 9 grids around/at where the player clicked
            while (xTarget >= xCenter - 1 && xTarget <= xCenter + 1 && yTarget >= yCenter - 1 && yTarget <= yCenter + 1 && max > 0)
            {
                max--;

                mineGridId = rng.Next(max);
                temp = mineList[max];
                mineList[max] = mineList[mineGridId];
                mineList[mineGridId] = temp;

                xTarget = mineList[max] / height;
                yTarget = mineList[max] % height;
            }

            field[xTarget, yTarget].HasMine = true;
            field[xPos, yPos].HasMine = false;
            set9GridsMineCount(xTarget, yTarget);
            set9GridsMineCount(xPos, yPos);
            max--;
        }

        private void openMineRecursion(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return;
            MineGrid grid = field[xPos, yPos];
            if (grid.State == GridState.Opened || grid.State == GridState.Flagged) return;
            grid.State = GridState.Opened;
            gridLeft--;
            if (grid.MineNum == 0)
            {
                openMineRecursion(xPos - 1, yPos - 1);
                openMineRecursion(xPos - 1, yPos);
                openMineRecursion(xPos - 1, yPos + 1);
                openMineRecursion(xPos, yPos - 1);
                openMineRecursion(xPos, yPos + 1);
                openMineRecursion(xPos + 1, yPos - 1);
                openMineRecursion(xPos + 1, yPos);
                openMineRecursion(xPos + 1, yPos + 1);
            }
        }

        public void setFlag(int xPos, int yPos)
        {
            if (!allowFlag) return;
            MineGrid grid = field[xPos, yPos];
            if (grid.State == GridState.Unopened)
            {
                grid.State = GridState.Flagged;
                FlagsRemain--;
            }
            else if (grid.State == GridState.Flagged)
            {
                if (AllowMark)
                    grid.State = GridState.Marked;
                else
                    grid.State = GridState.Unopened;
                FlagsRemain++;
            }
            else if (grid.State == GridState.Marked)
            {
                grid.State = GridState.Unopened;
            }
        }

        //used for auto open
        public short getSurroundingFlagCount(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos >= width || yPos >= height) return 0;
            short flagCount = 0;
            if (xPos > 0)
            {
                if (field[xPos - 1, yPos].State == GridState.Flagged) flagCount++;
                if (yPos > 0)
                {
                    if (field[xPos - 1, yPos - 1].State == GridState.Flagged) flagCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos - 1, yPos + 1].State == GridState.Flagged) flagCount++;
                }
            }
            if (xPos < width - 1)
            {
                if (field[xPos + 1, yPos].State == GridState.Flagged) flagCount++;
                if (yPos > 0)
                {
                    if (field[xPos + 1, yPos - 1].State == GridState.Flagged) flagCount++;
                }
                if (yPos < height - 1)
                {
                    if (field[xPos + 1, yPos + 1].State == GridState.Flagged) flagCount++;
                }
            }
            if (yPos > 0)
            {
                if (field[xPos, yPos - 1].State == GridState.Flagged) flagCount++;
            }
            if (yPos < height - 1)
            {
                if (field[xPos, yPos + 1].State == GridState.Flagged) flagCount++;
            }

            return flagCount;

        }

        public void RestartGame()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j].State = GridState.Unopened;
                }
            }
            IsFirstClick = true;
            IsLost = false;
            IsWin = false;
            IsRestartedGame = true;
            FlagsRemain = mineNumbers;
            gridLeft = FieldSize - mineNumbers;
        }

        public class MineGrid
        {
            private bool hasMine;

            private short mineNum;

            private GridState state;

            public bool HasMine { get => hasMine; set => hasMine = value; }

            public short MineNum { get => mineNum; set => mineNum = value; }

            public GridState State { get => state; set => state = value; }

            public MineGrid()
            {
                state = GridState.Unopened;
                hasMine = false;
            }

        }

        public enum GridState : byte
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
