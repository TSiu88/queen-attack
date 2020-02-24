using System;

class QueenAttack
{
  public class Queen
  {
    public Queen(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public static void canAttack(int xCoord, int yCoord)
    {
      bool horizontal = checkHorizontal(xCoord);
      bool vertical = checkVertical(yCoord);
      bool diagonal = checkDiagonal(xCoord, yCoord);
      // do return part here 
    }

    static void checkHorizontal(int other)
    {
      if (this.x == other){
        return true;
      } else {
        return false;
      }
    }

    static void checkVertical(int other)
    {
      if (this.y == other){
        return true;
      } else {
        return false;
      }
    }

    static void checkDiagonal(int otherX, int otherY)
    {
      if (otherX < 7 && otherY < 7){
        for (int i = this.x; i < 8; i++){
          if (this.x + i == otherX){
            if (this.y + i == otherY){
              return true;
            } else if (this.y - i == otherY){
              return true;
            } else if (this.y + i > 8) {
              break;
            }
          }
        }

        for (int j = 1; j <= this.x; j++){
          if (this.x - j == otherX){
            if (this.y - j == otherY){
              return true;
            } else if (this.y + j == otherY){
              return true;
            } else if (this.y - j < 0) {
              break;
            }
          }
        }
      } else {
        return false;
      }
    }
  }
  static void Main()
  {
    Console.WriteLine("Enter Queen's coordinates X,Y");
    string[] queenInput = Console.ReadLine().Split(",");
    Console.WriteLine("Enter other pieces's coordinates X,Y");
    string[] otherInput = Console.ReadLine().Split(",");
    int[] queenCoordinates = getCoordinates(queenInput);
    int[] otherCoordinates = getCoordinates(otherInput);
    Queen queen = new Queen(queenCoordinates[0], queenCoordinates[1]);
    bool attack = queen.canAttack(otherCoordinates[0], otherCoordinates[1]);
    if (attack == true){
      Console.WriteLine("Queen can attack!");
    } else {
      Console.WriteLine("Queen can not attack.");
    }
    
  }

  static void getCoordinates(string[] input)
  {
    int xCoord = int.Parse(input[0]);
    int yCoord = int.Parse(input[1]);
    int[] coordinates = {xCoord, yCoord};
    return coordinates;
  }
  
}