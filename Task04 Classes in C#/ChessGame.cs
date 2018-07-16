using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    class Board
    {
        private string[,] board;
        int whitePieces, blackPieces;
        public Board()
        {
            board = new string[8, 8];
            whitePieces = blackPieces = 16;
            
        }
        public void DecWhitePiece()
        {
            whitePieces--;
        }
        public void DecBlackPiece()
        {
            blackPieces--;
        }

        public void PutPiece(Piece P,int x,int y)
        {
            
            board[x,y] = P.Name;
        }
        public void DeletePiece(int x,int y)
        {
            board[x, y] = "";
        }

    }

    abstract class Piece
    {
        protected string name;
        protected char Color;
        protected int posx, posy;
        public string Name { get { return name;  } }
        public Piece()
        {
            name = "Queen";
        }
        public Piece(string name)
        {
            this.name = name;
        }
        protected virtual bool CanMove(int x,int y,Board B)
        {
            return true;
        }
        public virtual void Move(int x, int y,Board B)
        {
            B.DeletePiece(posx, posy);
        }
        public abstract void ShowMoveMessage();
    }

    sealed class King : Piece
    {

        public King(char Color,int x,int y) : base("King")
        {
            this.Color = Color;
            posx = x;
            posy = y;
        }
        protected override bool CanMove(int x, int y, Board B)
        {
            if (x == posx && y == posy)
                return false;
            if (x > 8 || x < 1 || y > 8 || y < 1)
                return false;
            if (Math.Abs(x - posx) <= 1 && Math.Abs(y - posy) <= 1)
                return true;
            else
                return false;
        }
        public override void Move(int x, int y, Board B)
        {
            base.Move(x, y, B);
            B.PutPiece(this, x, y);
        }
        public override void ShowMoveMessage()
        {
            Console.WriteLine("Moving King...");
        }

    }
    //TO DO: Implement all pieces

    class ChessGame
    {

        private Board board;
        List<Piece> gamePieces;
        public ChessGame()
        {
            board = new Board();
            gamePieces = new List<Piece>();
            gamePieces.Add(new King('W',8,5));
            gamePieces.Add(new King('B',1,5));
            //TO DO: Add all pieces...
        }

        //TO DO : Game Logics
    }

    class Program
    {

        public static void Main(String[] args)
        {
            var list = new List<Point>();
            var list2 = new List<IInterface>();

            
        }
    }

    struct Point : IInterface
    {

    }

    interface IInterface
    {

    }
}