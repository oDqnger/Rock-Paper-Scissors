using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class RockPaperScisscors {

     static string playerOneName = "";
     static string playerTwoName = "";
     static string robotName = "";
     public static void Main(string[] args) {
          Entrance();
     }

     static void Entrance() {
          Thread.Sleep(1000);
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Welcome to rock, paper scissors!");
          Thread.Sleep(1000);
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("If you have not played rps before and you do not know the rules or how to play, please press 'r'. If you do know and you would like to play, press any button on the keyboard. (r/any)");
          
          string? input = Console.ReadLine();

          if (input.ToLower() == "r") {
               Thread.Sleep(500);
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine("The rules are fairly simple. There are two players, each of the two players have to choose an option, rock, paper or scissors");
               Console.WriteLine("Now once both of the players have chosen their item, they must show it to their opposing partner.");
               Thread.Sleep(2000);
               Console.WriteLine("If one person has chosen rock and the other has chosen scissors, rock beats scissors, therefore gaining one point");
               Thread.Sleep(2000);
               Console.WriteLine("If they have chosen paper and the other player has chosen rock, paper beats it");
               Thread.Sleep(1000);
               Console.WriteLine("If they have chosen paper and the other player has chosen scissors, scissors beats it \n");

               Thread.Sleep(1900);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("So in summary: ");
               Thread.Sleep(1500);
               Console.WriteLine("Paper beats rock, paper loses to scissors and it ties if paper fights paper.\n");
               Console.WriteLine("Rock beats scissors, rock loses to paper and rock ties with rock\n");
               Console.WriteLine("Scissor beats paper, scissor loses to rock and scissor ties with scissor\n");

               Console.WriteLine("Hope the rules are easy to understand :)");
               Thread.Sleep(2000);
          }

          Console.ForegroundColor = ConsoleColor.Gray;
          Console.WriteLine("In this version of rps, you can either play against a robot (which will just randomly pick an option) or against a trustworthy friend! (not online)");
          Thread.Sleep(2500);
          Console.WriteLine("If you would like to play against a robot, press 'r' or if you want to play against a friend, press 'f'");
          input = Console.ReadLine();

          while (true) {
               if (input.ToLower() == "r") {
                    Robot();
                    break;
               } else if(input.ToLower() == "f") {
                    Friend();
                    break;
               } else if (input.ToLower() == "q" || input.ToLower() == "quit") {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Thanks for coming!");
                    System.Environment.Exit(1);
               }
               else {
                    Console.WriteLine("Sorry, I did not get what you said, please try again");
               }
          }
     }

     static void Robot() {
          int roundsPlayed = 0;
          int currentRounds = 0;
          int randomOption;
          string option;

          int robotPoints = 0;
          int humanPoints = 0;

          Random rnd = new Random();
          
          while (true) {
               while (true) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter how many rounds of rps you would like to play: ");
                    try {
                         roundsPlayed = Convert.ToInt32(Console.ReadLine());
                    } catch {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Sorry, but the input is not a number. Please try again.");
                         continue;
                    }

                    if (roundsPlayed == 0) {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Sorry. You cannot choose 0 rounds, please try again.");
                         continue;
                    }

                    break;
               }
               Thread.Sleep(1000);
               
               Console.WriteLine("Please enter your name (you can choose to skip this by saying n): ");
               playerOneName = Console.ReadLine();

               Console.WriteLine("If you would like, please enter the robot's name, if not you can type 'n': ");
               robotName = Console.ReadLine();

               if (robotName == "n") {
                    robotName = "Robot";
               }
               if (playerOneName == "n") {
                    playerOneName = "You";
               } 

               while (currentRounds < roundsPlayed) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Thread.Sleep(1000);
                    Console.WriteLine("What option you would like to pick: r or 0 (for rock), p or 1 (for paper) or s or 2(for scissors)");
                    Thread.Sleep(1000);
                    option = Console.ReadLine();

                    randomOption = rnd.Next(0,3);
                    if (option.ToLower() == "r" || option.ToLower() == "0") {
                         switch(randomOption) {
                              case 0:
                                   Console.ForegroundColor = ConsoleColor.DarkGray;
                                   Console.WriteLine("That is a tie! You and the robot chose rock. No point given to anyone");
                                   break;
                              case 1:  
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine($"You lose! {robotName} chose paper and you chose rock. Point given to robot");
                                   robotPoints++;
                                   break;
                              case 2:
                                   Console.ForegroundColor = ConsoleColor.Green;
                                   Console.WriteLine($"You win! {robotName} chose scissor and you chose rock. Point given to you.");
                                   humanPoints++;
                                   break;
                         }

                         currentRounds++;
                    } else if (option.ToLower() == "p" || option.ToLower() == "1") {
                         switch(randomOption) {
                              case 0:
                                   Console.ForegroundColor = ConsoleColor.Green;
                                   Console.WriteLine($"You win! {robotName} chose rock and you chose paper. Point given to you");
                                   humanPoints++;
                                   break;
                              case 1:
                                   Console.ForegroundColor = ConsoleColor.DarkGray;
                                   Console.WriteLine($"That is a tie! You and the {robotName} chose paper. No point given to anyone");
                                   break;
                              case 2:
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine($"You lose! {robotName} chose scissor and you chose paper. Point given to robot!");
                                   robotPoints++;
                                   break;
                         }

                         currentRounds++;

                    } else if (option.ToLower() == "s" || option == "2") {
                         switch(randomOption) {
                              case 0:
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine($"You lose! {robotName} chose rock and you chose scissor. Point given to robot.");
                                   robotPoints++;
                                   break;
                              case 1:
                                   Console.ForegroundColor = ConsoleColor.Green;
                                   Console.WriteLine($"You win! {robotName} chose paper and you chose scissor. Point given to you.");
                                   humanPoints++;
                                   break;
                              case 2:
                                   Console.ForegroundColor = ConsoleColor.DarkGray;
                                   Console.WriteLine($"That is a tie! You and the {robotName} chose scissor. No points given.");
                                   break;
                         }

                         currentRounds++;
                    } else if (option.ToLower() == "q" || option.ToLower() == "quit") {
                         Console.ForegroundColor = ConsoleColor.DarkYellow;
                         Console.WriteLine("Thanks for coming!");
                         System.Environment.Exit(1);
                    }
                    else {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Please try again");
                         continue;
                    }
               }

               Console.ForegroundColor = ConsoleColor.White;
               Thread.Sleep(3000);
               Console.WriteLine($"All {roundsPlayed} have been done! Here are the scores: ");
               Thread.Sleep(1000);
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.WriteLine($"{playerOneName}: {humanPoints} - {robotName}: {robotPoints}");
               Thread.Sleep(2000);

               if (humanPoints > robotPoints) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{playerOneName} won!");
               } else if (robotPoints > humanPoints){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{robotName} won!");
               } else { 
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Damn, thats a tie. good game lad");
               }

               Thread.Sleep(2000);
               Console.WriteLine("Would you like to play again? (y/n) ");

               if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes") {
                    Thread.Sleep(200);
                    Console.WriteLine("Great!");
                    robotPoints = 0;
                    humanPoints = 0;
                    currentRounds = 0;
                    roundsPlayed = 0;
                    continue;
               } else {

                    Console.WriteLine("Would you like to play against your friend or would you like to quit the application? (f/q) ");
                    if (Console.ReadLine().ToLower() == "f") {
                         Friend();
                         break;
                    } else {
                         Console.ForegroundColor = ConsoleColor.DarkYellow;
                         Console.WriteLine("Thanks for playing!");
                         Environment.Exit(1);
                         break;
                    }
               }
          } 
     }

     static void Friend() {
          int roundsPlayed;
          int currentRounds = 0;
          string playerOneOption;
          string playerTwoOption;

          int playerOnePoint = 0;
          int playerTwoPoint = 0;

          while(true) {
               while(true) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter how many rounds of rps you would like to play: ");

                    try {
                         roundsPlayed = Convert.ToInt32(Console.ReadLine());
                    } catch {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Sorry, but the input is not a number. Please try again.");
                         continue;
                    }
                    
                    if (roundsPlayed == 0) {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Sorry, you cannot choose 0 rounds. Please try again");
                         continue;
                    }

                    break;
               }

               Thread.Sleep(1000);

               Console.WriteLine("Please enter player one name (you can choose to not do this by typing 'n'): ");
               playerOneName = Console.ReadLine();

               Console.WriteLine("Please enter player two name (you can choose to not do this by typing 'n'): ");
               playerTwoName = Console.ReadLine();

               if (playerTwoName == "n") {
                    playerTwoName = "Robot";
               } 

               if (playerOneName == "n") {
                    playerOneName = "You";
               }

               while(currentRounds < roundsPlayed) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{playerOneName}, please choose your move (r or 0 for rock, p or 1 for paper or s or 2 for scissors): ");
                    playerOneOption = Console.ReadLine();
                    Thread.Sleep(1000);
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{playerTwoName}, please choose your move (r or 0 for rock, p or 1 for paper or s or 2 for scissor): ");
                    playerTwoOption = Console.ReadLine();
                    Thread.Sleep(1000);
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    if (playerOneOption == "r" || playerOneOption == "0") {
                         if (playerTwoOption == "r" || playerTwoOption == "0") {
                              Console.WriteLine($"That is a tie! {playerOneName} chose rock and {playerTwoName} chose rock. No points given.");
                         } else if (playerTwoOption == "p" || playerTwoOption == "1") {
                              Console.WriteLine($"{playerTwoName} won! {playerTwoName} chose paper and {playerOneName} chose rock. Point given to {playerTwoName}.");
                              playerTwoPoint++;
                         } else if (playerTwoOption == "s" || playerTwoOption == "2") {
                              Console.WriteLine($"{playerOneName} won! {playerOneName} chose paper and {playerTwoName} chose scissor. Point given to {playerOneName}.");
                              playerOnePoint++;
                         }
                    } else if (playerOneOption == "p" || playerOneOption == "1") {
                         if (playerTwoOption == "r" || playerTwoOption == "0") {
                              Console.WriteLine($"{playerOneName} won! {playerOneName} chose paper and {playerTwoName} chose rock. Point given to {playerOneName}.");
                              playerOnePoint++;
                         } else if (playerTwoOption == "p" || playerTwoOption == "1") {
                              Console.WriteLine($"That is a tie! {playerOneName} chose paper and {playerTwoName} chose paper. No points given.");
                         } else if (playerTwoOption == "s" || playerTwoOption == "2") {
                              Console.WriteLine($"{playerTwoName} won! {playerTwoName} chose scissor and {playerOneName} chose paper. Point given to {playerTwoName}.");
                              playerTwoPoint++;
                         }
                    } else if (playerOneOption == "s" || playerOneOption == "2") {
                         if (playerTwoOption == "r" || playerTwoOption == "0") {
                              Console.WriteLine($"{playerOneName} won! {playerOneName} chose scissor and {playerTwoName} chose rock. Point given to {playerOneName}.");
                              playerOnePoint++;
                         } else if (playerTwoOption == "p" || playerTwoOption == "1") {
                              Console.WriteLine($"{playerTwoName} won! {playerTwoName} chose paper and {playerOneName} chose scissor. Point given to {playerTwoName}.");
                              playerTwoPoint++;
                         } else if (playerTwoOption == "s" || playerTwoOption == "2") {
                              Console.WriteLine($"That is a tie! {playerOneName} chose paper and {playerTwoName} chose paper. No points given.");
                         }
                    } else if (playerOneOption.ToLower() == "q" || playerOneOption.ToLower() == "quit" || playerTwoOption.ToLower() == "q" || playerTwoOption.ToLower() == "quit")
                         System.Environment.Exit(1);
                    else {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Invalid response. Please try again.");
                         continue;
                    }

                    currentRounds++;
               }

               Console.ForegroundColor = ConsoleColor.Gray;
               Thread.Sleep(3000);
               Console.WriteLine($"All {roundsPlayed} have been done! Here are the scores: ");
               Thread.Sleep(1000);
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.WriteLine($"{playerOneName}: {playerOnePoint} - {playerTwoName}: {playerTwoPoint}");
               Thread.Sleep(2000);

               if (playerOnePoint > playerTwoPoint) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{playerOneName} won!");
               } else if (playerTwoPoint > playerOnePoint){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{playerTwoName} won!");
               } else { 
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Damn, thats a tie. good game lad");
               }

               Thread.Sleep(2000);
               Console.WriteLine("Would you like to play again? (y/n) ");

               if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes") {
                    Thread.Sleep(200);
                    Console.WriteLine("Great!");
                    playerOnePoint = 0;
                    playerTwoPoint = 0;
                    currentRounds = 0;
                    roundsPlayed = 0;
                    continue;
               } else {
                    Console.WriteLine("Would you like to play against a robot or would you like to quit the application? (r/q) ");
                    if (Console.ReadLine().ToLower() == "r") {
                         Robot();
                         break;
                    } else {
                         Console.WriteLine("Thanks for playing!");
                         Environment.Exit(1);
                         break;
                    }
               }
          }
     }
}