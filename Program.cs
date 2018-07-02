using System;
using System.IO;

namespace dev275x.studentlist
{
    class Program
    {
        // The Main method 
        static void Main(string[] args)
        {
           
            /* Check arguments */
			if(args.Length == null || args.Length != 1)
			{
				Console.WriteLine("ERROR");
				return;
			}
			var fileContents = LoadData(Constants.StudentList);
            if (args[0] == "a") 
			{
				var words = fileContents.Split(',');
                foreach(var j in words) 
				{
					Console.WriteLine(j);
				}
              
            }
            else if (args[0]== Constants.ShowRandom)
            {
                Console.WriteLine("Loading data ...");
				
                // We are loading data
             
                var words = fileContents.Split(',');
                var randomWord = new Random();
                var y = randomWord.Next(0,words.Length);
                Console.WriteLine(words[y]);
             
            }

            else if (args[0].Contains(Constants.AddEntry))
            {
				
                // read
                Console.WriteLine("Loading data ...");
            
                var rr = args[0].Substring(1);
            
				
                // Write
          
            }
            else if (args[0].Contains(Constants.FindEntry))
			{ 
				var word = fileContents.Split(',');
                bool done = false;
                var t = args[0].Substring(1);
                for (int idx = 0; idx < word.Length && !done; idx++)
                {
                    if (word[idx] == t)
                        Console.WriteLine("We found it!");
                        done = true;
                }
            }
            else if (args[0].Contains(Constants.ShowCount))
			{ 
                var character = fileContents.ToCharArray();
                var in_word = false;
				var count = 0;
				Console.WriteLine(String.Format("{0} words found", count));
			}
		
		}
		static string LoadData(string fileName)
       {
        
			// The 'using' construct does the heavy lifting of flushing a stream
			// and releasing system resources the stream was using.
			using (var fileStream = new FileStream(fileName, FileMode.Open))
			using (var reader = new StreamReader(fileStream))
			{

				// The format of our student list is that it is two lines.
				// The first line is a comma-separated list of student names. 
				// The second line is a timestamp. 
				// Let's just retrieve the first line, which is the student names. 
				return reader.ReadLine();
			}	
		}


		// Writes the given string of data to the file with the given file name.
		//This method also adds a timestamp to the end of the file. 
		static void UpdateContent(string content, string fileName)
		{
			var timestamp = String.Format("List last updated on {0}", DateTime.Now);

			// The 'using' construct does the heavy lifting of flushing a stream
			// and releasing system resources the stream was using.
			using (var fileStream = new FileStream(fileName, FileMode.Open))
			using (var writer = new StreamWriter(fileStream))
			{
				writer.WriteLine(content);
				writer.WriteLine(timestamp);
			}
		}
    }
}