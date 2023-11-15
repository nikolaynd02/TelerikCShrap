using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorsOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> patients = new List<string>();

            LinkedList<string> patients = new LinkedList<string>();

            StringBuilder output = new StringBuilder();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdParams = input.Split().ToArray();

                string cmdType = cmdParams[0];

                if(cmdType == "Append")
                {
                    patients.AddLast(cmdParams[1]);
                    
                    output.AppendLine("OK");
                }
                else if(cmdType == "Insert")
                {
                    int position = int.Parse(cmdParams[1]);
                    string name = cmdParams[2];

                    if(position < 0 ||  position > patients.Count) 
                    {
                        output.AppendLine("Error");
                        continue;
                    }

                    if(position == patients.Count)
                    {
                        patients.AddLast(name);
                        output.AppendLine("OK");
                        continue;
                    }

                    var curr = patients.First;

                    for(int i = 1; i <= position; i++)
                    {
                        curr = curr.Next;
                    }

                    LinkedListNode<string> inserter = new LinkedListNode<string>(name);

                    patients.AddBefore(curr, inserter);


                    output.AppendLine("OK");
                }
                else if(cmdType == "Find")
                {
                    string name = cmdParams[1];

                    int patientsWithName = patients.Where(p => p == name).Count();

                    output.AppendLine(patientsWithName.ToString());
                }
                else if(cmdType == "Examine")
                {
                    int count = int.Parse(cmdParams[1]);


                    if(count > patients.Count)
                    {
                        output.AppendLine("Error");
                        continue;
                    }

                    StringBuilder temp = new StringBuilder();

                    for(int i = 0; i < count; i++)
                    {
                        temp.Append(patients.First.Value);
                        patients.RemoveFirst();
                    }

                    output.AppendLine(temp.ToString().Trim());

                }


            }

            Console.WriteLine(output.ToString());
        }
    }
}