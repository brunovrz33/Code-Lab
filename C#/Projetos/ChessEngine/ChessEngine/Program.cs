using System;
using System.Threading;
using board;
using chess;

namespace chess_console
{
    class Program
    {
        static int secondsLeft;
        static bool timeExpired;
        static CancellationTokenSource cts;
        static int timerRow; // row on screen where timer is displayed

        static void Main(string[] args)
        {
            try
            {
                ChessGame game = new ChessGame();

                while (!game.finished)
                {
                    try
                    {
                        RunTurn(game);
                    }
                    catch (BoardException e)
                    {
                        cts?.Cancel();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                    if (timeExpired)
                    {
                        AnnounceTimeout(game);
                        break;
                    }
                }

                if (!timeExpired)
                {
                    Console.Clear();
                    Screen.printGame(game);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        static void RunTurn(ChessGame game)
        {
            // --- Origin input ---
            StartTimer();
            Console.Clear();
            Screen.printGame(game);

            // Save the row where timer will be shown
            timerRow = Console.CursorTop;
            PrintTimerBar();

            Console.WriteLine();
            Console.Write("Origin: ");
            string originStr = Console.ReadLine()!;
            cts.Cancel();

            if (timeExpired || secondsLeft <= 0) return;

            Position origin = Screen.ParseChessPosition(originStr).toPosition();
            game.validateOriginPosition(origin);
            bool[,] possibleMoves = game.board.piece(origin).possibleMoves();

            // --- Destination input ---
            StartTimer();
            Console.Clear();
            Screen.printGame(game);
            Screen.printBoard(game.board, possibleMoves);

            timerRow = Console.CursorTop;
            PrintTimerBar();

            Console.WriteLine();
            Console.Write("Destination: ");
            string destStr = Console.ReadLine()!;
            cts.Cancel();

            if (timeExpired || secondsLeft <= 0) return;

            Position destination = Screen.ParseChessPosition(destStr).toPosition();
            game.validateDestinationPosition(origin, destination);
            game.performMove(origin, destination);
        }

        static void StartTimer()
        {
            secondsLeft = 10;
            timeExpired = false;
            cts = new CancellationTokenSource();
            Thread timerThread = new Thread(() => Countdown(cts.Token));
            timerThread.IsBackground = true;
            timerThread.Start();
        }

        static void Countdown(CancellationToken token)
        {
            while (secondsLeft > 0 && !token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                if (token.IsCancellationRequested) break;

                secondsLeft--;

                // Update timer on screen
                int savedTop = Console.CursorTop;
                int savedLeft = Console.CursorLeft;

                Console.SetCursorPosition(0, timerRow);
                PrintTimerBar();

                // Restore cursor to where the user was typing
                Console.SetCursorPosition(savedLeft, savedTop);

                if (secondsLeft <= 0)
                {
                    timeExpired = true;
                }
            }
        }

        static void PrintTimerBar()
        {
            ConsoleColor color = secondsLeft <= 4
                ? ConsoleColor.Red
                : ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.Write($"  ⏱  Time remaining: {secondsLeft,2} seconds   ");
            Console.ResetColor();
        }

        static void AnnounceTimeout(ChessGame game)
        {
            Console.Clear();
            Screen.printGame(game);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============================");
            Console.WriteLine($"  TIME'S UP! {game.currentPlayer} loses!");
            Console.WriteLine("=============================");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}