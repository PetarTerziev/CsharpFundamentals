using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursesPlanning
{
    class SoftUniCoursesPlanning
    {
        static void Main(string[] args)
        {
            List<string> lessonsList = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string [] tokens = Console.ReadLine().Split(":").ToArray();
                string command = tokens[0];

                if (command == "course start")
                {
                    break;
                }

                string lessonTitle = tokens[1];

                if (command == "Add" && !lessonsList.Contains(lessonTitle))
                {
                    lessonsList.Add(lessonTitle);
                }
                else if (command == "Insert" && !lessonsList.Contains(lessonTitle))
                {
                    lessonsList.Insert(int.Parse(tokens[2]), lessonTitle);
                }
                else if (command == "Remove" && lessonsList.Contains(lessonTitle))
                {
                    lessonsList.Remove(lessonTitle);

                    if (lessonsList.Contains($"{lessonTitle}-Exercise"))
                    {
                        lessonsList.Remove($"{lessonTitle}-Exercise");
                    }
                }
                else if (command == "Exercise" && !lessonsList.Contains($"{lessonTitle}-Exercise"))
                {
                    if (lessonsList.Contains(lessonTitle))
                    {
                        int indexOfLesson = lessonsList.IndexOf(lessonTitle);
                        lessonsList.Insert(indexOfLesson + 1, $"{lessonTitle}-Exercise");
                    }
                    else
                    {
                        lessonsList.Add(lessonTitle);
                        lessonsList.Add($"{lessonTitle}-Exercise");
                    }
                }
                else if (command == "Swap")
                {
                    string lessonTitleSwap = tokens[2];

                    if (lessonsList.Contains(lessonTitle) && lessonsList.Contains(lessonTitleSwap))
                    {
                        int indexOfLessonTitle = lessonsList.IndexOf(lessonTitle);
                        int indexOfLessonSwap = lessonsList.IndexOf(lessonTitleSwap);
                        lessonsList[indexOfLessonTitle] = lessonTitleSwap;
                        lessonsList[indexOfLessonSwap] = lessonTitle;
                    }

                    if (lessonsList.Contains($"{lessonTitle}-Exercise"))
                    {
                        string exercisesTitle = $"{lessonTitle}-Exercise";
                        lessonsList.Remove($"{lessonTitle}-Exercise");
                        lessonsList.Insert(lessonsList.IndexOf(lessonTitle) + 1, exercisesTitle);
                    }

                    if (lessonsList.Contains($"{lessonTitleSwap}-Exercise"))
                    {
                        string exercisesTitle = $"{lessonTitleSwap}-Exercise";
                        lessonsList.Remove(exercisesTitle);
                        lessonsList.Insert(lessonsList.IndexOf(lessonTitleSwap) + 1, exercisesTitle);
                    }
                }
            }

            for (int i = 0; i < lessonsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessonsList[i]}");
            }
        }
    }
}
