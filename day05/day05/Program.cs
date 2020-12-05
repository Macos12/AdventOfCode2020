using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace day05
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
			string[] files = File.ReadAllLines(path);

			int max_id = 0;
			int idi = 0;
			int count = 0;
			foreach (string line in files)
			{
				Console.WriteLine(line);
				count++;
				var str = line;
				var strRow = str.Substring(0, 7);
				int startRow = 0; int endRow = 0; int row = 0;
				if (strRow[0].ToString() == "F")
				{
					startRow = 0;
					endRow = 63;
				}
				else if (strRow[0].ToString() == "B")
				{
					startRow = 64;
					endRow = 127;
				}
				Console.WriteLine(strRow[0].ToString() + " rows " + startRow + " through " + endRow);
				for (int i = 1; i < 7; i++)
				{
					if (i != 6)
					{
						if (strRow[i].ToString() == "B")
						{
							startRow = startRow + (endRow - startRow) / 2 + 1;
						}
						else
						{
							endRow = startRow + (endRow - startRow) / 2;
						}
						Console.WriteLine(strRow[i].ToString() + " rows " + startRow + " through " + endRow);
					}
					else
					{
						if (strRow[6].ToString() == "B")
						{
							row = endRow;
						}
						else
						{
							row = startRow;
						}
					}
				}
				Console.WriteLine("The final " + strRow[2].ToString() + " row " + row);
				Console.WriteLine();
				string strColumn = str.Substring(7, 3);
				int start = 0;
				int end = 7;
				int column = 0;
				for (int i = 0; i < 3; i++)
				{
					if (i != 2)
					{
						if (strColumn[i].ToString() == "R")
						{
							start = (end - start) / 2 + 1;
						}
						else
						{
							end = start + (end - start) / 2;
						}
						Console.WriteLine(strColumn[i].ToString() + " columns " + start + " through " + end);
					}
					else
					{
						if (strColumn[2].ToString() == "R")
						{
							column = end;
						}
						else
						{
							column = start;
						}
					}

				}
				Console.WriteLine("The final " + strColumn[2].ToString() + " column " + column);
				int id = row * 8 + column;
				if (max_id < id)
				{
					idi = count;
					max_id = id;
				}
				Console.WriteLine(str + ": row " + row + ", column " + column + ", seat ID " + id + ".");
				Console.WriteLine();
			}
			Console.WriteLine("The highest seat ID is " + max_id + " with " + files[idi]);
			Console.ReadKey();
		}
	}
}
