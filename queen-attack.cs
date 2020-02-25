using System;

public class Queen
{
  public int QueenX;
  public int QueenY;
  public Queen(int x, int y)
  {
    QueenX = x;
    QueenY = y;
  }

  public bool canAttack(int xCoord, int yCoord)
  {
    bool horizontal = checkHorizontal(xCoord);
    bool vertical = checkVertical(yCoord);
    bool diagonal = checkDiagonal(xCoord, yCoord);
    if (horizontal || vertical || diagonal){
      return true;
    } else {
      return false;
    }
  }

  public bool checkHorizontal(int otherX)
  {
    if (this.QueenX == otherX){
      return true;
    } else {
      return false;
    }
  }

  public bool checkVertical(int otherY)
  {
    if (this.QueenY == otherY){
      return true;
    } else {
      return false;
    }
  }

  public bool checkDiagonal(int otherX, int otherY)
  {
    for (int i = this.QueenX; i < 7; i++){
      if (this.QueenX + (7-i) == otherX){
        if (this.QueenY + (7-i) == otherY){
          return true;
        } else if (this.QueenY - (7-i) == otherY){
          return true;
        } else if (this.QueenY + (7-i) > 8) {
          break;
        }
      }
    }

    for (int j = 1; j <= this.QueenX; j++){
      if (this.QueenX - j == otherX){
        if (this.QueenY - j == otherY){
          return true;
        } else if (this.QueenY + j == otherY){
          return true;
        } else if (this.QueenY - j < 0) {
          break;
        }
      }
    }
    return false;
  }
}
class QueenAttack
{
  static void Main()
  {
    Console.WriteLine("Enter Queen's coordinates X,Y");
    string[] queenInput = Console.ReadLine().Split(",");
    checkCoordinates(queenInput);
    int[] queenCoordinates = getCoordinates(queenInput);
    Console.WriteLine("Enter other pieces's coordinates X,Y");
    string[] otherInput = Console.ReadLine().Split(",");
    checkCoordinates(otherInput);
    int[] otherCoordinates = getCoordinates(otherInput);
    Queen queen = new Queen(queenCoordinates[0], queenCoordinates[1]);
    bool attack = queen.canAttack(otherCoordinates[0], otherCoordinates[1]);
    if (attack == true){
      Console.WriteLine("Queen can attack!");
    } else {
      Console.WriteLine("Queen can not attack.");
    }
    System.Environment.Exit(0);  
  }

  static int[] getCoordinates(string[] input)
  {
    int xCoord;
    int yCoord;

    bool xIsInt = int.TryParse(input[0], out xCoord);
    bool yIsInt= int.TryParse(input[1], out yCoord);
    if (xIsInt && yIsInt){
      int[] coordinates = {xCoord, yCoord};
      return coordinates;
    } else {
      Console.WriteLine("Invalid. Enter numbers for coordinates.");
      int[] coord = {-1};
      return coord;
    }
    
    
  }
  
  static void checkCoordinates(string[] input)
  {
    if (input.Length <= 1 || string.IsNullOrEmpty(input[0])){
      Console.WriteLine("Invalid coordinates.  Need X and Y coordinates.");
      Main();
    } else {
      int[] test = getCoordinates(input);
      if (test[0] == -1){
        Main();
      } else if (test[0] < 0 || test[0] > 7 || test[1] < 0 || test[1] > 7){
      Console.WriteLine("Invalid coordinates. Choose between 0 and 7.");
      Main();
      }
    } 
  }

}