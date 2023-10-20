using System;
using System.Text.RegularExpressions;
using Tasks_Management.Exceptions;

namespace Tasks_Management;
public static class Validator
{
    public static void ValidateIntRange(int value, int min, int max, string message)
    {
        if (value < min || value > max)
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateDecimalRange(decimal value, decimal min, decimal max, string message)
    {
        if (value < min || value > max)
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateSymbols(string value, string pattern, string message)
    {
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        if (!regex.IsMatch(value))
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateBugStatus(Commands.Enums.BugStatus value, string message)
    {
        if (value != Commands.Enums.BugStatus.Active && value != Commands.Enums.BugStatus.Fixed)
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateStoryStatus(Commands.Enums.StoryStatus value, string message)
    {
        if (value != Commands.Enums.StoryStatus.NotDone &&
            value != Commands.Enums.StoryStatus.InProgress &&
            value != Commands.Enums.StoryStatus.Done)
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateFeedbackStatus(Commands.Enums.FeedbackStatus value, string message)
    {
        if (value != Commands.Enums.FeedbackStatus.Scheduled &&
            value != Commands.Enums.FeedbackStatus.New &&
            value != Commands.Enums.FeedbackStatus.Done &&
            value != Commands.Enums.FeedbackStatus.Unscheduled)
        {
            throw new InvalidUserInputException(message);
        }
    }

    public static void ValidateString(string str, string msg)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new InvalidUserInputException(msg);
        }
    }
}