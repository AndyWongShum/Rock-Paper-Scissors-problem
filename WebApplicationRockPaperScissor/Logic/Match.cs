using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApplicationRockPaperScissor
{
    class RockScissorPaperLogic
    {

        private string[] temp;
        List<string> newInput = new List<string>();
        List<string> winners = new List<string>();
        List<string> strategy = new List<string>();
        private string Message = "";
        FileManager f = new FileManager();
        private  bool End ;
        private bool tournament;
        private int playerName1;
        private int playerStrategy1;
        private int playerName2;
        private int playerStrategy2;
        private int i;
        private bool validInput;

        public void setFormat(string input)
        {
            //first we need to clean the lists
            newInput.Clear();
            strategy.Clear();

            //we add the strategys for a better flexibility in case we want to add lizard or spock
            strategy.Add("R");
            strategy.Add("P");
            strategy.Add("S");

            temp = (Regex.Replace(input, @"[^0-9a-zA-Z]+", " ")).Split(' ');

            //remove the extra space of the array
            //add the clean version of the string to a list, for a better use.
            for (int i = 1; i < temp.Length - 1; i++)
            {
                newInput.Add(temp[i]);
            }

        }

        public string match()
        {
            End = false;
            tournament = false;
            playerName1=0;
            playerStrategy1=0;
            playerName2=0;
            playerStrategy2=0;
            i = 0;
            validInput = false;

            try
            {
                while (!End)
                {
                    //reset all parameters in case of a new round
                    winners.Clear();
                    playerName1 = 0;
                    playerStrategy1 = 1;
                    playerName2 = 2;
                    playerStrategy2 = 3;
                    i = 0;

                    while (i < (newInput.Count / 4))
                    {
                        //Insentitive case
                        newInput[playerStrategy1] = newInput[playerStrategy1].ToUpper();
                        newInput[playerStrategy2] = newInput[playerStrategy2].ToUpper();

                        //Verify the rules, so it can display de winner
                        if (!strategy.Contains(newInput[playerStrategy1]) || !strategy.Contains(newInput[playerStrategy2]))
                        {
                            throw new System.InvalidOperationException();
                        }

                        //check if they got the same strategy
                        //its separated in case this rule has to be changed
                        if (newInput[playerStrategy1] == newInput[playerStrategy2])
                        {
                            Message = "[" + "\"" + newInput[playerName1] + "\"" + ", " + "\"" + newInput[playerStrategy1] + "\"" + "]";
                            winners.Add(newInput[playerName1]);
                            winners.Add(newInput[playerStrategy1]);
                            validInput = true;
                        }
                        //check who wins between diferent strategy
                        if ((newInput[playerStrategy1] == "P" && newInput[playerStrategy2] == "R") || (newInput[playerStrategy1] == "R" && newInput[playerStrategy2] == "S") || (newInput[playerStrategy1] == "S" && newInput[playerStrategy2] == "P"))
                        {
                            Message =  "[" + "\"" + newInput[playerName1] + "\"" + ", " + "\"" + newInput[playerStrategy1] + "\"" + "]";
                            winners.Add(newInput[playerName1]);
                            winners.Add(newInput[playerStrategy1]);
                            validInput = true;
                        }
                        else
                        {
                            Message = "[" + "\"" + newInput[playerName2] + "\"" + ", " + "\"" + newInput[playerStrategy2] + "\"" + "]";
                            winners.Add(newInput[playerName2]);
                            winners.Add(newInput[playerStrategy2]);
                            validInput = true;
                        }

                        //set the new index to compare
                        playerName1 = playerName1 + 4;
                        playerStrategy1 = playerStrategy1 + 4;
                        playerName2 = playerName2 + 4;
                        playerStrategy2 = playerStrategy2 + 4;
                        i++;
                    }
                    //check if there is a missing players
                    if (!validInput) {
                        throw new System.InvalidOperationException();
                    }

                    if (winners.Count > 2)
                    {
                        //clean the list so we can add a new one
                        newInput.Clear();
                        //add the winners list
                        newInput = winners.ToList();
                        
                        //set the flag so we can know if we are at a tournament or not.
                        tournament = true;
                    }
                    if (winners.Count == 2)
                    {
                        End = true;
                        winners.Clear();
                        newInput.Clear();

                        if (tournament)
                        {
                            f.writeWinners(Message);
                        }
                        
                        return "The winner is " + Message;
                    }
                }

                if (tournament)
                {
                    f.writeWinners(Message);
                }
                return "The winner is " + Message;
            }
            catch (System.InvalidOperationException ex)
            {
                return Message = "error";
            }
        }
    }
}
