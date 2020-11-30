using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class ThePianist
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Piece> pieceList = new Dictionary<string, Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split("|").ToArray();
                pieceList.Add(pieceInfo[0], new Piece(pieceInfo[0], pieceInfo[1], pieceInfo[2]));
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("|").ToArray();
                string command = tokens[0];

                if (command == "Stop")
                {
                    break;
                }

                string pieceName = tokens[1];

                switch (command)
                {
                    case "Add":

                        if (!pieceList.ContainsKey(pieceName))
                        {
                            pieceList.Add(pieceName, new Piece(pieceName, tokens[2], tokens[3]));
                            Console.WriteLine($"{pieceName} by {tokens[2]} in {tokens[3]} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }
                        break;

                    case "Remove":

                        if (!pieceList.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        else
                        {
                            pieceList.Remove(pieceName);
                            Console.WriteLine($"Successfully removed {pieceName}!");
                        }
                        break;

                    case "ChangeKey":

                        if (!pieceList.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        else
                        {
                            Piece newPiece = pieceList[pieceName];
                            newPiece.Key = tokens[2];
                            pieceList[pieceName] = newPiece;
                            
                            Console.WriteLine($"Changed the key of {pieceName} to {newPiece.Key}!");
                        }
                        break;
                }
            }

            foreach (var piece in pieceList.OrderBy(x => x.Value.Name).ThenBy(x => x.Value.Composer))
            {
                Console.WriteLine(piece.Value);
            }
        }

        class Piece
        {
            public Piece(string name, string composer, string key)
            {
                this.Name = name;
                this.Composer = composer;
                this.Key = key;
            }
            public string Name { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> Composer: {this.Composer}, Key: {this.Key}"; 
            }

        }
    }
}
