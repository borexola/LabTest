using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LABTest.App_Code
{
    public class LeaderClass
    {

        public static int GetLeader(string filepath)
        {
            string fileLine = string.Empty;
            List<int> values = new List<int>();


            using (StreamReader file = new StreamReader(filepath))
            {
                while ((fileLine = file.ReadLine()) != null)
                {
                    //In case the content is not placed on the first line
                    if (fileLine.Trim() != string.Empty)
                    {
                        //get list of values and convert to list of integers
                        values = fileLine.Split(',').ToList().Select(s => int.Parse(s)).ToList();
                        break;
                    }
                }
            }

            return GetLeader(values);
        }


        public static int GetLeader(List<int> values)
        {
            int leader = -1;
            int leaderMinCount = 0;


            try
            {
                if (values.Count > 0)
                {
                    //Set minimum condition for a number to be a leader
                    leaderMinCount = (values.Count() / 2) + 1;

                    //Get distinct numbers
                    List<int> _distinctNumbers = values.Select(x => x).Distinct().ToList();

                    foreach (int num in _distinctNumbers)
                    {
                        ///Get how many times the number exists
                        int occurence = values.Where(x => x == num).Count();

                        if (occurence >= leaderMinCount)
                        {
                            leader = num;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return leader;
        }

        

    }
}