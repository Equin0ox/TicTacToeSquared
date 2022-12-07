namespace tictactoeNaDruhou
{
    internal class CoolClass
    {
        public string player1 = "";
        public string player2 = "";
        public int LastRow = -1;
        public int LastCol = -1;
        public int AvalaibleRowMin = 0;
        public int AvalaibleColMin = 0;
        public int AvalaibleRowMax = 8;
        public int AvalaibleColMax = 8;
        string[,] BigBoard = new string[3, 3];
        public void Run()
        {
            string[,] board = new string[9, 9];
            int rows = 9;
            int columns = 9;

            SetupGame(board, rows, columns);
            Printboard(board, rows, columns);

            string a = "a";

            while (a == "a")
            {
                PlayGamePlayer(board, player1);
                GameOver(board, player1);
                Printboard(board, rows, columns);
                PlayGamePlayer(board, player2);
                GameOver(board, player2);
                Printboard(board, rows, columns);
            }
        }
        public void SetupGame(string[,] board, int rows, int columns)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    board[i, j] = ".";
                }
            }

            while (player1.ToCharArray().Length != 1)
            {
                Console.WriteLine("player 1 choose a single character");
                player1 = Console.ReadLine();
            }

            while (player2.ToCharArray().Length != 1 || player2 == player1)
            {
                Console.WriteLine("player 2 choose a single character diffrent to player 1");
                player2 = Console.ReadLine();
            }
        }
        public void Printboard(string[,] board, int rows, int columns)
        {
            for (var i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if (k % 3 == 1 && k != 1)
                            {
                                Console.Write("|");
                            }
                            Console.Write(k);
                        }
                        Console.WriteLine();
                    }
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("|");
                    }
                    if (i % 3 == 0 && j == 0 && i != 0)
                    {
                        for (int k = 0; k < 11; k++)
                        {
                            if ((k % 4) - 3 == 0 && k != 0)
                            {
                                Console.Write("+");
                            }
                            else
                            {
                                Console.Write("-");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.Write(board[i, j]);
                }
                Console.WriteLine(i + 1);
            }
        }
        public void PlayGamePlayer(string[,] board, string player)
        {
            int playerRow = -5;
            while (playerRow < 0 || playerRow > 9)
            {
                Console.WriteLine($"player {player} choose a row ({AvalaibleRowMin + 1} - {AvalaibleRowMax + 1}):");
                playerRow = SafelyConvertToInt(Console.ReadLine()) - 1;
            }
            int playerColumn = -5;
            while (playerColumn < 0 || playerColumn > 9)
            {
                Console.WriteLine($"player {player} choose a column ({AvalaibleColMin + 1} - {AvalaibleColMax + 1}):");
                playerColumn = SafelyConvertToInt(Console.ReadLine()) - 1;
            }
            if (CheckforCorrectSquare(playerRow, playerColumn))
            {
                if (CheckForPosition(board, playerRow, playerColumn))
                {
                    SetPosition(board, playerRow, playerColumn, player);
                    GameOver(board, player);
                }
                else
                {
                    PlayGamePlayer(board, player);
                }
            }
            else
            {
                PlayGamePlayer(board, player);
            }
        }
        public bool CheckforCorrectSquare(int playerRow, int playerColumn)
        {
            if ((LastRow == -1) || (((AvalaibleRowMin <= playerRow) && (AvalaibleRowMax >= playerRow)) && ((AvalaibleColMin <= playerColumn) && (AvalaibleColMax >= playerColumn))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckForPosition(string[,] board, int playerRow, int playerColumn)
        {
            if (board[playerRow, playerColumn] == ".")
            {
                Console.WriteLine("position avalaible");
                AvalaibleRowMin = playerRow % 3 * 3;
                AvalaibleRowMax = playerRow % 3 * 3 + 2;
                AvalaibleColMin = playerColumn % 3 * 3;
                AvalaibleColMax = playerColumn % 3 * 3 + 2;
                if (BigBoard[playerRow % 3, playerColumn % 3] != null)
                {
                    AvalaibleRowMin = 0;
                    AvalaibleRowMax = 8;
                    AvalaibleColMin = 0;
                    AvalaibleColMax = 8;
                }
                return true;
            }
            else
            {
                Console.WriteLine("position taken");
                return false;
            }
        }
        public void SetPosition(string[,] board, int playerRow, int playerColumn, string player)
        {
            board[playerRow, playerColumn] = player;
            LastRow = playerRow;
            LastCol = playerColumn;
        }
        public /*bool*/ void GameOver(string[,] board, string player)
        {
            string TopRow1 = board[0, 0] + board[0, 1] + board[0, 2];
            string MidRow1 = board[1, 0] + board[1, 1] + board[1, 2];
            string BotRow1 = board[2, 0] + board[2, 1] + board[2, 2];
            string FirCol1 = board[0, 0] + board[1, 0] + board[2, 0];
            string SecCol1 = board[0, 1] + board[1, 1] + board[2, 1];
            string ThiCol1 = board[0, 2] + board[1, 2] + board[2, 2];
            string Diagon1 = board[0, 0] + board[1, 1] + board[2, 2];
            string RevDia1 = board[0, 2] + board[1, 1] + board[2, 0];

            string TopRow2 = board[0, 3] + board[0, 4] + board[0, 5];
            string MidRow2 = board[1, 3] + board[1, 4] + board[1, 5];
            string BotRow2 = board[2, 3] + board[2, 4] + board[2, 5];
            string FirCol2 = board[0, 3] + board[1, 3] + board[2, 3];
            string SecCol2 = board[0, 4] + board[1, 4] + board[2, 4];
            string ThiCol2 = board[0, 5] + board[1, 5] + board[2, 5];
            string Diagon2 = board[0, 3] + board[1, 4] + board[2, 5];
            string RevDia2 = board[2, 3] + board[1, 4] + board[0, 5];

            string TopRow3 = board[0, 6] + board[0, 7] + board[0, 8];
            string MidRow3 = board[1, 6] + board[1, 7] + board[1, 8];
            string BotRow3 = board[2, 6] + board[2, 7] + board[2, 8];
            string FirCol3 = board[0, 6] + board[1, 6] + board[2, 6];
            string SecCol3 = board[0, 7] + board[1, 7] + board[2, 7];
            string ThiCol3 = board[0, 8] + board[1, 8] + board[2, 8];
            string Diagon3 = board[0, 6] + board[1, 7] + board[2, 8];
            string RevDia3 = board[2, 6] + board[1, 7] + board[0, 8];

            string TopRow4 = board[3, 0] + board[3, 1] + board[3, 2];
            string MidRow4 = board[4, 0] + board[4, 1] + board[4, 2];
            string BotRow4 = board[5, 0] + board[5, 1] + board[5, 2];
            string FirCol4 = board[3, 0] + board[4, 0] + board[5, 0];
            string SecCol4 = board[3, 1] + board[4, 1] + board[5, 1];
            string ThiCol4 = board[3, 2] + board[4, 2] + board[5, 2];
            string Diagon4 = board[3, 0] + board[4, 1] + board[5, 2];
            string RevDia4 = board[5, 0] + board[4, 1] + board[3, 2];

            string TopRow5 = board[3, 3] + board[3, 4] + board[3, 5];
            string MidRow5 = board[4, 3] + board[4, 4] + board[4, 5];
            string BotRow5 = board[5, 3] + board[5, 4] + board[5, 5];
            string FirCol5 = board[3, 3] + board[4, 3] + board[5, 3];
            string SecCol5 = board[3, 4] + board[4, 4] + board[5, 4];
            string ThiCol5 = board[3, 5] + board[4, 5] + board[5, 5];
            string Diagon5 = board[3, 3] + board[4, 4] + board[5, 5];
            string RevDia5 = board[5, 3] + board[4, 4] + board[3, 5];

            string TopRow6 = board[3, 6] + board[3, 7] + board[3, 8];
            string MidRow6 = board[4, 6] + board[4, 7] + board[4, 8];
            string BotRow6 = board[5, 6] + board[5, 7] + board[5, 8];
            string FirCol6 = board[3, 6] + board[4, 6] + board[5, 6];
            string SecCol6 = board[3, 7] + board[4, 7] + board[5, 7];
            string ThiCol6 = board[3, 8] + board[4, 8] + board[5, 8];
            string Diagon6 = board[3, 6] + board[4, 7] + board[5, 8];
            string RevDia6 = board[5, 6] + board[4, 7] + board[3, 8];

            string TopRow7 = board[6, 0] + board[6, 1] + board[6, 2];
            string MidRow7 = board[7, 0] + board[7, 1] + board[7, 2];
            string BotRow7 = board[8, 0] + board[8, 1] + board[8, 2];
            string FirCol7 = board[6, 0] + board[7, 0] + board[8, 0];
            string SecCol7 = board[6, 1] + board[7, 1] + board[8, 1];
            string ThiCol7 = board[6, 2] + board[7, 2] + board[8, 2];
            string Diagon7 = board[6, 0] + board[7, 1] + board[8, 2];
            string RevDia7 = board[8, 0] + board[7, 1] + board[6, 2];

            string TopRow8 = board[6, 3] + board[6, 4] + board[6, 5];
            string MidRow8 = board[7, 3] + board[7, 4] + board[7, 5];
            string BotRow8 = board[8, 3] + board[8, 4] + board[8, 5];
            string FirCol8 = board[6, 3] + board[7, 3] + board[8, 3];
            string SecCol8 = board[6, 4] + board[7, 4] + board[8, 4];
            string ThiCol8 = board[6, 5] + board[7, 5] + board[8, 5];
            string Diagon8 = board[6, 3] + board[7, 4] + board[8, 5];
            string RevDia8 = board[8, 3] + board[7, 4] + board[6, 5];

            string TopRow9 = board[6, 6] + board[6, 7] + board[6, 8];
            string MidRow9 = board[7, 6] + board[7, 7] + board[7, 8];
            string BotRow9 = board[8, 6] + board[8, 7] + board[8, 8];
            string FirCol9 = board[6, 6] + board[7, 6] + board[8, 6];
            string SecCol9 = board[6, 7] + board[7, 7] + board[8, 7];
            string ThiCol9 = board[6, 8] + board[7, 8] + board[8, 8];
            string Diagon9 = board[6, 6] + board[7, 7] + board[8, 8];
            string RevDia9 = board[8, 6] + board[7, 7] + board[6, 8];

            string playerTriple = player + player + player;

            if (TopRow1.Equals(playerTriple)
                || MidRow1.Equals(playerTriple)
                || BotRow1.Equals(playerTriple)
                || FirCol1.Equals(playerTriple)
                || SecCol1.Equals(playerTriple)
                || ThiCol1.Equals(playerTriple)
                || Diagon1.Equals(playerTriple)
                || RevDia1.Equals(playerTriple)
            )
            {
                BigBoard[0, 0] = player;
                board[0, 0] = player;
                board[0, 1] = player;
                board[0, 2] = player;
                board[1, 0] = player;
                board[1, 1] = player;
                board[1, 2] = player;
                board[2, 0] = player;
                board[2, 1] = player;
                board[2, 2] = player;
            }
            if (TopRow2.Equals(playerTriple)
                            || MidRow2.Equals(playerTriple)
                            || BotRow2.Equals(playerTriple)
                            || FirCol2.Equals(playerTriple)
                            || SecCol2.Equals(playerTriple)
                            || ThiCol2.Equals(playerTriple)
                            || Diagon2.Equals(playerTriple)
                            || RevDia2.Equals(playerTriple)
                        )
            {
                BigBoard[0, 1] = player;
                board[0, 3] = player;
                board[0, 4] = player;
                board[0, 5] = player;
                board[1, 3] = player;
                board[1, 4] = player;
                board[1, 5] = player;
                board[2, 3] = player;
                board[2, 4] = player;
                board[2, 5] = player;
            }
            if (TopRow3.Equals(playerTriple)
                            || MidRow3.Equals(playerTriple)
                            || BotRow3.Equals(playerTriple)
                            || FirCol3.Equals(playerTriple)
                            || SecCol3.Equals(playerTriple)
                            || ThiCol3.Equals(playerTriple)
                            || Diagon3.Equals(playerTriple)
                            || RevDia3.Equals(playerTriple)
                        )
            {
                BigBoard[0, 2] = player;
                board[0, 6] = player;
                board[0, 7] = player;
                board[0, 8] = player;
                board[1, 6] = player;
                board[1, 7] = player;
                board[1, 8] = player;
                board[2, 6] = player;
                board[2, 7] = player;
                board[2, 8] = player;
            }
            if (TopRow4.Equals(playerTriple)
                            || MidRow4.Equals(playerTriple)
                            || BotRow4.Equals(playerTriple)
                            || FirCol4.Equals(playerTriple)
                            || SecCol4.Equals(playerTriple)
                            || ThiCol4.Equals(playerTriple)
                            || Diagon4.Equals(playerTriple)
                            || RevDia4.Equals(playerTriple)
                        )
            {
                BigBoard[1, 0] = player;
                board[3, 0] = player;
                board[3, 1] = player;
                board[3, 2] = player;
                board[4, 0] = player;
                board[4, 1] = player;
                board[4, 2] = player;
                board[5, 0] = player;
                board[5, 1] = player;
                board[5, 2] = player;
            }
            if (TopRow5.Equals(playerTriple)
                            || MidRow5.Equals(playerTriple)
                            || BotRow5.Equals(playerTriple)
                            || FirCol5.Equals(playerTriple)
                            || SecCol5.Equals(playerTriple)
                            || ThiCol5.Equals(playerTriple)
                            || Diagon5.Equals(playerTriple)
                            || RevDia5.Equals(playerTriple)
                        )
            {
                BigBoard[1, 1] = player;
                board[3, 3] = player;
                board[3, 4] = player;
                board[3, 5] = player;
                board[4, 3] = player;
                board[4, 4] = player;
                board[4, 5] = player;
                board[5, 3] = player;
                board[5, 4] = player;
                board[5, 5] = player;
            }
            if (TopRow6.Equals(playerTriple)
                            || MidRow6.Equals(playerTriple)
                            || BotRow6.Equals(playerTriple)
                            || FirCol6.Equals(playerTriple)
                            || SecCol6.Equals(playerTriple)
                            || ThiCol6.Equals(playerTriple)
                            || Diagon6.Equals(playerTriple)
                            || RevDia6.Equals(playerTriple)
                        )
            {
                BigBoard[1, 2] = player;
                board[3, 6] = player;
                board[3, 7] = player;
                board[3, 8] = player;
                board[4, 6] = player;
                board[4, 7] = player;
                board[4, 8] = player;
                board[5, 6] = player;
                board[5, 7] = player;
                board[5, 8] = player;
            }
            if (TopRow7.Equals(playerTriple)
                            || MidRow7.Equals(playerTriple)
                            || BotRow7.Equals(playerTriple)
                            || FirCol7.Equals(playerTriple)
                            || SecCol7.Equals(playerTriple)
                            || ThiCol7.Equals(playerTriple)
                            || Diagon7.Equals(playerTriple)
                            || RevDia7.Equals(playerTriple)
                        )
            {
                BigBoard[2, 0] = player;
                board[6, 0] = player;
                board[6, 1] = player;
                board[6, 2] = player;
                board[7, 0] = player;
                board[7, 1] = player;
                board[7, 2] = player;
                board[8, 0] = player;
                board[8, 1] = player;
                board[8, 2] = player;
            }
            if (TopRow8.Equals(playerTriple)
                            || MidRow8.Equals(playerTriple)
                            || BotRow8.Equals(playerTriple)
                            || FirCol8.Equals(playerTriple)
                            || SecCol8.Equals(playerTriple)
                            || ThiCol8.Equals(playerTriple)
                            || Diagon8.Equals(playerTriple)
                            || RevDia8.Equals(playerTriple)
                        )
            {
                BigBoard[2, 1] = player;
                board[6, 3] = player;
                board[6, 4] = player;
                board[6, 5] = player;
                board[7, 3] = player;
                board[7, 4] = player;
                board[7, 5] = player;
                board[8, 3] = player;
                board[8, 4] = player;
                board[8, 5] = player;
            }
            if (TopRow9.Equals(playerTriple)
                            || MidRow9.Equals(playerTriple)
                            || BotRow9.Equals(playerTriple)
                            || FirCol9.Equals(playerTriple)
                            || SecCol9.Equals(playerTriple)
                            || ThiCol9.Equals(playerTriple)
                            || Diagon9.Equals(playerTriple)
                            || RevDia9.Equals(playerTriple)
                        )
            {
                BigBoard[2, 2] = player;
                board[6, 6] = player;
                board[6, 7] = player;
                board[6, 8] = player;
                board[7, 6] = player;
                board[7, 7] = player;
                board[7, 8] = player;
                board[8, 6] = player;
                board[8, 7] = player;
                board[8, 8] = player;
            }
            string TopRow = BigBoard[0, 0] + BigBoard[0, 1] + BigBoard[0, 2];
            string MidRow = BigBoard[1, 0] + BigBoard[1, 1] + BigBoard[1, 2];
            string BotRow = BigBoard[2, 0] + BigBoard[2, 1] + BigBoard[2, 2];
            string FirCol = BigBoard[0, 0] + BigBoard[1, 0] + BigBoard[2, 0];
            string SecCol = BigBoard[0, 1] + BigBoard[1, 1] + BigBoard[2, 1];
            string ThiCol = BigBoard[0, 2] + BigBoard[1, 2] + BigBoard[2, 2];
            string Diagon = BigBoard[0, 0] + BigBoard[1, 1] + BigBoard[2, 2];
            string RevDia = BigBoard[0, 2] + BigBoard[1, 1] + BigBoard[2, 0];

            if (TopRow.Equals(playerTriple)
                            || MidRow.Equals(playerTriple)
                            || BotRow.Equals(playerTriple)
                            || FirCol.Equals(playerTriple)
                            || SecCol.Equals(playerTriple)
                            || ThiCol.Equals(playerTriple)
                            || Diagon.Equals(playerTriple)
                            || RevDia.Equals(playerTriple)
                        )
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = player;
                    }
                }
                Console.WriteLine("And the winnes is " + player);
            }
        }
        public int SafelyConvertToInt(string s)
        {
            if (int.TryParse(s, out var i))
            {
                return i;
            }
            return -1;
        }
    }
}