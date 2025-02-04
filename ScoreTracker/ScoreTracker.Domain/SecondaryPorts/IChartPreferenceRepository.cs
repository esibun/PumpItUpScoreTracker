﻿using ScoreTracker.Domain.Enums;
using ScoreTracker.Domain.Records;
using ScoreTracker.Domain.ValueTypes;

namespace ScoreTracker.Domain.SecondaryPorts
{
    public interface IChartPreferenceRepository
    {
        Task SaveRating(MixEnum mix, Guid userId, Guid chartId, Rating rating, CancellationToken cancellationToken);

        Task SetAverageRating(MixEnum mix, Guid chartId, Rating averageRating, int ratingCount,
            CancellationToken cancellationToken);

        Task<IEnumerable<ChartPreferenceRatingRecord>> GetPreferenceRatings(MixEnum mix,
            CancellationToken cancellationToken);

        Task<IEnumerable<Rating>> GetRatingsForChart(MixEnum mix, Guid chartId, CancellationToken cancellationToken);

        Task<IEnumerable<UserRatingsRecord>> GetUserRatings(MixEnum mix, Guid userId,
            CancellationToken cancellationToken);
    }
}
