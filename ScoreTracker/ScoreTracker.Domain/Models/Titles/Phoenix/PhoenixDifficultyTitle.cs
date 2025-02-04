﻿using ScoreTracker.Domain.Enums;
using ScoreTracker.Domain.ValueTypes;
using System;

namespace ScoreTracker.Domain.Models.Titles.Phoenix;

public sealed class PhoenixDifficultyTitle : PhoenixTitle
{
    public PhoenixDifficultyTitle(Name name, DifficultyLevel level, int ratingRequired) : base(name,
        $"Get {ratingRequired} Rating on {level}s ({level.BaseRating} per AA)", "Difficulty", ratingRequired)
    {
        Level = level;
        RequiredRating = ratingRequired;
    }

    public DifficultyLevel Level { get; }
    public int RequiredRating { get; }

    public override int CompletionProgress(Chart chart, RecordedPhoenixScore attempt)
    {
        if (chart.Level != Level || attempt.IsBroken || attempt.Score == null) return 0;
        return (int)Math.Round(chart.Level.BaseRating * attempt.Score.Value.LetterGrade.GetModifier());
    }
}
