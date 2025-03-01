using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExampleClint;

public class Movie
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("director")]
    public string Director { get; set; } // rejissyorining ismi
    [JsonPropertyName("durationMinutes")]
    public int DurationMinutes { get; set; } // Davomiyligi (minutlarda)
    [JsonPropertyName("rating")]
    public double Rating { get; set; } // Baholanish (IMDB yoki shunga o'xshash)
    [JsonPropertyName("boxOfficeEarnings")]
    public long BoxOfficeEarnings { get; set; } // Yig'gan summasi (dollarda)
    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}, Title : {Title}, Director : {Director}, DurationMinutes : {DurationMinutes}," 
            +$" Rating : {Rating}, RD : {ReleaseDate}, BE : {BoxOfficeEarnings}";
    }
}
