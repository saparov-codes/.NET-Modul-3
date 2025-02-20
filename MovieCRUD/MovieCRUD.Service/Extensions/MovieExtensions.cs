using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Extensions;

public static class MovieExtensions
{
    public static double MinToHour (this double minute)
    {
        return minute / 60;
    }

    public static long TotalBoxOfficeEarnings(this List<MovieDto> movies)
    {
        var sum = 0l;
        foreach (var movie in movies)
        {
            sum += movie.BoxOfficeEarnings;
        }
        return sum;
    }
}
