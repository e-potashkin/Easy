using System;
using System.Collections.Generic;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Easy.Infrastructure.Extensions
{
    public static class NpgsqlDbContextOptionsBuilderExtensions
    {
        public static NpgsqlDbContextOptionsBuilder AddDefaultRetryBehaviour(this NpgsqlDbContextOptionsBuilder builder)
        {
            return builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), default(List<string>));
        }
    }
}