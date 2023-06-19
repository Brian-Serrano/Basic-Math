using Advance_Web_Programming_Project.Models.Quizzes;
using Advance_Web_Programming_Project.Models.Topic;
using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Others
{
    public static class ComponentGetter
    {
        public static List<string> GetQuiz(int courseId, Random random, int level)
        {
            switch (courseId)
            {
                case 0:
                    return new Arithmetic(random, level).GetComponent();
                case 1:
                    return new Quizzes.Others(random, level).GetComponent();
                case 2:
                    return new NumberSystem(random, level).GetComponent();
                case 3:
                    return new Probability(random, level).GetComponent();
                case 4:
                    return new LcmAndGcf(random, level).GetComponent();
                case 5:
                    return new Perimeter(random, level).GetComponent();
                case 6:
                    return new Area(random, level).GetComponent();
                case 7:
                    return new Volume(random, level).GetComponent();
                case 8:
                    return new Fraction(random, level).GetComponent();
                case 9:
                    return new Algebra(random, level).GetComponent();
                case 10:
                    return new Sets(random, level).GetComponent();
                case 11:
                    return new Statistics(random, level).GetComponent();
                default:
                    throw new ArgumentException("Invalid course ID");
            }
        }

        public static List<string> GetTopic(int courseId, int type)
        {
            switch (courseId)
            {
                case 0:
                    return new ArithmeticTopic().GetTopic()[type];
                case 1:
                    return new OthersTopic().GetTopic()[type];
                case 2:
                    return new NumberSystemTopic().GetTopic()[type];
                case 3:
                    return new ProbabilityTopic().GetTopic()[type];
                case 4:
                    return new LcmAndGcfTopic().GetTopic()[type];
                case 5:
                    return new PerimeterTopic().GetTopic()[type];
                case 6:
                    return new AreaTopic().GetTopic()[type];
                case 7:
                    return new VolumeTopic().GetTopic()[type];
                case 8:
                    return new FractionTopic().GetTopic()[type];
                case 9:
                    return new AlgebraTopic().GetTopic()[type];
                case 10:
                    return new SetsTopic().GetTopic()[type];
                case 11:
                    return new StatisticsTopic().GetTopic()[type];
                default:
                    throw new ArgumentException("Invalid course ID");
            }
        }

        public static List<CompletedAchievement> GetAchievement(Achievement obj, List<int> id)
        {
            List<CompletedAchievement> completedAchievements = new List<CompletedAchievement>();

            for(int i = 0; i < id.Count; i++)
            {
                completedAchievements.Add(new CompletedAchievement { Id = id[i], Name = obj.GetTitle()[id[i]], Description = obj.GetDescription()[id[i]] });
            }

            return completedAchievements;
        }
    }
}