﻿using BashSoft.Models;
using BashSoft.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BashSoft
{
    public class StudentsRepository
    {
        private bool IsDataInitialized = false;
        private Dictionary<string, Student> students;
        private Dictionary<string, Course> courses;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.IsDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedExeption);
                return;
            }

            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.IsDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataNotInitializedExceptionMessage);
                return;
            }
            this.students = null;
            this.courses = null;
            this.IsDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.CurrentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);

                        string courseName = currentMatch.Groups[1].Value;
                        string studentName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();
                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }
                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }
                            if (!this.students.ContainsKey(studentName))
                            {
                                this.students.Add(studentName, new Student(studentName));
                            }
                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }
                            Course course = this.courses[courseName];
                            Student student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line: {line}");
                        }
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            IsDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        public bool IsQueryForCoursePossible(string courseName)
        {
            if (IsDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        public bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingStudentInDataBase);

            }
            return false;
        }

        public void GetStudentScoresFromTheCourse(string courseName, string studentName)
        {
            if (IsQueryForStudentPossible(courseName, studentName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentName, this.courses[courseName].StudentsByName[studentName].MarksByCourseName[courseName]));
            }
        }
        public void GetAllStudentsFromTheCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromTheCourse(courseName, studentMarksEntry.Key);
                }
            }
        }
        public void FilerAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }
                Dictionary<string, double> marks =
                    this.courses[courseName]
                        .StudentsByName
                        .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }
        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks =
                    this.courses[courseName]
                        .StudentsByName
                        .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }
    }
}
