// See https://aka.ms/new-console-template for more information
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace  RewardPointCalculator
{
    class RewardPointCalculator

    {
        static void Main(string[] args)
        {
            IDictionary<int,int> Rewards = new Dictionary<int,int>();
            List<int> Transaction = new List<int>(){-120,100,78,25};
            string Fname = Environment.GetCommandLineArgs()[1];
            Console.WriteLine(Fname);
            IDictionary<int,int> records = ParseTransactionRecords(Fname);
            Rewards = RewardCalculator(records);
        }
        public static IDictionary<int,int> RewardCalculator(IDictionary<int,int> Transaction_Amount)
        {
            try
            {
                int n = Transaction_Amount.Count();
                int RewardAmount = 0;
                IDictionary<int,int> RewardPoint = new Dictionary<int,int>();
                //Iterating the records using the dictionary key
                foreach (var item in Transaction_Amount)
                {                    
                    if (item.Value > 100)
                    {
                        // Adding reward of 2 points for every dollar spent over $100 in each transaction + 1 point for every dollar spent over $50
                        RewardAmount = (item.Value -100)*2 + 50;
                    }
                    else if (item.Value >= 50 && item.Value <=100)
                    {
                        // 1 point for every dollar spent over $50
                        RewardAmount = (item.Value -50);
                    }
                    else 
                    {
                        //No point is rewarded for transaction below $50
                        RewardAmount = 0;
                    }
                    Console.WriteLine("Processed for RecordID {0}:  Amount:{1}   Rewardpoints:{2}",item.Key,item.Value,RewardAmount);
                    RewardPoint.Add(item.Key,RewardAmount);
                }
                return RewardPoint;
            }             
            catch (System.Exception)
            {                
                throw;
            }
        }

        public static IDictionary<int,int> ParseTransactionRecords(string filename)
        {
            try
            {
                IDictionary<int,int> records = new Dictionary<int,int>() ;
                // Taking the input dataset and Parsing it
                string text = File.ReadAllText(filename); 
                if (File.Exists(filename) && text.Length !=0)
                {            
                    string[] lines = File.ReadAllLines(filename);// seperates each line from the text file
                    foreach(string line in lines)
                    {                
                        string [] value = line.Split(' ');
                        int _rid = int.Parse(value[0].Replace('\\', ' ').Trim());
                        int _ramt = int.Parse(value[1].Replace('\\', ' ').Trim());    
                        if (_ramt < 0){throw new InvalidRecordException ("Please enter amount greater than zero");} 
                        records.Add(_rid, _ramt);// trimming presence of any special characters
                    }                
                }
                if(text.Length ==0)
                {
                    Console.WriteLine("No Data found: File is empty ");
                } 
                return records;                
            }
            catch(InvalidRecordException e)
             {
                 Console.WriteLine("InvalidRecordException : {0}",e.Message);
                 throw;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("FileNotFound: Unable to find the Input file ");
                throw;
            }            
            catch(InvalidCastException e)
            {
                Console.WriteLine("InvalidCastExpression: {0} Please enter valid entries ",e);
                throw;
            }
            catch(FormatException e)
            {
                Console.WriteLine("Please provide input records in correct format",e);
                throw;
            }
            catch (System.Exception)
            {                
                throw;
            }
            
        }
    }
    public class InvalidRecordException:Exception
    {
        public InvalidRecordException(){}
        public InvalidRecordException (string message) : base(message){ }
    }
}

